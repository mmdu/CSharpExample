using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace CastingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // upcast , text and shape referenced to same object

            Text text = new Text();
            Shape shape = text;



            //   StreamReader reader = new StreamReader(new MemoryStream()); 

            var list = new ArrayList();
            //  not type safety, to object , implicit converted base object
            list.Add(1);
            list.Add("mosh");
            list.Add(new Text());
            // using generic class  

            var betterList = new List<Shape>();

            // downcasting , compile time : shape, runtime； Text

            Shape shape2 = new Text();
            // F9. F10,  checkout the value  is : Text , so shape is limited view, need downcast, convert shape to text 
            Text text2 = (Text)shape;
            
        }
    }
}
