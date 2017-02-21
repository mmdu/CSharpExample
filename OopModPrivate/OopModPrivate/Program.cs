using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopModPrivate
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("husky");
            Console.WriteLine("a dog object is established");
            Console.WriteLine("this dog 's type is {0} and dog's name is{1} ",dog.type,dog.name);

            //Tiger tiger = new Tiger("southChinaTiger"); wrong for it is private constructor 
            //Tiger.ZooTiger tz = new Tiger.ZooTiger();      wrong private class 

            Tiger tiger = new Tiger(true);
            Console.WriteLine("a tiger object is established");
            Console.WriteLine("this tiger"+tiger.name+"'s type is southChianTiger  ? :"+tiger.isChianTiger);
        }

        class Dog
        {
            internal string name = " My little sun";
            private string _type;
            internal Dog(string tp)
            {
                this._type = tp;
            }
            internal string type
            {
                get { return this._type; } //******  get access to the private menber_type 's value***************;
            }       
        }

        class Tiger
        {
            internal string name = "Tiger";      private string _type;       private bool _isChinaTiger;
            private Tiger(string tp)
            {
                this._type = tp;
            }    
            internal Tiger(bool chinatiger)
            {
                this._isChinaTiger = chinatiger;
            }
            internal string isChianTiger
            {   
                get {

                    // Inside GET, you can reference class  ,object,
                    ZooTiger zt = new ZooTiger();

                    return this._isChinaTiger + "(" + zt.name + ")";
                } 
            } 

            private class ZooTiger
            {

                internal string name;
                internal ZooTiger()
                {
                    this.name = "Zoo's tiger";
                }
            }
        }
    }
}
