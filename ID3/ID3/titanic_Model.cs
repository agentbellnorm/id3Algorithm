using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ID3
{
    class Model : IModel
    {
        public string passengerid { get; set; }
        public string survived { get; set; }
        public string pclass { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string sibsp { get; set; }
        public string parch { get; set; }
        public string ticket { get; set; }
        public string fare { get; set; }
        public string cabin { get; set; }
        public string embarked { get; set; }

        public static Func<Model, bool> Success = (x => x.survived == "1");
        public static List<string> predictiveProperties = new List<string>() { "pclass", "sex", "sibsp", "parch", "embarked" };
        public static string Positive = "1";
        public static string Negative = "0";

        public Model(string pid, string surv, string clas, string n, string s, string a, string sib, string pa, string ti, string f, string cab, string emb)
        {
            passengerid = pid; survived = surv; pclass = clas; name = n; sex = s; age = a; sibsp = sib; parch = pa; ticket = ti; fare = f; cabin = cab; embarked = emb;
        }

        public string valueByField(string field)
        {
            switch (field)
            {
                case "survived":
                    return survived;
                case "pclass":
                    return pclass;
                case "name":
                    return name;
                case "sex":
                    return sex;
                case "age":
                    return age;
                case "sibsp":
                    return sibsp;
                case "parch":
                    return parch;
                case "ticket":
                    return ticket;
                case "fare":
                    return fare;
                case "cabin":
                    return cabin;
                case "embarked":
                    return embarked;
                default:
                    return "Error";
            }
        }

        private static List<Model> InitData()
        {
            List<Model> rowList = new List<Model>();
            var rows = (
                from line in File.ReadAllLines("titanic.csv")
                where line.Length > 0
                let Items = line.Split(';')
                select Items).ToList();
            for (int i = 1; i < rows.Count; i++)
            {
                rowList.Add(new Model(rows[i][0], rows[i][1], rows[i][2], rows[i][3], rows[i][4], rows[i][5], rows[i][6], rows[i][7], rows[i][8], rows[i][9], rows[i][10], rows[i][11]));
            }
            return rowList;
        }

        public static List<Model> getData()
        {
            return InitData();
        }

        public IEnumerable<string> SplitCSV(string input)
        {
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

            foreach (Match match in csvSplit.Matches(input))
            {
                yield return match.Value.TrimStart(',');
            }
        }


    }
}
