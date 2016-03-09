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
        public string day { get; set;}
        public string outlook { get; set; }
        public string temperature { get; set; }
        public string humidity { get; set; }
        public string wind { get; set; }
        public string play { get; set; }

        public static Func<Model, bool> Success = (x => x.play == "Yes");
        public static List<string> predictiveProperties = new List<string>() { "outlook", "temperature", "humidity", "wind" };
        public static string Positive = "Yes";
        public static string Negative = "No";

        public Model(string _day, string _outlook, string _temperature, string _humidity, string _wind, string _play)
        {
            day = _day;
            outlook = _outlook;
            temperature = _temperature;
            humidity = _humidity;
            wind = _wind;
            play = _play;
        }

        public string valueByField(string field)
        {
            switch (field)
            {
                case "day":
                    return day;
                case "outlook":
                    return outlook;
                case "temperature":
                    return temperature;
                case "humidity":
                    return humidity;
                case "wind":
                    return wind;
                case "play":
                    return play;
                default:
                    return "Error";
            }
        }

        private static List<Model> InitData()
        {
            List<Model> rowList = new List<Model>();
            var rows = (
                from line in File.ReadAllLines("play_ball.csv")
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
