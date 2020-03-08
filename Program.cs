using System;

namespace CryptoAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            string coded, decoded;
            string M = "TEKSTTESTOWYTAKISE", C = "TTTTSESTSOYAIEKEWK";
            coded = RailFence(3, M);
            decoded = RailFenceDecrypt(3, C);

            if (decoded.Equals(C))
            {
                Console.WriteLine("Takie same");
            }
            else
            {
                Console.WriteLine("Teksty sa rozne");
            }
        }



        public static string RailFence(int n, string M) {

            char[,] array = new char[n, M.Length];
            bool down = true;

            for (int i = 0, tmp = 0; i < M.Length; i++) {
                if (tmp == n - 1 ) down = false;
                if (tmp == 0) down = true;

                array[tmp, i] = M[i];

                if (down) tmp++;
                    else tmp--;
            }

            string result = "";
            Console.WriteLine(M);
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < M.Length; j++)
                {
                    if(Char.IsLetter(array[i,j]))
                        result += array[i, j];
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(result);
            return result;
        }

        public static string RailFenceDecrypt(int n, string C)
        {

            char[,] array = new char[n, C.Length];
            bool down = true;
            int index = 0;

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
            

            string result = "";
            Console.WriteLine(C);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < C.Length; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   if (Char.IsLetter(array[j, i]))
                        result += array[j, i];
                }
            }
            Console.WriteLine(result);
            return result;
        }
    }
}
