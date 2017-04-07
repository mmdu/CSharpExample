using System;
using System.Threading;

namespace DelegateExampleBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Action);
            Console.WriteLine(t.IsClass);

            ProductFactory productFactory=new ProductFactory();
            ;
            WrapFactory wrapFactory = new WrapFactory();

            Logger logger = new Logger();
            Action<Product>log =new Action<Product>(logger.Log);


            Func<Product> func1 = productFactory.MakePizza;
            Func<Product> func2 =new Func<Product>(productFactory.MakeToyCar);

            // pattern method, func1 delegate methode can bring different procduct ( you can chang product by design productFactory, adding more product)
             // callback method,hollywood method, if I choose, i will call you. 
            Box box1 = wrapFactory.WrapProduct(func1,log);
            Box box2 = wrapFactory.WrapProduct(func2,log);
            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);


            //----------------------------------------------------------------------------------
            // sample for multi delegate

            Student stu1 = new Student() {ID = 1, PenColor = ConsoleColor.Blue};
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Yellow };
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
            Student stu4 = new Student() { ID = 4, PenColor = ConsoleColor.Green };

            Action action1=new Action(stu1.DoHomework);
            Action action2 = new Action(stu2.DoHomework);
            Action action3 = new Action(stu3.DoHomework);
            Action action4 = new Action(stu4.DoHomework);

            action1 += action2;
            action1 += action3;
            action1 += action4;
            action1();


        }
        // no return value, action<>
        class  Logger
        {
            public void Log(Product product)
            {
                Console.WriteLine("Product '{0} created at {1}, Price is {2}", product.Name, DateTime.UtcNow,product.Price);
            }
        }

        class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        class Box
        {
            public Product  Product  { get; set; }
        }

        class WrapFactory
        {
            public Box WrapProduct(Func<Product> getProduct,Action<Product> logCallback)
            {
                Box box =new Box();
                Product product = getProduct.Invoke();
                if (product.Price > 50)
                {
                    logCallback(product);
                }

                box.Product = product;
                return box;
            }
        }

        class  ProductFactory
        {
            public Product MakePizza()
            {
                Product product=new Product();
                product.Name = "pizza";
                product.Price = 12;
                return product;
            }

            public Product MakeToyCar()
            {
                Product product=new Product();
                product.Name = "toycar";
                product.Price = 80;
                return product;
            }
        }


        // multidelegate

        class  Student
        {
            public int ID  { get; set; }
            public ConsoleColor PenColor { get; set; }

            public void DoHomework()
            {
                for (int i = 0; i <5; i++)
                {
                    Console.ForegroundColor = this.PenColor;
                    Console.WriteLine("Student {0} doing homework {1} hours", this.ID,i);
                     Thread.Sleep(1000);
                }
            }
        }
    }
}
