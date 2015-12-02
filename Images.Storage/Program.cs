using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Images.Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ImagesContext())
            {
                /*
                Initialize ImagesContext DB object as db. Add the classifications model to the DB to 
                represent the database. Then save changes.
                */

                // Enter database upload logic in here

                foreach (var item in db.Classifications)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Annotator);
                    Console.WriteLine(item.Label);
                    Console.WriteLine(item.ImageBin);
                    Console.WriteLine(item.X);
                    Console.WriteLine(item.Y);
                    Console.WriteLine(item.W);
                    Console.WriteLine(item.H);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
