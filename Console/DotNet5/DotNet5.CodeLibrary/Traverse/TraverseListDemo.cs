﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet5.CodeLibrary.Traverse
{
    public class TraverseListDemo
    {
        public static void Run()
        {
            //去掉集合中的所有奇数

            //正序
            RemoveAtWithOrder();
            //倒序
            RemoveAtWithReverseOrder();
        }

        /// <summary>
        /// 随机100W个数字
        /// </summary>
        /// <returns></returns>
        public static List<int> GetRandomDatas()
        {
            List<int> datas = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                Random random = new Random();
                datas.Add(random.Next(100000));
            }

            return datas;
        }

        private static void RemoveAtWithOrder()
        {
            List<int> datas = GetRandomDatas();

            var start = Environment.TickCount;
            for (int i = 0; i < datas.Count;)
            {
                if (datas[i] % 2 != 0)
                    datas.RemoveAt(i);
                else
                    i++;
            }
            var end = Environment.TickCount;
            var t = end - start;
            Console.WriteLine($"正序用时:{t}");
        }


        private static void RemoveAtWithReverseOrder()
        {
            List<int> datas = GetRandomDatas();

            var start = Environment.TickCount;
            for (int i = datas.Count-1; i >=0 ;i--)
            {
                if (datas[i] % 2 != 0)
                    datas.RemoveAt(i);
            }
            var end = Environment.TickCount;
            var t = end - start;
            Console.WriteLine($"倒序用时:{t}");
        }
    }
}
