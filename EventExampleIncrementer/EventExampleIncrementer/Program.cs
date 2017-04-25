using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExampleIncrementer
{
    class Program
    {
        class IncrementerEventArgs : EventArgs                             // ****************publisher******************, sender 
        {
            public event EventHandler CountedADozen;      // delegate ,publish an Event   CounterADozen   

            public void DoCount()                          //mothod  Docount to invoke event CounterADozen
            {
                for (int i = 1; i < 100;i++)
                {
                    if (i % 12 == 0 && CountedADozen !=null)   // check if the event null 
                        CountedADozen(this, null);             // Invoke /fire/raise  Event  with parameters  , DozensCount fired when i= 12 
                }

            }
        }

        class  Dozons                                       //************ Subscriber****************  receiver 
        {
            public int DozensCount { get; private set; }

            public Dozons(Incrementer incrementer)
            {
                DozensCount = 0;
                incrementer.CountedADozen += IncrementDozenCount;   // Dozons subscribed a methode  to event 
            }

            void IncrementDozenCount(object source, EventArgs e)
            {
                DozensCount++;    //  claim Event program 
            }
        }
        static void Main(string[] args)
        {
            Incrementer incrementer = new Incrementer();
            
            Dozons dozensCounter = new Dozons(incrementer);

            incrementer.DoCount();
            Console.WriteLine("number of dozens = {0}", dozensCounter.DozensCount);
        }
    }
}
