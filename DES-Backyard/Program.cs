namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /////////////////
            //if (0 == 0)
            //{
            //    //HEX -> BIN
            //    string hexNumber = "A1B2C3D4"; // Replace with the hexadecimal number you want to convert
            //    string binaryNumber = Convert.ToString(Convert.ToInt32(hexNumber, 16), 2);
            //}
            //else
            //{
            //    //DEC -> BIN
            //    int decimalNumber = 15;
            //    string binaryNumber = Convert.ToString(decimalNumber, 2);
            //    Console.WriteLine(binaryNumber);
            //}
            ////////////////////////////////////////////////////////////////
            //                c0       d0


            string key = "0x133457799BBCDFF1";//64 bit
            key = Convert.ToString(Convert.ToInt64(key, 16), 2);//bin
            key = binaryMissingZeros(key);
            //Console.WriteLine(key);
            int[] PC1 =
            {
              57, 49, 41, 33, 25, 17, 9,
              1, 58, 50, 42, 34, 26, 18,
              10, 2, 59, 51, 43, 35, 27,
              19, 11, 3, 60, 52, 44, 36,
              63, 55, 47, 39, 31, 23, 15,
              7, 62, 54, 46, 38, 30, 22,
              14, 6, 61, 53, 45, 37, 29,
              21, 13, 5, 28, 20, 12, 4
            };
            string tmpKey = "";
            for (int i = 0; i < PC1.Length; i++)
            {
                tmpKey += key[PC1[i] - 1];
            }
            key = tmpKey;
            //Console.WriteLine("-----------");
            //Console.WriteLine(key);

            List<string> C = new List<string>();
            List<string> D = new List<string>();
            C.Add(key.Substring(0, 28));
            D.Add(key.Substring(28, 28));
            for (int i = 1; i <= 16; i++)
            {
                C.Add(C[i - 1]);
                D.Add(D[i - 1]);
                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    shiftLeft(C[i], 1);
                    shiftLeft(D[i], 1);
                }
                else
                {
                    shiftLeft(C[i], 2);
                    shiftLeft(C[i], 2);
                }

            }

            List<string> keys = new List<string>();
            keys.Add("aliMohamed");
            for (int i = 1; i <= 16; i++)
            {
                keys.Add(C[i] + D[i]);
            }

            int[] PC2 =
             {
             14, 17, 11, 24, 1, 5,
             3, 28, 15, 6, 21, 10,
             23, 19, 12, 4, 26, 8,
             16, 7, 27, 20, 13, 2,
             41, 52, 31, 37, 47, 55,
             30, 40, 51, 45, 33, 48,
             44, 49, 39, 56, 34, 53,
             46, 42, 50, 36, 29, 32
            };


            for (int i = 1; i <= 16; i++)
            {
                string tmpKeys = "";
                for (int j = 0; j < PC2.Length; j++)
                {
                    tmpKeys += keys[i][PC2[j] - 1];
                }
                keys[i] = tmpKeys;
            }
            //Console.WriteLine(keys.Last());


            string plain = "0x0123456789ABCDEF";
            plain = Convert.ToString(Convert.ToInt64(plain, 16), 2);//bin
            plain = binaryMissingZeros(plain);

            int[] IP =
            {
             58, 50, 42, 34, 26, 18, 10, 2,
             60, 52, 44, 36, 28, 20, 12, 4,
             62, 54, 46, 38, 30, 22, 14, 6,
             64, 56, 48, 40, 32, 24, 16, 8,
             57, 49, 41, 33, 25, 17, 9, 1,
             59, 51, 43, 35, 27, 19, 11, 3,
             61, 53, 45, 37, 29, 21, 13, 5,
             63, 55, 47, 39, 31, 23, 15, 7
            };

            string tmp = "";
            for (int i = 0; i < IP.Length; i++)
            {
                tmp += plain[IP[i] - 1];
            }
            plain = tmp;

            Console.WriteLine(plain);

            //for(int i = 1; i < 16;i++) 
            //{
            //    string left1 = plain.Substring(0, 32);
            //    string right1 = plain.Substring(32, 32);

            //    string left2 = right1;

            //    Int64 leftInt = Convert.ToInt64(left1, 2);
            //    Int64 funcOutInt = Convert.ToInt64(func(keys[i], right1), 2);

            //    Int64 rightInt = leftInt | funcOutInt;
            //    string right2 = Convert.ToString(rightInt);
            //    right2 = binaryMissingZeros(right2);
            //}


        }
        static string shiftLeft(string binaryNumber, int shiftAmount)
        {
            string shiftedBinaryNumber = binaryNumber.Substring(shiftAmount) + new string('0', shiftAmount);
            return shiftedBinaryNumber;
        }

        static string func(string key, string right)
        {
            return key;
        }
        static string binaryMissingZeros(string binaryNumber)
        {
            string tmp = "";
            for (int i = 0; i < 64 - binaryNumber.Length; i++)
            {
                tmp += '0';
            }
            tmp += binaryNumber;
            return tmp;
        }

        static string round(string plain, int i)
        {

            string left1 = plain.Substring(0, 32);
            string right1 = plain.Substring(32, 32);

            string left2 = right1;

            Int64 leftInt = Convert.ToInt64(left1, 2);
            Int64 funcOutInt = Convert.ToInt64(func(keys[i], right1), 2);

            Int64 rightInt = leftInt | funcOutInt;
            string right2 = Convert.ToString(rightInt);
            right2 = binaryMissingZeros(right2);

            string newPlain = left2 + right2;
            if (i < 16)
                return round(newPlain, i + 1);
            else
            {
                //swap
                return newPlain
            }

        }
    }
}