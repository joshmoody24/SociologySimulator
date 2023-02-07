using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociologySimulator.Utility
{
    public class Input
    {
        // temp, shouldn't be used long term
        public static T ChooseFromList<T>(IEnumerable<T> collection, string prompt)
        {
            int id = 0;
            int chosen = -1;
            while (chosen < 0 || chosen >= id)
            {
                id = 0;
                chosen = -1;
                Console.WriteLine(prompt);
                foreach (T element in collection)
                {
                    Console.WriteLine(id + 1 + ". " + element.ToString());
                    id++;
                }
                Console.Write("Enter a number: ");
                if (!int.TryParse(Console.ReadLine(), out chosen)) continue;
                chosen -= 1;
            }
            Console.WriteLine(collection.ElementAt<T>(chosen).ToString() + " selected");
            return collection.ElementAt<T>(chosen);
        }
    }
}
