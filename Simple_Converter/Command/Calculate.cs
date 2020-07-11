using System;
using Simple_Converter.ViewModel;

namespace Simple_Converter.Command
{
    public class Calculate
    {
        private readonly SimpleConverterViewModel _simpleConverterViewModel;

        public Calculate(SimpleConverterViewModel simpleConverterViewModel)
        {
            _simpleConverterViewModel = simpleConverterViewModel;
        }
        
         public string DectoBit(String decNum)
        {

            string answer;
            string result;


            if (decNum != String.Empty)
            {
                answer = decNum;
                long num = Convert.ToInt64(answer);
                result = "";
                while (num > 1)
                {
                    long remainder = num % 2;
                    result = Convert.ToString(remainder) + result;
                    num /= 2;
                }
                result = Convert.ToString(num) + result;
                return result + "b";
            }
            return String.Empty;
        }

        public string DectoHex(String decNum)
        {

            string answer;
            string result;
            if (decNum != String.Empty)
            {
                answer = decNum;

                long num = Convert.ToInt64(answer);
                result = "";
                string rema = "";
                while (num > 1)
                {
                    long remainder = num % 16;
                    if (remainder == 15) rema = "F";
                    if (remainder == 14) rema = "E";
                    if (remainder == 13) rema = "D";
                    if (remainder == 12) rema = "C";
                    if (remainder == 11) rema = "B";
                    if (remainder == 10) rema = "A";

                    if (remainder < 10) result = Convert.ToString(remainder) + result;
                    else result = rema + result;
                    num /= 16;
                }
                result = Convert.ToString(num) + result;
                return result + "h";
            }
            else return String.Empty;
        }

        public string BittoDec(String binNum)
        {
            if (binNum != String.Empty)
            {
                string erg = "";
                long b = Convert.ToInt64(binNum, 2);
                erg = Convert.ToString(b);


                return erg;
            } 
            return String.Empty;
        }
        public string BittoHex(String binNum)
        {
            string erg = "";
            
            string hextodec = BittoDec(binNum);

            erg = DectoHex(hextodec);

            return erg;
        }
        public string HextoDec(string hexNum)
        {
            double b = 0;
            double erge = 0;
            string erg = "";
            if (hexNum != String.Empty)
            {
                for (int i = 0; i < hexNum.Length; i++)
                {

                    if (hexNum[i] == 'F') b = 15 * Math.Pow(16, hexNum.Length - i - 1);
                    if (hexNum[i] == 'E') b = 14 * Math.Pow(16, hexNum.Length - i - 1);
                    if (hexNum[i] == 'D') b = 13 * Math.Pow(16, hexNum.Length - i - 1);
                    if (hexNum[i] == 'C') b = 12 * Math.Pow(16, hexNum.Length - i - 1);
                    if (hexNum[i] == 'B') b = 11 * Math.Pow(16, hexNum.Length - i - 1);
                    if (hexNum[i] == 'A') b = 10 * Math.Pow(16, hexNum.Length - i - 1);
                    if (Convert.ToInt32(hexNum[i] - '0') < 10) { b = Convert.ToDouble(Convert.ToInt32(Convert.ToInt32(hexNum[i] - '0') * Math.Pow(16, hexNum.Length - i - 1))); }
                    erge = b + erge;

                }
                erg = Convert.ToString(erge);
                return erg;
            }
            else return String.Empty;
        }
        public string HextoBit(string hexNum)
        {
            if (hexNum != String.Empty)
            {
                string erg = "";
                string res = HextoDec(hexNum);
                erg = DectoBit(res);
                return erg;
            }
            return String.Empty;
        }
        public String execute(String str)
        {
            if (!string.IsNullOrEmpty(str) && str[str.Length - 1] == 'b')
            {
                str = str.Substring(0, str.Length - 1);
            return str;
            }
            if (!string.IsNullOrEmpty(str) && str[str.Length - 1] == 'h')
            {
                str = str.Substring(0, str.Length - 1);
            return str;
            }
            return str;
        }
        public void Clear()
        {
            _simpleConverterViewModel.Binary = String.Empty;
            _simpleConverterViewModel.Hexa = String.Empty;
            _simpleConverterViewModel.Decimal = String.Empty;
        }


    }
}