using System;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateExampleBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Action);
            Console.WriteLine(t.IsClass);

            // Func Action Example 
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


            //  interface example 
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toycarFactory =new ToyCarFactory();
            WrapFactoryInterface wrapFactoryInterface = new WrapFactoryInterface();
            Box box3 = wrapFactoryInterface.WrapProduct(pizzaFactory);
            Box box4 = wrapFactoryInterface.WrapProduct(toycarFactory);
            Console.WriteLine(box3.Product.Name);
            Console.WriteLine(box4.Product.Name);

            //----------------------------------------------------------------------------------
            // sample for multicast delegate

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

            // throw exception
            //action1.BeginInvoke(null, null);
            //action2.BeginInvoke(null, null);
            //action3.BeginInvoke(null, null);
            //action4.BeginInvoke(null, null);

            Thread thread1 = new Thread(new ThreadStart(stu1.DoHomework));
            Thread thread2 = new Thread(new ThreadStart(stu2.DoHomework));
            Thread thread3 = new Thread(new ThreadStart(stu3.DoHomework));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.WriteLine("*******************************");

            Task task1 = new Task(new Action(stu2.DoHomework));
            Task task2 = new Task(new Action(stu3.DoHomework));
            Task task3 = new Task(new Action(stu4.DoHomework));
            Console.WriteLine("*******************************");
            task1.Start();
            task2.Start();
            task3.Start();


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
        //============= using inteface===================
        interface IProductFactory
        {
            Product Make();
        }

        class PizzaFactory : IProductFactory
        {
            public Product Make()
            {
                Product product = new Product();
                product.Name = "pizza";
                product.Price = 12;
                return product;

            }
        }

        class ToyCarFactory :IProductFactory
        {
            public Product Make()
            {
                Product product = new Product();
                product.Name = "toycar";
                product.Price = 80;
                return product;

            }
        }

        class WrapFactoryInterface
        {
            public Box WrapProduct(IProductFactory productFactory)
            {
                Box box = new Box();
                Product product = productFactory.Make();
               
                box.Product = product;
                return box;
            }
        }
    }
}
