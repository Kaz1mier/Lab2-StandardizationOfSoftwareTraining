using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public class FoundConstruct
    {
        public int Line { get; set; }
        public string Operator { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    public class StatementStat
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class AnalysisResult
    {
        public int CL { get; set; }
        public double cl { get; set; }
        public int CLI { get; set; }
        public int N { get; set; }
        public List<FoundConstruct> BranchingStatements { get; set; } = new List<FoundConstruct>();
        public List<StatementStat> AllStatements { get; set; } = new List<StatementStat>();
    }

    internal class Parser
    {
        private string code = string.Empty;
        private string cleanCode = string.Empty;

        public string Code => code;

        public FileReadResult ReadCode(string filePath)
        {
            try
            {
                code = File.ReadAllText(filePath);
                cleanCode = Regex.Replace(code, @"//.*|/\*[\s\S]*?\*/", "");
                return new FileReadResult
                {
                    ErrorCode = FileReadErrorCode.Success,
                    Message = "Файл успешно прочитан."
                };
            }
            catch (Exception ex)
            {
                return new FileReadResult
                {
                    ErrorCode = FileReadErrorCode.UnknownError,
                    Message = ex.Message
                };
            }
        }

        public AnalysisResult Analyze()
        {
            var result = new AnalysisResult();
            string[] rawLines = cleanCode.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int cl = 0;
            int currentDepth = 0;
            int maxDepth = 0;

            // --- 1. РАСЧЕТ ВЕТВЛЕНИЙ И МЕТРИК ДЖИЛБА ---
            for (int i = 0; i < rawLines.Length; i++)
            {
                string line = rawLines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                bool isBranch = false;
                string opName = "";

                if (Regex.IsMatch(line, @"\bif\b"))
                {
                    cl++;
                    currentDepth++;
                    if (currentDepth > maxDepth) maxDepth = currentDepth;
                    isBranch = true;
                    opName = line.Contains("else if") ? "else if" : "if";
                }
                else if (Regex.IsMatch(line, @"\bfor\b"))
                {
                    cl++;
                    currentDepth++;
                    if (currentDepth > maxDepth) maxDepth = currentDepth;
                    isBranch = true;
                    opName = "for";
                }
                else if (Regex.IsMatch(line, @"\bcase\b"))
                {
                    cl++;
                    currentDepth++;
                    if (currentDepth > maxDepth) maxDepth = currentDepth;
                    isBranch = true;
                    opName = "case";
                }

                if (isBranch)
                {
                    result.BranchingStatements.Add(new FoundConstruct
                    {
                        Line = i + 1,
                        Operator = opName,
                        Text = line
                    });
                }

                if (line.Contains("}"))
                {
                    int closeCount = line.Count(c => c == '}');
                    currentDepth = Math.Max(0, currentDepth - closeCount);
                }
            }

            // --- 2. ПОДГОТОВКА ТЕКСТА ---
            string workText = cleanCode;

            // Исключаем объявленяи package и import
            workText = Regex.Replace(workText, @"\bpackage\s+[A-Za-z_]\w*", " ");
            workText = Regex.Replace(workText, @"\bimport\s*\((?:[^()]*|\([^()]*\))*\)", " ");
            workText = Regex.Replace(workText, @"\bimport\s+""[^""]*""", " ");

            // Исключаем объявленя функций и строковые литералы
            workText = Regex.Replace(workText, @"\bfunc\s+[A-Za-z_]\w*\s*\([^)]*\)(?:\s*[A-Za-z_]\w*)?\s*", " ");
            workText = Regex.Replace(workText, @"""[^""]*""|'[^']+'", " ");

            var ops = new Dictionary<string, int>();

            // --- 3. ИСПОЛНЯЕМЫЕ КЛЮЧЕВЫЕ СЛОВА (без switch и default) ---
            string[] executableKeywords = { "if", "else", "for", "return", "case", "continue", "break", "range", "go", "defer"};
            foreach (var kw in executableKeywords)
            {
                int count = Regex.Matches(workText, @"\b" + kw + @"\b").Count;
                if (count > 0) ops[kw] = count;
            }

            // --- 4. СОСТАВНЫЕ И СИМВОЛЬНЫЕ ОПЕРАТОРЫ ---
            var compoundOps = new (string sym, string pattern)[]
            {
                (":=", @":="),
                ("==", @"=="),
                ("!=", @"!="),
                ("<=", @"<="),
                (">=", @">="),
                ("++", @"\+\+"),
                ("--", @"--"),
                ("+=", @"\+="),
                ("-=", @"-="),
                ("*=", @"\*="),
                ("/=", @"/="),
                ("%=", @"%=")
            };

            foreach (var (sym, pattern) in compoundOps)
            {
                int c = Regex.Matches(workText, pattern).Count;
                if (c > 0)
                {
                    ops[sym] = c;
                    workText = Regex.Replace(workText, pattern, "  ");
                }
            }

            var singleOps = new (string sym, string pattern)[]
            {
                ("=", @"(?<![:!=<>])=(?![=])"),
                ("<", @"<(?![=])"),
                (">", @">(?![=])"),
                ("+", @"\+(?![+=])"),
                ("-", @"-(?![=-])"),
                ("*", @"\*(?![=])"),
                ("/", @"/(?![=])"),
                ("%", @"%(?![=])"),
                ("&&", @"&&"),
                ("||", @"\|\|"),
                ("!", @"!(?![=])")
            };

            foreach (var (sym, pattern) in singleOps)
            {
                int c = Regex.Matches(workText, pattern).Count;
                if (c > 0) ops[sym] = c;
            }

            // --- 5. ВЫЗОВЫ ФУНКЦИЙ КАК ОПЕРАТОРЫ ---
            var fnMatches = Regex.Matches(workText, @"\b(?<name>[A-Za-z_]\w*(?:\.[A-Za-z_]\w*)*)\s*\(");
            HashSet<string> controlKeywords = new HashSet<string> { "if", "for", "switch"};

            foreach (Match match in fnMatches)
            {
                string name = match.Groups["name"].Value;
                if (controlKeywords.Contains(name)) continue;

                string fnOperator = name + "()";
                ops[fnOperator] = ops.GetValueOrDefault(fnOperator, 0) + 1;
            }

            // --- 6. ИТОГИ ---
            int totalStatements = ops.Values.Sum();
            double relativeCl = totalStatements > 0 ? (double)cl / totalStatements : 0;

            result.CL = cl;
            result.cl = relativeCl;
            result.CLI = maxDepth;
            result.N = totalStatements;

            foreach (var kvp in ops.OrderByDescending(x => x.Value))
            {
                result.AllStatements.Add(new StatementStat
                {
                    Name = kvp.Key,
                    Count = kvp.Value
                });
            }

            return result;
        }
    }

    public enum FileReadErrorCode
    {
        Success,
        UnknownError
    }

    public struct FileReadResult
    {
        public FileReadErrorCode ErrorCode { get; set; }
        public string Message { get; set; }
    }
}