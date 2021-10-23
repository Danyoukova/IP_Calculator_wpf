using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ait.IPCalculator.Core.Services
{
    public class ConvertService
    {

        public string DecToBinaryNumber(int inputnumber)
        {
            string result = "";
            while (inputnumber > 0)
            {
                result = (inputnumber % 2).ToString() + result;
                inputnumber /= 2;
            }
            while (result.Length < 8)
            {
                result = "0" + result;
            }

            return result;
        }

        public int BinaryToDecimal(string inputBnumber)
        {
            int result = 0;
            int exponent = 1;
            for (int i = inputBnumber.Length - 1; i >= 0; i--)
            {
                result += (inputBnumber[i] - '0') * exponent;
                exponent *= 2;
            }
            return result;
        }
              
        public string BinaryToDD(string s)
        {
            string result = "";
            for (int c = 0; c < s.Length; c += 8)
            {
                result = result + s[c] + ".";
            }

            string[] splitted = SplitString(result);
            string joined = JoinArr(splitted);
            return joined;
        }

       
        public string JoinArr(string[] arr)
        {
            return string.Join(".", arr);
        }
        public string[] SplitString(string s)
        {
            string[] newArr = s.Split(".");
            return newArr;
        }

        public string ForeachToBinary(string[] arr)
        {
            string str = "";
            foreach (string s in arr)
            {
                str += DecToBinaryNumber(int.Parse(s)).ToString();
            }
            return str;

        }
        public string ChangeAllToBinaryOne(string str)
        {
            string newstring = "";
            foreach (char c in str)
            {
                newstring += "1";
            }
            return newstring;
        }

        public string[] ChangeBroadcastToLastHost(string[] arr)
        {
            string[] broadcastToLastHostarr = new string[4];
            broadcastToLastHostarr[0] = arr[0];
            broadcastToLastHostarr[1] = arr[1];
            broadcastToLastHostarr[2] = arr[2];
            broadcastToLastHostarr[3] = (int.Parse(arr[3]) - 1).ToString();

            return broadcastToLastHostarr;
        }
        public string[] ChangeToFirstHost(string[] arr)
        {
            string[] newString = new string[4];
            newString[0] = arr[0];
            newString[1] = arr[1];
            newString[2] = arr[2];
            newString[3] = (int.Parse(arr[3]) + 1).ToString();

            return newString;
        }

        public int GetMaxHost(int i)
        {
            int hostnr = (int)(Math.Pow(2, i) - 2);
            return hostnr;
        }

        public string CheckTypeOfNetworkadd(string str)
        {
            string[] strarray = str.Split(".");
            string resultType = "";
            int part1 = int.Parse(strarray[0]);
            int part2 = int.Parse(strarray[1]);
            int part3 = int.Parse(strarray[2]);
            int part4 = int.Parse(strarray[3]);
            if (part1 == 10 || part1 == 172 && part2 >= 16 && part2 <= 31 || part1 == 192)
            {
                resultType = "Private";
            }

            if (part1 == 100 && part2 >= 64 && part2 <= 127)
            {
                resultType = "Shared address space";
            }
            else if (part1 == 127)
            {
                resultType = "Loopback adres";
            }

            else if (part1 == 169 && part2 == 254)
            {
                resultType = "Link-local adres";
            }

            else if (part1 >= 240 && part2 <= 255)
            {
                resultType = "Experimental";
            }
            else if (part1 == 192 && part2 == 0 && part3 == 2 && part4 >= 0 && part4 <= 255)
            {
                resultType = "Test-net";
            }

            else
            {
                resultType = "Public";
            }
            return resultType;
        }

        public string CheckClass(int firstByte)
        {
            string classAddress = string.Empty;
            if (firstByte < 127)
            {
                classAddress = "A";
            }
            if (firstByte > 127 && firstByte < 191)
            {
                classAddress = "B";
            }
            if (firstByte > 191 && firstByte < 223)
            {
                classAddress = "C";
            }
            if (firstByte > 223 && firstByte < 239)
            {
                classAddress = "D";
            }
            if (firstByte > 239 && firstByte < 255)
            {
                classAddress = "E";
            }
            return classAddress;
        }
    }
}
