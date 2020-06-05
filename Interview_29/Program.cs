using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 面试题29. 顺时针打印矩阵
 * 输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字。

示例 1：
输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
输出：[1,2,3,6,9,8,7,4,5]

示例 2：
输入：matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
输出：[1,2,3,4,8,12,11,10,9,5,6,7]
*/
namespace Interview_29
{
    public class Solution
    {
        public int[] SpiralOrder(int[][] matrix)
        {
            int nXLen = matrix.Length;
            if (nXLen <= 0)
            {
                return new int[] { };
            }
            int nYLen = matrix[0].Length;
            int[] resoult = new int[nXLen * nYLen];
            int nStartX = 0, nEndX = nXLen - 1;
            int nStartY = 0, nEndY = nYLen - 1;
            int nDec = 1;
            int nNum = 0;
            while (nStartX <= nEndX && nStartY <= nEndY)
            {
                switch (nDec)
                {
                    case 1://向左
                        for (int i = nStartY; i <= nEndY; ++i)
                        {
                            resoult[nNum++] = matrix[nStartX][i];
                        }
                        nStartX++;
                        nDec++;
                        break;
                    case 2://向下
                        for (int i = nStartX; i <= nEndX; ++i)
                        {
                            resoult[nNum++] = matrix[i][nEndY];
                        }
                        nEndY--;
                        nDec++;
                        break;
                    case 3://向右
                        for (int i = nEndY; i >= nStartY; --i)
                        {
                            resoult[nNum++] = matrix[nEndX][i];
                        }
                        nEndX--;
                        nDec++;
                        break;
                    case 4://向上
                        for (int i = nEndX; i >= nStartX; --i)
                        {
                            resoult[nNum++] = matrix[i][nStartY];
                        }
                        nStartY++;
                        nDec = 1;
                        break;
                    default:
                        break;

                }
            }
            return resoult;
        }

        public int[] SpiralOrder2(int[][] matrix)
        {
            if (matrix.Length < 1) return new int[0];
            int row = matrix.Length;
            int colum = matrix[0].Length;
            int[,] direction = new int[,] { { 1, 0 }, { 0, -1, }, { -1, 0 }, { 0, 1 } };
            int[] pos = new int[] { 0, colum - 1 };
            int reserve = 0;

            int len = (row - 1) * colum; //总长度(减去第一行)
            int[] result = new int[row * colum];
            int index = colum;
            for (int i = 0; i < colum; i++)
            {
                result[i] = matrix[0][i];//插入第一行
            }
            while (len > 0)
            {
                for (int i = 1; i < row; i++)
                {
                    len--;
                    pos[0] += direction[reserve, 0];
                    pos[1] += direction[reserve, 1];
                    result[index++] = matrix[pos[0]][pos[1]];
                }
                row--;
                Swap(ref row, ref colum);
                reserve = (reserve + 1) % 4;
            }
            return result;
        }

        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public int[] SpiralOrder3(int[][] matrix)
        {
            if (matrix.Length < 1) return new int[0];
            int row = matrix.Length;
            int colum = matrix[0].Length;
            int[] result = new int[row * colum];
            int[,] direction = new int[,] { { 0, 1 }, { 1, 0, }, { 0, -1 }, { -1, 0 } };
            int[] pos = new int[] { 0, -1 };
            int reserve = 0;
            int index = 0;
            while (row > 0 && colum > 0)
            {
                for (int i = 0; i < colum; i++)
                {
                    pos[0] += direction[reserve, 0];
                    pos[1] += direction[reserve, 1];
                    result[index++] = matrix[pos[0]][pos[1]];
                }
                row--;
                Swap(ref row, ref colum);
                reserve = (reserve + 1) % 4;
            }
            return result;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            //int[,] matrix = new int[3, 3] { { 1,2,3},{ 4,5,6},{ 7,8,9} };
            int[][] matrix = new int[3][];// { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrix[0] = new int[]{ 1, 2, 3,4 };
            matrix[1] = new int[] { 5, 6, 7,8 };
            matrix[2] = new int[] { 9, 10, 11,12 };
            Solution so = new Solution();
            int[]  x = so.SpiralOrder3(matrix);
            foreach (int i in x)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
