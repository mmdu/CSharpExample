using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class Program
    {
        interface IIfc1{void PrintOut(string s);}
        interface IIfc2{void PrintOut(string t);}

        class  MyClass:IIfc1,IIfc2
        {
            Void IIfc1.PrintOut(string s) {
                Console.WriteLine("called through :{0}",s);
            }
            Void IIfc2.PrintOut(string t)
            {
                Console.WriteLine("called through :{0}", t);
            }
            public void Method1()
            {
                
            }

             
        }
        static void Main(string[] args)
        {
        }
    }
}
