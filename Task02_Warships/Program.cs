using System;
using System.Linq;

namespace Task02_Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int destination = int.Parse(Console.ReadLine());

            string[] attackCommands = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string[,] field = new string[destination, destination];

            int shipsOne = 0;
            int shipsTwo = 0;
            int totalCountShipsDestroyed = 0;
            string winner = null;

            for (int i = 0; i <= destination - 1; i++)
            {
                string[] nextLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j <= destination - 1; j++)
                {
                    if(nextLine[j] == "<")
                    {
                        shipsOne++;
                    }
                    if (nextLine[j] == ">")
                    {
                        shipsTwo++;
                    }
                    field[i, j] = nextLine[j];
                }
            }

            int whoAttacking = -1;
            for (int i = 0; i <= attackCommands.Length - 1; i++)
            {
                if(i % 2 == 0)
                {
                    whoAttacking = 1;
                }
                else
                {
                    whoAttacking = 2;
                }

                string[] nextAttack = attackCommands[i].Split(' ');
                int row = int.Parse(nextAttack[0]);
                int column = int.Parse(nextAttack[1]);

                if(row < 0 || row > destination - 1 || column < 0 || column > destination - 1)
                {
                    continue;
                }

                string target = field[row, column];
                
                switch (target)
                {
                    case "<":
                        if(whoAttacking == 1)
                        {
                            totalCountShipsDestroyed++;
                            shipsTwo--;
                        }
                        else
                        {
                            totalCountShipsDestroyed++;
                            shipsOne--;
                        }
                        break;

                    case ">":
                        if (whoAttacking == 1)
                        {
                            totalCountShipsDestroyed++;
                            shipsTwo--;
                        }
                        else
                        {
                            totalCountShipsDestroyed++;
                            shipsOne--;
                        }
                        break;

                    case "#":
                        for (int j = row - 1; j <= row + 1; j++)
                        {
                            for (int x = column - 1; x <= column + 1; x++)
                            {
                                if (j < 0 || j > destination - 1 || x < 0 || x > destination - 1)
                                {
                                    continue;    
                                }

                                if(field[j, x] == "<")
                                {
                                    totalCountShipsDestroyed++;
                                    shipsOne--;
                                }
                                if (field[j, x] == ">")
                                {
                                    totalCountShipsDestroyed++;
                                    shipsTwo--;
                                }

                                field[j, x] = "X";
                            }
                        }
                        break;

                    default:
                        break;
                }

                if(shipsOne == 0)
                {
                    winner = "Player Two";
                    break;
                }

                if (shipsTwo == 0)
                {
                    winner = "Player One";
                    break;
                }
            }

            if(winner == null)
            {
                Console.WriteLine($"It's a draw! Player One has {shipsOne} ship left. Player Two has {shipsTwo} ship left.");
            }
            else
            {
                Console.WriteLine($"{winner} has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle.");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
