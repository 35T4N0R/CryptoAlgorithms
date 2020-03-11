using System;

namespace CryptoAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //string coded, decoded;
            //string M = "TEKSTTESTOWYTAKISE", C = "LATEOZJSSPRMEU";
            //coded = RailFence(3, M);
            //decoded = RailFenceDecrypt(3, C);
            //Console.WriteLine(decoded);
            //MatrixDecrypt("3142", "YGHACTAOPRYROPS");
            //Matrix3Decrypt("CONVENIENCE", "heespnirrsseeseiyascbtemgepnandictrtahsoieero");
            //Console.WriteLine(NWD(452, 23));
            Cesar(5, 7, "CRYPTOGRAPHY");
        }



        public static string RailFence(int n, string M) {

            char[,] array = new char[n, M.Length];
            bool down = true;
            string result = "";

            for (int i = 0, tmp = 0; i < M.Length; i++) {
                if (tmp == n - 1 ) down = false;
                if (tmp == 0) down = true;

                array[tmp, i] = M[i];

                if (down) tmp++;
                    else tmp--;
            }

            
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < M.Length; j++)
                {
                    if(Char.IsLetter(array[i,j]))
                        result += array[i, j];
                }
            }

            return result;
        }

        public static string RailFenceDecrypt(int n, string C)
        {

            char[,] array = new char[n, C.Length];
            bool down = true;
            int index = 0;
            string result = "";

            for(int tmp2 = 0; tmp2 < n; tmp2++)
            {
                for (int i = 0, tmp = 0; i < C.Length; i++)
                {
                    if (tmp == n - 1) down = false;
                    if (tmp == 0) down = true;

                    if (tmp == tmp2)
                    {
                        array[tmp, i] = C[index++];
                    }

                    if (down) tmp++;
                    else tmp--;
                }
            }
            

            
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   if (Char.IsLetter(array[j, i]))
                        result += array[j, i];
                }
            }

            return result;
        }

        public static void Matrix(string key, string M)
        {
           
            //construct an 2D array
            double N = (double)M.Length / key.Length;

            if (N % (int)N != 0) N += 1;

            int n = (int)N / 1;

            char[,] array = new char[n, key.Length];

            //construct 1D array with keys
            int[] keyTab = new int[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                keyTab[i] = Convert.ToInt32(Convert.ToString(key[i]));
            }

            //Write array
            int index = 0;
            string result = "";
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < key.Length && index < M.Length; j++)
                {
                    array[i, j] = M[index++];
                }
            }

            //Read 2D array
            int y = 0, x;

            while(y < keyTab.Length)
            {
                x = keyTab[y++];
                for(int i = 0; i < n; i++)
                {
                    if (Char.IsLetter(array[i, x - 1]))
                    {
                        result += array[i, x - 1];
                    }
                }
            }
            Console.WriteLine(result);
        }

        public static void MatrixDecrypt(string key, string M)
        {

            //construct an 2D array
            double N = (double)M.Length / key.Length;

            if (N % (int)N != 0) N += 1;

            int n = (int)N / 1;

            char[,] array = new char[n, key.Length];

            //construct 1D array with keys
            int[] keyTab = new int[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                keyTab[i] = Convert.ToInt32(Convert.ToString(key[i]));
            }

            //Write array
            int index = 0;
            string result = "";

            int idx = M.Length % keyTab.Length;
            int x, tmp;
            for (int i = 0; i < keyTab.Length; i++)
            {
                x = keyTab[i];

                if (x <= idx || idx == 0) tmp = n;
                else tmp = n - 1;

                for (int j = 0; j < tmp ; j++)
                {
                    array[j, x-1] = M[index++];
                }
            }

            /*for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < keyTab.Length; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }*/


            //Read Array
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < keyTab.Length; j++)
                {
                    if(Char.IsLetter(array[i,j]))
                        result += array[i, j];
                }
            }

            Console.WriteLine(result);
        }

        public static void Matrix2(string key, string M)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToLower();
            M = M.ToLower();
            
            //Prepare the array key
            for(int i = 0; i < alphabet.Length; i++)
            {
                for(int j = 0; j < key.Length; j++)
                {
                    if (alphabet[i].Equals(key[j]))
                    {
                        keyTab[j] = x;
                        x++;
                    }
                }
            }

            //construct teh 2D array
            double N = (double)M.Length / key.Length;

            if (N % (int)N != 0) N += 1;

            int n = (int)N / 1;

            char[,] array = new char[n, key.Length];

            //write 2D array
            int index = 0;
            for(int i = 0; i < n ; i++)
            {
                for(int j = 0; j < key.Length && index < M.Length; j++)
                {
                    array[i, j] = M[index++];
                }
            }

            //Read 2D array
            for (int g = 0; g < key.Length + 1; g++)
            {
                for (int i = 0; i < keyTab.Length; i++)
                {
                    if (g == keyTab[i])
                    {
                        for (int j = 0; j < n; j++)
                        {
                            result += array[j, i];
                        }
                    }
                }
            }




            Console.WriteLine(result);

            //for(int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + " ");
                     
            //}

            //for(int i = 0; i < n; i++)
            //{
            //    for(int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}

        }

        public static void Matrix2Decrypt(string key, string M)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToLower();
            M = M.ToLower();

            //Prepare the array key
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (alphabet[i].Equals(key[j]))
                    {
                        keyTab[j] = x;
                        x++;
                    }
                }
            }

            //construct teh 2D array
            double N = (double)M.Length / key.Length;

            if (N % (int)N != 0) N += 1;

            int n = (int)N / 1;

            char[,] array = new char[n, key.Length];

            //write 2D array
            int index = 0;

            int idx = M.Length % keyTab.Length;
            int h, tmp;
            for (int i = 1; i <= keyTab.Length; i++)
            {
                for(int k = 0; k < keyTab.Length; k++)
                {
                    if(i == keyTab[k])
                    {   
                        if (k + 1  <= idx || idx == 0) tmp = n;
                        else tmp = n - 1;

                        for (int j = 0; j < tmp; j++)
                        {
                            array[j, k] = M[index++];
                        }
                    }
                }
            }


            //Read 2D array
            int c = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < key.Length && c < M.Length; j++)
                {
                    result += array[i,j];
                    c++;
                }
            }




            Console.WriteLine(result);

            //for (int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + " ");

            //}

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        public static void Matrix3(string key, string M) {

            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToLower();
            M = M.ToLower();

            //Prepare the array key
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (alphabet[i].Equals(key[j]))
                    {
                        keyTab[j] = x;
                        x++;
                    }
                }
            }
            int sum = 0;
            int n = 0;
            for(int i = 1; i <= keyTab.Length; i++)
            {
                for(int j = 0; j < keyTab.Length; j++)
                {
                    if(i == keyTab[j])
                    {
                        sum += (j + 1);
                    }
                }
                if (sum == M.Length)
                {
                    n = i;
                    break;
                }
            }

            char[,] array = new char[n, keyTab.Length];


            //Write 2D array
            int index = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int k = 0; k < keyTab.Length; k++)
                {
                    if (i == keyTab[k])
                    {
                        //if (k + 1 <= idx || idx == 0) tmp = n;
                        //else tmp = n - 1;

                        for (int j = 0; j < k + 1; j++)
                        {
                            array[i - 1, j] = M[index++];
                        }
                        break;
                    }
                }
            }

            //Read 2D array
            for (int g = 0; g < key.Length + 1; g++)
            {
                for (int i = 0; i < keyTab.Length; i++)
                {
                    if (g == keyTab[i])
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if(Char.IsLetter(array[j, i]))
                                result += array[j, i];
                        }
                        //result += " ";
                    }
                }
            }
            Console.WriteLine(result);

            //Console.WriteLine(n);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    Console.Write(array[i, j] + ". ");
                }
                Console.WriteLine();
            }

        }

        public static void Matrix3Decrypt(string key, string M)
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToLower();
            M = M.ToLower();

            //Prepare the array key
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (alphabet[i].Equals(key[j]))
                    {
                        keyTab[j] = x;
                        x++;
                    }
                }
            }

            int sum = 0;
            int n = 0;
            for (int i = 1; i <= keyTab.Length; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    if (i == keyTab[j])
                    {
                        sum += (j + 1);
                    }
                }
                if (sum == M.Length)
                {
                    n = i;
                    break;
                }
            }

            char[,] array = new char[n, keyTab.Length];

            int[] charNumbers = new int[keyTab.Length];

            for(int i = 0; i < keyTab.Length; i++)
            {
                charNumbers[keyTab[i] - 1] = i + 1;
            }
            //for (int i = 0; i < charNumbers.Length; i++)
            //{
            //    Console.Write(charNumbers[i] + " ");

            //}

            x = 0;
            for (int i = 1; i <= keyTab.Length; i++)
            {
                for (int k = 0; k < keyTab.Length; k++)
                {
                    if (i == keyTab[k])
                    {
                        for (int j = 0; j < n && x < M.Length; j++)
                        {
                            if (k + 1 <= charNumbers[j]) array[j, k] = M[x++];
                            else array[j, k] = ' ';
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    if (Char.IsLetter(array[i, j])) result += array[i, j];
                    Console.Write(array[i, j] + ". ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(result);
        }

        public static void Cesar(int k0, int k1, string M)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            alphabet = alphabet.ToUpper();
            string result = "";
            if (NWD(k1, 26) != 1) return;
            if (NWD(k0, 26) != 1) return;

            for (int i = 0; i < M.Length; i++)
            {
                result += alphabet[(((M[i] - 65) * k1 + k0) % 26)];
            }

            Console.WriteLine(result);




           /* int tmp; //zły wzór patrzyłem na wzór do deszyfowania
            int opposite = 0;
            for(int i = 0; i < 26; i++)
            {
                tmp = (k1 * i) % 26;
                if(tmp == 1)
                {
                    opposite = i;
                    break;
                }
            }
            for (int i = 0; i < M.Length; i++)
            {   
                result += alphabet[((M[i] + (26 - k0)) * opposite) % 26];

            }

            Console.WriteLine(result);*/

        }

        public static int NWD(int k0, int k1)
        {
            while (k0 != k1)
            {
                if (k0 > k1)
                    k0 -= k1;
                else
                    k1 -= k0;
            }

            return k0;
        }
    }
}
