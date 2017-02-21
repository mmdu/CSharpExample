using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input tiger object's weight and lenght ,seperated by ','");
            string input = Console.ReadLine();
            int pos = input.IndexOf(",");
            string w = input.Substring(0, pos);
            string l = input.Substring(pos + 1);
            Tiger chinaTiger = new Tiger(w, l);
            Console.WriteLine("Tiger object is established  ");
            Console.WriteLine(  "tiger 's weight is {0},lenght is{1}",chinaTiger.weight,chinaTiger.lenght );
            Console.WriteLine(  "tiger's character is "+Tiger.msg);
            Console.WriteLine(" Is tiger like cat : "+Tiger.cat() );
        }
        class Mammal
        {
            protected static bool viviparous = true;
            protected static bool feeding = true;
        }

        class Felid: Mammal
        {
            protected static bool catlike = true;
            protected static bool sensitivity = true;
        }
        class Tiger:Felid
        {
            internal static string msg = "vigours, swimming, beautiful, tree,";
            internal static string habitat = "forest";
            internal string weight;
            internal string lenght;
            internal Tiger (string w, string l)
            {
                this.weight = w;
                this.lenght = l;
            }
            internal static bool cat()
            {
                return Tiger.catlike;
            }
         }

    }
}
