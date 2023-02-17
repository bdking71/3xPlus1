using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3xPlus1 {
    internal class Program {
        static string LogFile = "c:\\temp\\hailstone.txt"; 
        static Int64 max = 9999999;
        static void Main(string[] args)
        {
            int steps;
            Int64 cnt = 1;
            //for (Int64 cnt = 1; cnt <= max;cnt++) {
            do { 
               Int64 x = cnt;
               string nbrs = "";
               steps = 0;   
               do { 
                x = getHailstoneNbr(x);
                if (x == 1) {
                    nbrs = nbrs + x.ToString();
                } else {
                    nbrs = nbrs + x.ToString() + ",";
                }
                steps++;
               } while (x != 1);
                WriteLog(cnt, steps, nbrs);
                cnt++;
            } while (cnt < max);
            Console.ReadLine();
        }

        static Int64 getHailstoneNbr(Int64 n) {
            Int64 hailstoneNbrs = n;
            if (isOdd(hailstoneNbrs))
            {
                hailstoneNbrs = (hailstoneNbrs * 3) + 1;
            }
            else
            {
                hailstoneNbrs = (hailstoneNbrs / 2);
            }
            return hailstoneNbrs;
        } 
        static bool isOdd(Int64 n) {
            return n % 2 != 0;
        }

        private static void WriteLog(Int64 cnt, Int64 step, string nbrs) {
            string line = $"{cnt},{step},[{nbrs}]{Environment.NewLine}";
            Console.Write(line);
            File.AppendAllText(LogFile, $"{line}");
        }

    }
}
