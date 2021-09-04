using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace _8_Queen
{
    class Program
    {
        //定義棋盤大小
        public static int Q_Amount = 8;
        public static int solutionCnt = 0;
 
        static void Main(string[] args)
        {
            List<char[,]> results = new List<char[,]>();
            results = solveNQueens();
            Console.ReadLine();
        }

        public static List<char[,]> solveNQueens()
        {
            List<char[,]> results = new List<char[,]>();

            char[,] result = new char[Q_Amount, Q_Amount];
            for (int i = 0; i < Q_Amount; ++i)
            {
                for (int j = 0; j < Q_Amount; ++j)
                {
                    result[i,j] = '.';
                }
            }
            backtrack(results, result, 0);

            return results;
        }

        private static void backtrack(List<char[,]> results, char[,] result, int x)
        {
            for (int j = 0; j < Q_Amount; ++j)
            {
                if (j < Q_Amount)
                {
                    if (isValid(result, x, j))
                    {
                        result[x, j] = 'Q';
                        if (x == Q_Amount - 1)
                        {
                            solutionCnt++;
                            Console.WriteLine("//solution " + solutionCnt);
                            showResult(results, result);

                        }

                        else
                        {
                            backtrack(results, result, x + 1);
                        }

                    }
                    result[x, j] = '.';

                }
            }
        }

        private static bool isValid(char[,] result, int x, int y)
        {

            for (int i = 0; i < x; ++i)
            {
                if (result[i,y] == 'Q')
                {
                    return false;
                }
            }
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; --i, --j)
            {
                if (result[i,j] == 'Q')
                {
                    return false;
                }
            }
            for (int i = x - 1, j = y + 1; i >= 0 && j < Q_Amount; --i, ++j)
            {
                if (result[i,j] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }

        private static void showResult(List<char[,]> results, char[,] result)
        {
            int cnt = 0;
            foreach (char value in result)
            {
                cnt++;
                if ((cnt != 0) && (cnt % Q_Amount == 0))
                {
                    Console.WriteLine(value);
                }
                else {
                    Console.Write(value);
                }
            }
            results.Add(result);
        }

    }


}
