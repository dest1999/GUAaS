using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public class StrangeSumClass
    {
        static void Main(string[] args)
        {

        }
        
        
        public int StrangeSum(int[] inputArray) // n - кол-во эл-тов массива
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                    }
                }
            }

            return sum; // сложность метода O(n^3)
        }
    }


}
