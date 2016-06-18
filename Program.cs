using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Puzzle2
{
    class Program
    {
        public struct tilesSet
        {
            public int profit { get; set; }
            public int firstT { get; set; }
            public int lastT { get; set; }
            public tilesSet(int _profit, int _firstT, int _lastT)
            {
                profit = _profit;
                firstT = _firstT;
                lastT = _lastT;
            }
        }
        public static tilesSet MaxSubProfit(int[] A)
        {
            int profit = 0, maxProfit = 0, check = 0, firstTile = 0, lastTile = 0, firstT = 0, lastT = 0, minLength = A.Length;

            for (int j = 0; j < A.Length; j++)
            {
                profit = profit + A[j];

                if (profit > 0)
                {
                    check++;
                    if (check == 1)
                    {
                        firstT = j + 1;
                        lastT = j + 1;
                    }
                    if (check > 1)
                        lastT = j + 1;
                    if (profit == maxProfit)
                    {
                        if (lastT - firstT + 1 < minLength)
                        {
                            firstTile = firstT;
                            lastTile = lastT;
                            minLength = lastTile - firstTile + 1;
                        }
                    }
                    if (profit > maxProfit)
                    {
                        firstTile = firstT;
                        lastTile = lastT;
                        minLength = lastTile - firstTile + 1;

                        maxProfit = profit;
                    }
                }
                else if (profit < 0)
                {
                    profit = 0;
                    check = 0;
                }
            }
            return new tilesSet(maxProfit, firstTile, lastTile);
        }
        static void Main(string[] args)
        {
            int tilesNo = 0;
            //assuming input is correct, no checks performed
            tilesNo = Int32.Parse(Console.ReadLine());

            var profitList = new int[tilesNo];
            for (int i = 0; i < tilesNo; i++)
            {
                profitList[i] = Int32.Parse(Console.ReadLine());
            }
            tilesSet ts = MaxSubProfit(profitList);
            //Console.WriteLine("total profit: ");
            Console.WriteLine(ts.profit + " " + ts.firstT + " " + ts.lastT);
            Console.ReadKey();
        }
    }
}
