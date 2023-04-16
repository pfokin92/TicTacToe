using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class TicTacToe
    {
        public string[,] fieldGame { get; private set; }
        public string[,] fieldExample = { { "0", "1", "2" }, { "3", "4", "5" }, { "6", "7", "8" } };
        private int[,] recodeList = { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 2, 0 }, { 2, 1 }, { 2, 2 } };
        private int[,] winComb = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
        public TicTacToe()
        {
            fieldGame = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
        }

        public void showField(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write($"{field[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public bool checkMove(int move)
        {
            return fieldGame[recodeList[move, 0], recodeList[move, 1]] == " " ? true : false;
        }

        public bool checkInsertNumber(int insertNum)
        {
            return (insertNum >= 0 && insertNum < 9) ? true : false;
        }

        public bool checkWin(string gamer)
        {
            bool win = false;
            for (int i = 0; i < winComb.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < winComb.GetLength(1); j++)
                {
                    if (gamer == fieldGame[recodeList[winComb[i, j], 0], recodeList[winComb[i, j], 1]])
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    win = true;
                }
            }
            return win;
        }

        public void addMove(int move, string gamer)
        {
            fieldGame[recodeList[move, 0], recodeList[move, 1]] = gamer;
        }

        public void StartGame()
        {
            Console.WriteLine("Enter number from 0 to 8.");
            showField(fieldExample);
            for (int i = 0; i < 9; i++)
            {
                string gamer = i % 2 == 0 ? "X" : "O";
                int insert = 0;
                bool check = false;
                do
                {
                    try
                    {
                        insert = int.Parse(Console.ReadLine()); 
                        if (!checkInsertNumber(insert))
                        {
                            Console.WriteLine("Enter number from 0 to 8. Return move");
                            check = true;
                        }
                        else if (!checkMove(insert))
                        {
                            Console.WriteLine("Cell busy. Return move");
                            check = true;
                        }
                        else
                        {
                            addMove(insert, gamer);
                            check = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Enter number from 0 to 8. Return move");
                        check = true;
                    }
                    

                } while (check);
                if (checkWin(gamer))
                {
                    showField(fieldGame);
                    Console.WriteLine($"Gamer {gamer} win");
                    break;
                } else if (i == 8)
                {
                    Console.WriteLine("Draw");
                }
                showField(fieldGame);
            }
        }
    }
}
