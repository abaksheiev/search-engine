using ScoreEngine.Contracts.Dtos;
using ScoreEngine.Contracts.Services;
using ScoreEngine.Start.Model;
using System.Globalization;
using System.Reflection;

namespace ScoreEngine.Busness
{
    public class OutputFileService : IOutputService<SitterVisitScores>
    {
        private bool _isUseHeader = true;
        private const int NumberRound = 2;
        private const string DecimalSeparator = ".";
        private char delimetr = ',';

        private NumberFormatInfo NumberFormat => new NumberFormatInfo() { NumberDecimalSeparator = DecimalSeparator };


        public void OutputResults(List<SitterVisitScores> data, string pathToFile)
        {
            using (StreamWriter outputFile = new(pathToFile))
            {
                WriteHeader(outputFile);

                WriteData(data.OrderByDescending(d => d.SitterName).ToList(), outputFile);
            }
        }

        private void WriteData(List<SitterVisitScores> data, StreamWriter outputFile)
        {
            foreach (var d in data)
            {
                var str = string.Join(delimetr,
                    [
                    d.SitterEmail,
                        d.SitterName,
                        Round(d.ProfileScore),
                        Round(d.RatingsScore),
                        Round(d.SearchScore),

                        ]
                );

                outputFile.WriteLine(str);
            }
        }

        private void WriteHeader(StreamWriter outputFile)
        {
            if (!_isUseHeader)
            {
                return;
            }

            var lineHeader = GetHeader<SitterVisitScores>();
            outputFile.WriteLine(
                string.Join(delimetr,
                [
                    lineHeader[nameof(SitterVisitScores.SitterEmail)],
                        lineHeader[nameof(SitterVisitScores.SitterName)],
                        lineHeader[nameof(SitterVisitScores.ProfileScore)],
                        lineHeader[nameof(SitterVisitScores.RatingsScore)],
                        lineHeader[nameof(SitterVisitScores.SearchScore)],
                ]));
        }

        /// <summary>
        /// Round number to specific format
        /// </summary>
        /// <param name="number">Number which is needed to be round</param>
        /// <returns>String value of rounded value</returns>
        private string Round(double number)
        {
           return Math.Round(number, NumberRound).ToString(NumberFormat);
        }


        /// <summary>
        /// Get Header Names from ColumnNameAttribute
        /// </summary>
        /// <typeparam name="T">Type of source</typeparam>
        /// <returns>Mapper of name prop and file names</returns>
        private Dictionary<string, string> GetHeader<T>() {
            Type type = typeof(T);
            MemberInfo[] MyMemberInfo = type.GetProperties();
            var headerAttrs = new Dictionary<string, string>();

            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                ColumnNameAttribute? att = Attribute.GetCustomAttribute(MyMemberInfo[i], typeof(ColumnNameAttribute)) as ColumnNameAttribute;
                if (att != null)
                {
                    headerAttrs.Add(MyMemberInfo[i].Name, att.ColumnName);
                }
            }

            return headerAttrs;
        }
    }
}
