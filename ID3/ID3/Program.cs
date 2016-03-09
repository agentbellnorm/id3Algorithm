using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ID3
{
    class Program
    {
        static void Main(string[] args)
        {
            ID3Algorithm id3 = new ID3Algorithm();

            Node tree = id3.id3(Model.getData(), Model.predictiveProperties, "root");
            Console.ReadLine();
            
        }
    }
}
