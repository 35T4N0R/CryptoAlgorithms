using System;
using System.Collections.Generic;

namespace CryptoAlgorithms
{
    class Program
    {

        private static int[] key_generating_permutation_1 = new int[]
        {
            57,49,41,33,25,17,9,1,58,50,42,34,26,18,10,2,59,51,43,35,27,19,11,3,60,52,44,36,63,55,47,39,31,23,15,7,62,54,46,38,30,22,14,6,61,53,45,37,29,21,13,5,28,20,12,4
        };

        private static int[] shift_array = new int[]
        {
            1,1,2,2,2,2,2,2,1,2,2,2,2,2,2,1
        };

        private static int[] key_generating_permutation_2 = new int[]
        {
            14,17,11,24,1,5,3,28,15,6,21,10,23,19,12,4,26,8,16,7,27,20,13,2,41,52,31,37,47,55,30,40,51,45,33,48,44,49,39,56,34,53,46,42,50,36,29,32
        };


        static void Main(string[] args)
        {
            //HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION

            //Rail Fence
            //Console.WriteLine("-------------Rail Fence-------------");
            //RailFence(3, "CRYPTOGRAPHY");
            //RailFenceDecrypt(3, "CTARPORPYYGH");
            //Console.WriteLine();

            ////Matrix 2a
            //Console.WriteLine("-------------Matrix 2a-------------");
            //Matrix("34152", "CRYPTOGRAPHYOSA");
            //MatrixDecrypt("34152", "YPCTRRAOPGOSHAY");
            //Console.WriteLine();

            ////Matrix 2b
            //Console.WriteLine("-------------Matrix 2b-------------");
            //Matrix2("CONVENIENCE", "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION");
            //Matrix2Decrypt("CONVENIENCE", "HECRNCEYIISEPSGDIRNTOAAESRMPNSSROEEBTETIAEEHS");
            //Console.WriteLine();

            ////Matrix 2c
            //Console.WriteLine("-------------Matrix 2c-------------");
            //Matrix3("CONVENIENCE", "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION");
            //Matrix3Decrypt("CONVENIENCE", "HEESPNIRRSSEESEIYASCBTEMGEPNANDICTRTAHSOIEERO");
            //Console.WriteLine();

            ////Cesar
            //Console.WriteLine("-------------Affine Cipher-------------");
            //Cesar(5, 7, "CRYPTOGRAPHY");
            //CesarDecrypt(5, 7, "TURGIZVUFGCR");
            //Console.WriteLine();

            ////Vigenere
            //Console.WriteLine("-------------Vigenere Cipher-------------");
            //Vigenere("BREAK", "CRYPTOGRAPHY");
            //VigenereDecrypt("BREAK", "DICPDPXVAZIP");
            //Console.WriteLine();

            //LSFR
            //Console.WriteLine("-------------LFSR Generator-------------");
            //int[] taps = new int[2] { 1, 4 };
            //String number = LFSR("1101", taps);
            //Console.WriteLine("Generated Number with LFSR: " + number);
            //SynchronousEncode("11101001", "0010", taps);
            //SynchronousDecode("10010011", "0010", taps);
            //AutokeyEncode("11101001", "0011", taps);
            //AutokeyDecode("0110100011100101", "0011", taps);
            //Console.WriteLine();

            //DES
            //Console.WriteLine("-------------DES-------------");
            List<String> keys = DESKeyGenerate("IEOFIT#1");
            int idx = 1;
            foreach(String s in keys)
            {
                Console.WriteLine("Key " + idx++ + " : " + s);
            }

        }



        public static void RailFence(int n, string M)
        {
            M = M.ToUpper();

            //Construct 2D array
            char[,] array = new char[n, M.Length];
            bool down = true;
            string result = "";

            //Write 2D array
            for (int i = 0, tmp = 0; i < M.Length; i++) {
                if (tmp == n - 1 ) down = false;
                if (tmp == 0) down = true;

                array[tmp, i] = M[i];

                if (down) tmp++;
                    else tmp--;
            }

            //Read 2D array
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < M.Length; j++)
                {
                    if(Char.IsLetter(array[i,j]))
                        result += array[i, j];
                }
            }

            Console.WriteLine("Zakodowany tekst: " + result);
        }

        public static void RailFenceDecrypt(int n, string C)
        {
            C = C.ToUpper();

            //Construct 2D array
            char[,] array = new char[n, C.Length];
            bool down = true;
            int index = 0;
            string result = "";

            //Write 2D array
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
            

            //Read 2D array
            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   if (Char.IsLetter(array[j, i]))
                        result += array[j, i];
                }
            }

            Console.WriteLine("Odkodowany tekst: " + result);
        }

        public static void Matrix(string key, string M)
        {
            M = M.ToUpper();

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

            //Write 2D array
            int index = 0;
            string result = "";
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < key.Length && index < M.Length; j++)
                {
                    array[i, j] = M[index++];
                }
            }

            //Print 2D array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            //Read 2D array
            int y = 0;

            while(y < n)
            {

                for(int i = 0; i < keyTab.Length; i++)
                {
                    if (Char.IsLetter(array[y, keyTab[i] - 1]))
                    {
                        result += array[y, keyTab[i] - 1];
                    }
                }

                y++;
            }

            Console.WriteLine("Zakodowany tekst: " + result);
        }

        public static void MatrixDecrypt(string key, string M)
        {
            M = M.ToUpper();

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

            for (int i = 0; i < n; i++)
            {

                for(int j = 0; j < keyTab.Length && index < M.Length; j++)
                {
                    array[i, keyTab[j] - 1] = M[index++];
                }

            }

            //Print 2D array
            //for(int i = 0; i < n; i++)
            //{
            //    for(int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}


            //Read Array
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < keyTab.Length; j++)
                {
                    if(Char.IsLetter(array[i,j]))
                        result += array[i, j];
                }
            }

            Console.WriteLine("Odkodowany tekst: " + result);
        }

        public static void Matrix2(string key, string M)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToUpper();
            M = M.ToUpper();
            
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
                            if(Char.IsLetter(array[j, i]))
                                result += array[j, i];
                        }
                    }
                }
            }




            Console.WriteLine("Zakodowany tekst: " + result);

            //Print array with keys
            //for(int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + " ");
            //}

            //Print 2D array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}

        }

        public static void Matrix2Decrypt(string key, string M)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToUpper();
            M = M.ToUpper();

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




            Console.WriteLine("Odkodowany tekst: " + result);

            //Print array with keys
            //for (int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + " ");
            //}

            //Print 2D array
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

            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToUpper();
            M = M.ToUpper();

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

            //Print array with keys
            //for (int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + ". ");
            //}

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
                if (sum >= M.Length)
                {
                    n += i;
                    break;
                }else if(sum < M.Length && i >= keyTab.Length)
                {
                    n += i;
                    i = 0;
                }
            }

            char[,] array = new char[n, keyTab.Length];


            //Write 2D array
            int index = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int k = 0; k < keyTab.Length; k++)
                {
                    if ((i % keyTab.Length) == keyTab[k])
                    {
                       
                        for (int j = 0; j < k + 1 && index < M.Length; j++)
                        {
                            array[i - 1, j] = M[index++];
                        }
                        break;
                    }else if(i % keyTab.Length == 0)
                    {
                        k = keyTab.Length - 1;

                        for (int j = 0; j < k + 1 && index < M.Length; j++)
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
            Console.WriteLine("Zakodowany tekst: " + result);

            //Console.WriteLine(n);

            //Print 2D array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j] + ". ");
            //    }
            //    Console.WriteLine();
            //}

        }

        public static void Matrix3Decrypt(string key, string M)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int[] keyTab = new int[key.Length];
            int x = 1;

            key = key.ToUpper();
            M = M.ToUpper();

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
                if (sum >= M.Length)
                {
                    n += i;
                    break;
                }
                else if (sum < M.Length && i >= keyTab.Length)
                {
                    n += i;
                    i = 0;
                }
            }
            //Console.WriteLine(n);
            char[,] array = new char[n, keyTab.Length];

            int[] charNumbers = new int[keyTab.Length];

            for(int i = 0; i < keyTab.Length; i++)
            {
                charNumbers[keyTab[i] - 1] = i + 1;

            }

            //Print array with number of chars for each row
            //for (int i = 0; i < charNumbers.Length; i++)
            //{
            //    Console.Write(charNumbers[i] + " ");
            //}

            x = 0;
            int control_sum = 0;
            for (int i = 1; i <= keyTab.Length; i++)
            {
                control_sum = 0;
                for (int k = 0; k < keyTab.Length; k++)
                {
                    if (i == keyTab[k])
                    {
                        for (int j = 0,s = 0; j < n && x < M.Length; j++, s++)
                        {
                            if (j % charNumbers.Length == 0) s = 0;
                            if (k + 1 <= charNumbers[s] && control_sum + k < M.Length) array[j, k] = M[x++];
                            else array[j, k] = ' ';
                            control_sum += charNumbers[s];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    if (Char.IsLetter(array[i, j])) result += array[i, j];
                    //Console.Write(array[i, j] + ". "); //print values of 2D array
                }
                //Console.WriteLine();
            }

            Console.WriteLine("Odkodowany tekst: " + result);
        }

        public static void Cesar(int k0, int k1, string M)
        {
            M = M.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            if (NWD(k1, 26) != 1) return;
            if (NWD(k0, 26) != 1) return;

            for (int i = 0; i < M.Length; i++)
            {
                result += alphabet[(((M[i] - 65) * k1 + k0) % 26)];
            }

            Console.WriteLine("Zakodowany tekst: " + result);

        }

        public static void CesarDecrypt(int k0, int k1, string M)
        {
            M = M.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            if (NWD(k1, 26) != 1) return;
            if (NWD(k0, 26) != 1) return;

            int tmp;
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
                result += alphabet[(((M[i] - 65) + (26 - k0)) * opposite) % 26];

            }

            Console.WriteLine("Odkodowany tekst: " + result);
        }

        public static void Vigenere(string key, string M)
        {
            key = key.ToUpper();
            M = M.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            char[,] array = new char[26, 26]; 
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    array[i, j] = alphabet[(j + i) % 26];
                    //Console.Write(array[i, j] + " "); //print values of alphabet 2D array
                }
                //Console.WriteLine();
            }

            string usefullKey = "";
            int y = 0;
            while (usefullKey.Length < M.Length)
            {
                usefullKey += key[y++ % key.Length];
            }

            //Print extended key
            //Console.WriteLine(usefullKey);

            for (int i = 0; i < M.Length; i++)
            {
                result += array[usefullKey[i] - 65, M[i] - 65];
            }

            Console.WriteLine("Zakodowany tekst: " + result);
        }

        public static void VigenereDecrypt(string key, string M) 
        {
            key = key.ToUpper();
            M = M.ToUpper();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            char[,] array = new char[26, 26];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    array[i, j] = alphabet[(j + i) % 26];
                    //Console.Write(array[i, j] + " "); //print values of alphabet 2D array
                }
                //Console.WriteLine();
            }

            string usefullKey = "";
            int y = 0;
            while (usefullKey.Length < M.Length)
            {
                usefullKey += key[y++ % key.Length];
            }

            //Print extended key
            //Console.WriteLine(usefullKey);

            for (int j = 0; j < M.Length; j++)
            {
                for (int i = 0; i < 26; i++)
                {
                    if(array[usefullKey[j] - 65,i] == M[j])
                        result += alphabet[i];
                }
            } 
            Console.WriteLine("Odkodowany tekst: " + result);
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





        public static String LFSR(String seed, int[] taps)
        {
            String state = seed;
            int xor = 0;
            String generatedNumber = "";
            do
            {
                for (int i = 0; i < taps.Length; i++)
                {
                    xor += Convert.ToInt32(state[taps[i] - 1]) - '0'; 
                }

                xor %= 2;

                Console.WriteLine("state: " + state);

                state = state.Insert(0, xor.ToString());
                state = state.Remove(4, 1);


                generatedNumber += xor.ToString();

                xor = 0;
            } while (!state.Equals(seed));

            return generatedNumber;
        }

        public static void SynchronousEncode(String X, String seed, int[] taps)
        {

            String LFSRnumber = LFSR(seed, taps);
            String result = "";
            
            for (int i = 0; i < X.Length; i++)
            {
                result += ((Convert.ToInt32(X[i]) - '0') ^ (Convert.ToInt32(LFSRnumber[i]) - '0')).ToString();
            }

            Console.WriteLine("wynik: " + result);


        }

        public static void SynchronousDecode(String Y, String seed, int[] taps)
        {

            String LFSRnumber = LFSR(seed, taps);
            String result = "";

            for (int i = 0; i < Y.Length; i++)
            {
                result += ((Convert.ToInt32(Y[i]) - '0') ^ (Convert.ToInt32(LFSRnumber[i]) - '0')).ToString();
            }

            Console.WriteLine("wynik: " + result);


        }

        public static void AutokeyEncode(String X, String seed, int[] taps)
        {
            String result = "";
            String state = seed;

            int Z = 0;
            int tmp;
            int index = 0;

            do
            {
                for (int i = 0; i < taps.Length; i++)
                {
                    Z += Convert.ToInt32(state[taps[i] - 1]) - '0';
                }

                Z %= 2;

                tmp = (Convert.ToInt32(X[index++]) - '0') ^ Z;

                state = state.Insert(0, tmp.ToString());
                state = state.Remove(4, 1);

                result += tmp.ToString();

                Z = 0;

            } while (X.Length != result.Length);

            Console.WriteLine("Wynik: " + result);
        }

        public static void AutokeyDecode(String Y, String seed, int[] taps)
        {
            String result = "";
            String state = seed;
            int Z = 0;
            int index = 0;

            do
            {

                for (int i = 0; i < taps.Length; i++)
                {
                    Z += Convert.ToInt32(state[taps[i] - 1]) - '0';
                }

                Z %= 2;

                result += ((Convert.ToInt32(Y[index]) - '0') ^ Z).ToString();

                state = state.Insert(0, Y[index++].ToString());
                state = state.Remove(4, 1);

                Z = 0;

            } while (Y.Length != result.Length);

            Console.WriteLine("Wynil: " + result);

        }


        public static List<String> DESKeyGenerate (String key)
        {

            List<String> keys = new List<String>();

            String binary_key = "";
            foreach(char c in key)
            {
                binary_key += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            //Console.WriteLine("Given key in binary: " + binary_key);
            String permutated_key = "";
            for (int i = 0; i < key_generating_permutation_1.Length; i++)
            {
                permutated_key += binary_key[key_generating_permutation_1[i] - 1];
            }

            //Console.WriteLine("Permutated Key : " + permutated_key);

            String left_key_part = permutated_key.Substring(0,permutated_key.Length / 2);
            String right_key_part = permutated_key.Substring(permutated_key.Length / 2, permutated_key.Length / 2);

            Console.WriteLine("Left part of the key: " + left_key_part);
            Console.WriteLine("Right part of the key: " + right_key_part);
            Console.WriteLine();

            String left_value;
            String right_value;
            String permutated_new_key;
            for (int i = 0; i < shift_array.Length; i++)
            {
                left_value = left_key_part.Substring(0,shift_array[i]);
                left_key_part = left_key_part.Remove(0, shift_array[i]);
                left_key_part = left_key_part.Insert(left_key_part.Length, left_value.ToString());

                right_value = right_key_part.Substring(0, shift_array[i]);
                right_key_part = right_key_part.Remove(0, shift_array[i]);
                right_key_part = right_key_part.Insert(right_key_part.Length, right_value.ToString());

                String new_key = left_key_part + right_key_part;

                permutated_new_key = "";
                for (int j = 0; j < key_generating_permutation_2.Length; j++)
                {
                    permutated_new_key += new_key[key_generating_permutation_2[j] - 1];
                }

                keys.Add(permutated_new_key);

            }

            return keys;
        }


    }
}
