using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ID3
{
    class Model : IModel
    {
        public string id { get; set; }
        public string age { get; set; }
        public string income { get; set; }
        public string student { get; set; }
        public string credit_rating { get; set; }
        public string buys_computer { get; set; }

        public static Func<Model, bool> Success = (x => x.buys_computer == "yes");
        public static List<string> predictiveProperties = new List<string>() { "age", "income", "student", "credit_rating" };
        public static string Positive = "yes";
        public static string Negative = "no";

        public Model(string _id, string _age, string _income, string _student, string _credit, string _buys)
        {
            id = _id; age = _age; income = _income; student = _student; credit_rating = _credit; buys_computer = _buys;
        }

        public string valueByField(string field)
        {
            switch (field)
            {
                case "id":
                    return id;
                case "age":
                    return age;
                case "income":
                    return income;
                case "student":
                    return student;
                case "credit_rating":
                    return credit_rating;
                case "buys_computer":
                    return buys_computer;
                default:
                    return "Error";
            }
        }

        private static List<Model> InitData()
        {
            List<Model> rowList = new List<Model>();
            var rows = (
                from line in File.ReadAllLines("assignment.csv")
                where line.Length > 0
                let Items = line.Split(',')
                select Items).ToList();
            for (int i = 1; i < rows.Count; i++)
            {
                rowList.Add(new Model(rows[i][0], rows[i][1], rows[i][2], rows[i][3], rows[i][4], rows[i][5]));
            }
            return rowList;
        }

        public static List<Model> getData()
        {
            return InitData();
        }
    }
}
