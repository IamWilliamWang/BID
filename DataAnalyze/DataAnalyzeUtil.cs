using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BID.DataAnalyze
{
    class DataAnalyzeUtil
    {
        #region 算总和值
        /// <summary>
        /// 得到各列的总和值。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的总和值List</returns>
        public static List<double> get总和值List(List<List<double>> list)
        {
            List<double> sums = new List<double>();
           
            for (int col = 0; col < list[0].Count; col++)
            {
                double sum = 0;
                for (int row = 0; row < list.Count; row++)
                {
                    sum += list[row][col];
                }
                sums.Add(sum);
            }
            return sums;
        }
        #endregion

        #region 算平均值
        /// <summary>
        /// 得到各列的平均值。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的平均值List</returns>
        public static List<double> get平均值List(List<List<double>> list)
        {
            List<double> 总和List = get总和值List(list);
            List<double> result = new List<double>();
            foreach (float data in 总和List)
            {
                result.Add(data / list.Count);
            }
            return result;
        }
        #endregion

        #region 算最大值
        /// <summary>
        /// 得到各列的最大值。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的最大值List</returns>
        public static List<double> get最大值List(List<List<double>> list)
        {
            List<double> maxs = new List<double>();

            for (int col = 0; col < list[0].Count; col++)
            {
                double max = 0;
                for (int row = 0; row < list.Count; row++)
                {
                    if (list[row][col] > max)
                        max = list[row][col];
                }
                maxs.Add(max);
            }
            return maxs;
        }
        #endregion

        #region 算最小值
        /// <summary>
        /// 得到各列的最小值。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的最小值List</returns>
        public static List<double> get最小值List(List<List<double>> list)
        {
            List<double> mins = new List<double>();

            for (int col = 0; col < list[0].Count; col++)
            {
                double min = float.MaxValue;
                for (int row = 0; row < list.Count; row++)
                {
                    if (list[row][col] < min)
                        min = list[row][col];
                }
                mins.Add(min);
            }
            return mins;
        }
        #endregion

        #region 算极差
        /// <summary>
        /// 得到各列的极差。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的极差List</returns>
        public static List<double> get极差List(List<List<double>> list)
        {
            List<double> result = new List<double>();
            List<double> 最大 = get最大值List(list);
            List<double> 最小 = get最小值List(list);
            for(int i = 0; i < 最大.Count; i++)
            {
                result.Add(最大[i] - 最小[i]);
            }
            return result;
        }
        #endregion

        #region 算标准差
        /// <summary>
        /// 得到各列的标准差。
        /// </summary>
        /// <param name="list">二维List型float数据</param>
        /// <returns>各列的标准差List</returns>
        public static List<double> get标准差List(List<List<double>> list)
        {
            List<double> result = new List<double>();
            List<double> 平均值 = get平均值List(list);
            int N = list[0].Count;
            for(int col = 0; col < list[0].Count; col++)
            {
                double 该列的平均值 = 平均值[col];
                double 该列的标准差 = 0;
                for(int row = 0; row < list.Count; row++)
                {
                    该列的标准差 += Math.Pow(list[row][col] - 该列的平均值, 2);
                }
                该列的标准差 /= N;
                该列的标准差 = Math.Sqrt(该列的标准差);
                result.Add(该列的标准差);
            }
            return result;
        }
        #endregion
    }
}
