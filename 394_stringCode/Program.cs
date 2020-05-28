using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _394_StringCode
{
    //394. 字符串解码
    class Program
    {
        public string GetString(string s,int nStart,int nEnd)
        {
            string strDes = s.Substring(nStart + 1, (nEnd-1) - nStart);
            return strDes;
        }

        public int GetStringToNumber(string strNum)
        {
            int nSum = 0;
            int nLen = strNum.Length;
            for (int i = nLen -1; i>= 0;--i)
            {
                int nCur = strNum[i] - '0';
                nSum += nCur * (int)Math.Pow(10, nLen - i -1);
            }
            return nSum;
        }
        public string GetNumberString(string s, int nStart)
        {
            int nKey = nStart - 1;
            string strSum = "";
            while (nKey >= 0 && s[nKey] >= '0' && s[nKey] <= '9')
            {
                strSum = s[nKey] + strSum;
                nKey--;
            }
            return strSum;
        }

        public string SpliceString(string s,int nNum)
        {
            string str = "";
            for(int i = 0;i< nNum; ++i)
            {
                str += s;
            }
            return str;
        }

        public string DecodeString(string s)
        {
            string strEnd = s;
            int nLeft = 0;
            int nRight = 0;
            int nKey = 0;
            while (nKey < s.Length && nRight <= 0)
            {
                if (s[nKey] == '[')
                {
                    nLeft = nKey;
                }
                else if (s[nKey] == ']')
                {
                    nRight = nKey;
                    string strTest = GetString(s, nLeft, nRight);
                    string strNum = GetNumberString(s, nLeft);
                    int nNum = GetStringToNumber(strNum);
                    string str = SpliceString(strTest, nNum);
                    string str1 = s.Substring(0, nLeft - strNum.Length);
                    string str2 = s.Substring(nRight + 1, s.Length - 1 - nRight);
                    string strDes = str1 + str + str2;
                    strEnd = DecodeString(strDes);
                }
                nKey++;
            }
            return strEnd;
        }

        static void Main(string[] args)
        {
            var sb = new Stack<int>();
            Program pro = new Program();
            string strArg = "100[leetcode]";
            string strDes = pro.DecodeString(strArg);
            Console.WriteLine(strDes);
            Console.ReadKey();
        }
    }
}
