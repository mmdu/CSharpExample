using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    class Program
    {
        //----------------------------interface converter--------------------------
        interface IIfc1{void PrintOut(string s);}
        interface IIfc2{void PrintOut(string t);}
        class MyClass : IIfc1, IIfc2
        {
            void IIfc1.PrintOut(string s)
            {
                Console.WriteLine("called through :{0}", s);
            }
            void IIfc2.PrintOut(string t)
            {
                Console.WriteLine("called through :{0}", t);
            }
            public void Method1()
            {
                ((IIfc1)this).PrintOut("sssss");
            }

        }
        //--------------------------------------- Interface animal example 
        interface IliveBirth
        {
            void BabyCalled();
        }

        class  Animial 
        {
            
        }

        class cat : Animial, IliveBirth
        {
            void IliveBirth.BabyCalled()
            {
               Console.WriteLine(" Kitten called");
            }
        }

        class  dog: Animial,IliveBirth
        {
            void IliveBirth.BabyCalled()
            {
                Console.WriteLine("puppy called");
            }

        }

        class bird :Animial 
        {
            
        }
     
        static void Main(string[] args)
        {
            Animial[]  animialArray=new Animial[3];
            animialArray[0]=new cat();
            animialArray[1]=new dog();
            animialArray[2]=new bird();
            foreach (Animial animial in animialArray)
            {
                IliveBirth b= animial as IliveBirth;
                if (b != null)
                {
                    b.BabyCalled();
                }
                
            }
        }
    }
}
