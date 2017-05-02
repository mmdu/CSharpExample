using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIComparableArraySort
{

    class MyClass : IComparable
    {
        public int TheValue;
        public string TheString;
       
        //public int CompareTo(object obj)
        //{
        //    MyClass mc = (MyClass)obj;
        //    if (this.TheValue < mc.TheValue) return -1;
        //    if (this.TheValue > mc.TheValue)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}

        public int CompareTo(object obj)
        {
            MyClass mc = (MyClass) obj;
            if (this.TheString.Length < mc.TheString.Length) return -1;
            if (this.TheString.Length >mc.TheString.Length)
            {
                return 1;
            }
            return 0;
        }
    }
    class Program
    {
        
 
            static void PrintOut(string s, MyClass[] mc)
            {
                Console.WriteLine(s);
                foreach (var m in mc)
                {
                    Console.WriteLine("{0}", m.TheString);
                }
                Console.WriteLine("");
            }

            static void Main(string[] args)
            {
                var myInt = new[] { 20, 4, 16, 9, 2 };
                var myString = new[] {"aa", "ccccc", "dddddddd", "eeeeeeeeeeee", "bbb"};
                MyClass[] mcArr = new MyClass[5];
                for (int i = 0; i < 5; i++)
                {
                    mcArr[i] = new MyClass();
                //     mcArr[i].TheValue = myInt[i];
                    mcArr[i].TheString = myString[i];
                }
                PrintOut("Inital Order : ", mcArr);
                
            Array.Sort(mcArr);
                PrintOut("Sorted order : ", mcArr);
            Array.Sort(myInt);
                foreach (var e in myInt)
                {
                    Console.WriteLine(e);
                }
        }
    }
}
