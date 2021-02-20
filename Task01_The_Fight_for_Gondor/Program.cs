using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] platesData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>();

            for (int i = 0; i <= platesData.Length - 1; i++)
            {
                plates.Enqueue(platesData[i]);
            }

            
            Stack<int> orks = new Stack<int>();
            int curentOrk = 0;

            int curentPlate = 0;

            for (int i = 1; i <= waves; i++)
            {
                
                int[] orksData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                

                for (int j = 0; j <= orksData.Length - 1; j++)
                {
                    orks.Push(orksData[j]);
                }


                if (i % 3 == 0)
                {
                    int addPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(addPlate);

                }

                // ************ FIGHT ****************************
                


                while (orks.Count != 0)
                {
                    if (plates.Count == 0)
                    {
                        break;
                    }

                    if (curentOrk == 0)
                    {
                        curentOrk = orks.Pop();
                    } 
                    
                    if(curentPlate == 0)
                    {
                        curentPlate = plates.Peek();
                    }
                        

                    if (curentOrk == curentPlate)
                    {
                        plates.Dequeue();
                        curentOrk = 0;
                        curentPlate = 0;
                    }

                    else if (curentPlate > curentOrk)
                    {
                        curentPlate -= curentOrk;
                        curentOrk = 0;
                    }

                    else // curentOrk > curentPlate
                    {
                        curentOrk -= curentPlate;
                        curentPlate = 0;
                        plates.Dequeue();
                        orks.Push(curentOrk);
                    }
                }


                // *********************************************

                if (plates.Count == 0)
                {
                    break;
                }

            }

            if(plates.Count > 0) // ********************* WIN Plates ************************
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.Write($"Plates left: ");
                while (plates.Count > 0)
                {
                    Console.Write(plates.Dequeue());
                    if(plates.Count > 0)
                    {
                        Console.Write(", ");
                    }
                }
            }
            else // ********************* WIN ORKS *************************
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.Write("Orcs left: ");
                while (orks.Count > 0)
                {
                    Console.Write(orks.Pop());
                    if (orks.Count > 0)
                    {
                        Console.Write(", ");
                    }
                }

            }

            //Console.WriteLine(winner);
        }
    }
}
