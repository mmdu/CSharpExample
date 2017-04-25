using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private class IndexerRecord

        {
            private readonly string[] data = new string[6];

            private readonly string[] keys = {"Author", "Publisher", "Title", "Subject", "ISBN", "Comments"};

            public string this[int idx]
            {
                set
                {
                     if (idx >= 0 && idx < data.Length)

                        data[idx] = value;
                }

                get

                {
                    if (idx >= 0 && idx < data.Length)

                        return data[idx];

                    return null;
                }
            }

            public string this[string key]

            {
                set

                {
                 //   var idx = FindKey(key);

                 //    this[idx] = value;
                }

                get { return this[FindKey(key)]; }
            }

            private int FindKey(string key)

            {
                for (var i = 0; i < keys.Length; i++)

                    if (keys[i] == key) return i;

                return -1;
            }
        }

        private static void Main(string[] args)
        {
            var record = new IndexerRecord();

            record[0] = "Wang xiaoping";

            record[1] = "Springer";

            record[2] = "Sea and old man";

            Console.WriteLine(record["Title"]);

            Console.WriteLine(record["Author"]);

            Console.WriteLine(record["Publisher"]);
            Console.WriteLine(record[0]);
            Console.WriteLine(record[2]);
        }
    }
}
