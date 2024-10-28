using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_paskaita_Foreach_ir_dvimaciai_masyvai
{
    public static class Methods
    {
        public static double SumAverage(int[] numbers)
        {
            double sum = 0;

            foreach (int num in numbers)
            {
                sum += num;
            }

            return sum / numbers.Length;
        }


        public static int SetArrayLength(int[] arr)
        {
            int counter = 0;

            foreach (int n in arr)
            {
                if (n > 0)
                {
                    counter++;
                }
                else
                {
                    continue;
                }
            }
            return counter;
        }


        public static int[] GetPositiveNumbers(int[] numbers)
        {
            int[] positiveNums = new int[SetArrayLength(numbers)];
            int index = 0;

            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    positiveNums.SetValue(num, index);
                    index++;
                }
                else
                {
                    continue;
                }
            }
            return positiveNums;
        }


        public static double CalculateGPMpayment(double[] doubles)
        {
            double gpmRate = 0.15;
            double gpmSum = 0;

            foreach (double i in doubles)
            {
                gpmSum += i * gpmRate;
            }

            return gpmSum;
        }
    }
}
