using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulačka_kvadratických_rovnic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int x1, x2;
                Console.Write("Zadej a: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Zadej b: ");
                int b = int.Parse(Console.ReadLine());

                Console.Write("Zadej c: ");
                int c = int.Parse(Console.ReadLine());

                int D = b * b - 4 * a * c;

                if (D > 0)
                {
                    x1 = (-b + (int)Math.Sqrt(D)) / (2 * a);
                    x2 = (-b - (int)Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine("Má dvě řešení: x1 = {0} a x2 = {1}", x1, x2);
                }
                else if (D == 0)
                {
                    x1 = -b / (2 * a);
                    Console.WriteLine("Má jedno řešení: x1 = {0} ", x1);
                }
                else // D<0
                {
                    Console.WriteLine("Nemá řešení v oboru R");
                }

                Console.ReadLine();
            }
            while(true);
        }

        }
    }

