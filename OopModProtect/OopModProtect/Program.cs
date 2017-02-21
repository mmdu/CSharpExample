using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopModProtect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input tiger object's type :");
            string input = Console.ReadLine();
            string nm, tp;
            if (input != "chinatiger")
            {
                Tiger tg = new Tiger(input);
                nm = tg.name;
                tp = tg.type;
            }
            else
            {
                ChinaTiger tg = new ChinaTiger();
                nm = tg.name;
                tp = tg.type;
            }
            Console.WriteLine("\n one {0} is established succesfully ",nm);
            Console.WriteLine("\n this  {0} is type {1} ", nm, tp);


        }

        class Tiger
        {
            protected string _name = "tiger";
            protected string _type;
            internal Tiger() { }
            internal Tiger(string tp) { this._type = tp; }
            internal string name
            {
                get { return this._name; }
            }
            internal string type
            {
                get { return this._type; }
                set { this._type = value; }
            }
        }
        class ChinaTiger:Tiger
        {
            internal ChinaTiger()
            {
                this._type = "chinatiger";
            }
        }
    
    }
}
