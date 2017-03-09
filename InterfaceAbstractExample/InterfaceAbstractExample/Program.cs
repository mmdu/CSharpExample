using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer a = new PCA();
            Console.WriteLine( " a is a computer type A , cup is {0},  viedocar is {1}", a.getcpu(),a.videocard);
            a = new PCB();
            Console.WriteLine(" a is a computer type B, cup is {0},  viedocar is {1}", a.getcpu(), a.videocard);
            //a.videocard = "sfsdf"; wrong, for computer videocard  not set 

            PCB b = new PCB();
            b.videocard = "Nvida 3400";
            // Correct , 
            //a.videocard = "sfsdf"; wrong, for computer videocard  not set 
            Console.WriteLine(" b is a computer type B, cup is {0},  viedocar is {1}", b.getcpu(), b.videocard);


        }

        interface Computer
        {
            string getcpu();
            string videocard { get; }
        }

        class PCA :Computer
        {
            private string _vc = "NGD1000";
            public string getcpu() { return "Intel-Core"; }


            public string videocard { get { return _vc; }  set { _vc = value; } }
        }

        class PCB:Computer
        {
            private string _vc = "AMD 3000";
            public string getcpu() { return "AMD X2"; }

            public string videocard { get { return _vc; } set { _vc = value; } }
        }
    }
}
