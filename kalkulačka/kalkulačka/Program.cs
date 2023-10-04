using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulačka
{
    internal class Program
    {
        static void Main(string[] args)
        {

      
                do
                {
                    Console.Write("Zadej první číslo");
                    int a = int.Parse(Console.ReadLine());

                    Console.Write("Zadej druhé číslo");
                    int b = int.Parse(Console.ReadLine());

                    Console.Write("Zadej operaci");
                    string operace = Console.ReadLine();

                    if (operace == "+")
                    {
                        int V = a + b;
                        Console.WriteLine(V);
                    }
                    else
                    {
                        if (operace == "-")
                        {
                            int V = a - b;
                            Console.WriteLine(V);
                        }
                        else
                        {
                            if (operace == "*")
                            {
                                int V = a * b;
                                Console.WriteLine(V);
                            }
                            else
                            {
                                if (operace == "/")
                                {
                                    int V = a / b;
                                    Console.WriteLine(V);
                                }
                                else
                                {
                                    Console.WriteLine("špatná operace nebo číslo");
                                }
                            }
                        }
                    }
                    Console.WriteLine("chceš další příklad?(ano/ne)");
                    string odpoved = Console.ReadLine();

                    if (odpoved == "ano")
                    {
                    }
                    else if (odpoved == "ne")
                    {
                        break;
                    }
                }
                while (true);
        }
        }
    }

    
