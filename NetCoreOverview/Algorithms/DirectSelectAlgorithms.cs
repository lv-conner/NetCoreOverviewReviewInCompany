using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsConsole
{
    static class Algorithms
    {
        /// <summary>
        /// 直接选择排序
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<int> DirectSelectAlgorithms(bool desc, params int[] arr)
        {
            for (int i = 0; i < arr.Length -1; i++)
            {
                //每一轮排序完成后，第i项成为剩下的最大/最小
                for (int j = i + 1; j < arr.Length; j++)
                {
                    //使用异或运算符对>/<进行选择
                    if (arr[i] < arr[j] ^ desc)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr.ToList();
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<int> BubleAlgorithms(bool desc, params int[] arr)
        {
            //arr.length - 1在于第一次向上冒泡时会交换最后一个值；
            for (int i = 0; i < arr.Length - 1; i++)
            {
                //排序剩下的值；
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1] ^ desc)
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr.ToList();
        }
    }
}
