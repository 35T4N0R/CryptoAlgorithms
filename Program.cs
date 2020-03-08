using System;

namespace CryptoAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //string coded, decoded;
            //string M = "TEKSTTESTOWYTAKISE", C = "TTTTSESTSOYAIEKEWK";
            //coded = RailFence(3, M);
            //decoded = RailFenceDecrypt(3, C);

            MatrixDecrypt("3142", "YGHACTAOPRYROPS");
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
    }
}
