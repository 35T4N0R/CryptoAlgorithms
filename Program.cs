using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private static int[] des_permutation_1 = new int[]
        {
            58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,62,54,46,38,30,22,14,6,64,56,48,40,32,24,16,8,57,49,41,33,25,17,9,1,59,51,43,35,27,19,11,3,61,53,45,37,29,21,13,5,63,55,47,39,31,23,15,7
        };

        private static int[] expand_permutation = new int[]
        {
            32,1,2,3,4,5,4,5,6,7,8,9,8,9,10,11,12,13,12,13,14,15,16,17,16,17,18,19,20,21,20,21,22,23,24,25,24,25,26,27,28,29,28,29,30,31,32,1
        };

        private static int[] permutation_after_blocks = new int[]
        {
            16,7,20,21,29,12,28,17,1,15,23,26,5,18,31,10,2,8,24,14,32,27,3,9,19,13,30,6,22,11,4,25
        };

        private static int[] final_permutation = new int[]
        {
            40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25
        };

        private static int[,,] blocks = new int[,,]
        {
            {
                {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
                {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
                {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
                {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13}
            },
            {
                {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},
                {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
                {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
                {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
            },
            {
                {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
                {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
                {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
                {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12}
            },
            {
                {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
                {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
                {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
                {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14}
            },
            {
                {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
                {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
                {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
                {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3}
            },
            {
                {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},
                {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
                {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
                {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13}
            },
            {
                {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},
                {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
                {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
                {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12}
            },
            {
                {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},
                {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
                {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
                {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}
            }
    };

        #region blocks
        private static int[,] block_S1 = new int[,]
        {
            {14,4,13,1,2,15,11,8,3,10,6,12,5,9,0,7},
            {0,15,7,4,14,2,13,1,10,6,12,11,9,5,3,8},
            {4,1,14,8,13,6,2,11,15,12,9,7,3,10,5,0},
            {15,12,8,2,4,9,1,7,5,11,3,14,10,0,6,13}
        };

        private static int[,] block_S2 = new int[,]
        {
            {15,1,8,14,6,11,3,4,9,7,2,13,12,0,5,10},
            {3,13,4,7,15,2,8,14,12,0,1,10,6,9,11,5},
            {0,14,7,11,10,4,13,1,5,8,12,6,9,3,2,15},
            {13,8,10,1,3,15,4,2,11,6,7,12,0,5,14,9}
        };

        private static int[,] block_S3 = new int[,]
        {
            {10,0,9,14,6,3,15,5,1,13,12,7,11,4,2,8},
            {13,7,0,9,3,4,6,10,2,8,5,14,12,11,15,1},
            {13,6,4,9,8,15,3,0,11,1,2,12,5,10,14,7},
            {1,10,13,0,6,9,8,7,4,15,14,3,11,5,2,12}
        };

        private static int[,] block_S4 = new int[,]
        {
            {7,13,14,3,0,6,9,10,1,2,8,5,11,12,4,15},
            {13,8,11,5,6,15,0,3,4,7,2,12,1,10,14,9},
            {10,6,9,0,12,11,7,13,15,1,3,14,5,2,8,4},
            {3,15,0,6,10,1,13,8,9,4,5,11,12,7,2,14}
        };

        private static int[,] block_S5 = new int[,]
        {
            {2,12,4,1,7,10,11,6,8,5,3,15,13,0,14,9},
            {14,11,2,12,4,7,13,1,5,0,15,10,3,9,8,6},
            {4,2,1,11,10,13,7,8,15,9,12,5,6,3,0,14},
            {11,8,12,7,1,14,2,13,6,15,0,9,10,4,5,3}
        };

        private static int[,] block_S6 = new int[,]
        {
            {12,1,10,15,9,2,6,8,0,13,3,4,14,7,5,11},
            {10,15,4,2,7,12,9,5,6,1,13,14,0,11,3,8},
            {9,14,15,5,2,8,12,3,7,0,4,10,1,13,11,6},
            {4,3,2,12,9,5,15,10,11,14,1,7,6,0,8,13}
        };

        private static int[,] block_S7 = new int[,]
        {
            {4,11,2,14,15,0,8,13,3,12,9,7,5,10,6,1},
            {13,0,11,7,4,9,1,10,14,3,5,12,2,15,8,6},
            {1,4,11,13,12,3,7,14,10,15,6,8,0,5,9,2},
            {6,11,13,8,1,4,10,7,9,5,0,15,14,2,3,12}
        };

        private static int[,] block_S8 = new int[,]
        {
            {13,2,8,4,6,15,11,1,10,9,3,14,5,0,12,7},
            {1,15,13,8,10,3,7,4,12,5,6,11,0,14,9,2},
            {7,11,4,1,9,12,14,2,0,6,10,13,15,3,5,8},
            {2,1,14,7,4,10,8,13,15,12,9,0,3,5,6,11}
        };
        #endregion


        static void Main(string[] args)
        {
            //HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION

            //Rail Fence
            //Console.WriteLine("-------------Rail Fence-------------");
            //RailFence(4, "CRYPTOGRAPHY");
            //RailFenceDecrypt(4, "CGRORYYTAHPP");
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

            //Cesar
            //Console.WriteLine("-------------Affine Cipher-------------");
            //Cesar(5, 7, "CRYPTOGRAPHY");
            //CesarDecrypt(5, 7, "TURGIZVUFGCR");
            //Console.WriteLine();

            ////Vigenere
            //Console.WriteLine("-------------Vigenere Cipher-------------");
            //Vigenere("BREAK", "CRYPTOGRAPHY");
            //VigenereDecrypt("BREAK", "DICPDPXVAZIP");
            //Console.WriteLine();

            ////LSFR
            //Console.WriteLine("-------------LFSR Generator and stream ciphers-------------");
            //int[] taps = new int[] { 1, 3, 4 };
            //String number = LFSR("0110", taps);
            ////Console.WriteLine("Generated Number with LFSR: " + number);
            //SynchronousEncode("11101011", "0110", taps);
            //SynchronousDecode("00110000", "0110", taps);
            //AutokeyEncode("11101011", "0110", taps);
            //AutokeyDecode("01111101", "0110", taps);
            ////Console.WriteLine();

            //DES
            Console.WriteLine("-------------DES-------------");
            List<String> keys = DESKeyGenerate("abcd"); //generowanie kluczy

            //////wypisanie wygenerowanych kluczy
            ////int idx = 1;
            ////foreach (String s in keys)
            ////{
            ////    Console.WriteLine("Key " + idx++ + " : " + s);
            ////}
            Console.WriteLine("Kodowany teskt: At1fsafafs421fssss");
            String result = DESEncode(keys, "At1fsafafs421fssss"); // zakodowanie wiadomości
            Console.WriteLine("Encrypted text in HEX: " + result); // wypisanie zakodowanej wiadomości w hex
            DESDecryption(keys, result); // odkodowanie zakodowanej wiadomości przekazanej jako hex (format przekazanej wiadomości: 11-22-33-44-55-66-77-88)
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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < M.Length; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }

            //Read 2D array
            for (int i = 0; i < n; i++)
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
            for(int j = 0; j < n; j++)
            {
                for (int i = 0, tmp = 0; i < C.Length; i++)
                {
                    if (tmp == n - 1) down = false;
                    if (tmp == 0) down = true;

                    if (tmp == j)
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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }


            //Read Array
            for (int i = 0; i < n; i++)
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

            ////Print array with keys
            //for (int i = 0; i < keyTab.Length; i++)
            //{
            //    Console.Write(keyTab[i] + " ");
            //}
            //Console.WriteLine();

            ////Print 2D array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine("Zakodowany tekst: " + result);

            

            

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
            int tmp;
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



            //Print array with keys
            for (int i = 0; i < keyTab.Length; i++)
            {
                Console.Write(keyTab[i] + " ");
            }
            Console.WriteLine();

            //Print 2D array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < keyTab.Length; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Odkodowany tekst: " + result);

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
                        for (int g = 0; g < keyTab.Length; g++)
                        {
                            if (keyTab[g] == keyTab.Length) k = g;
                        }

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
                    }
                }
            }

            ////Print 2D array
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < keyTab.Length; j++)
            //    {
            //        Console.Write(array[i, j] + ". ");
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine("Zakodowany tekst: " + result);

            //Console.WriteLine(n);

            

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
                    Console.Write(array[i, j] + ". "); //print values of 2D array
                }
                Console.WriteLine();
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
                }
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
                }
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

                //Console.WriteLine("state: " + state);

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
                result += ((Convert.ToInt32(X[i]) - '0') ^ (Convert.ToInt32(LFSRnumber[i % LFSRnumber.Length]) - '0')).ToString();
            }

            Console.WriteLine("Zakodowana wartość: " + result);


        }

        public static void SynchronousDecode(String Y, String seed, int[] taps)
        {

            String LFSRnumber = LFSR(seed, taps);
            String result = "";

            for (int i = 0; i < Y.Length; i++)
            {
                result += ((Convert.ToInt32(Y[i]) - '0') ^ (Convert.ToInt32(LFSRnumber[i % LFSRnumber.Length]) - '0')).ToString();
            }

            Console.WriteLine("Rozkodowana wartość: " + result);


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

            Console.WriteLine("Zakodowana wartość: " + result);
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

            Console.WriteLine("Odkodowana wartość: " + result);

        }


        public static List<String> DESKeyGenerate (String key)
        {

            List<String> keys = new List<String>();

            String binary_key = "";
            foreach(char c in key)
            {
                binary_key += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            binary_key = binary_key.PadRight(64, '0');

            //Console.WriteLine("Given key in binary: " + binary_key);

            String permutated_key = "";
            for (int i = 0; i < key_generating_permutation_1.Length; i++)
            {
                permutated_key += binary_key[key_generating_permutation_1[i] - 1];
            }

            //Console.WriteLine("Permutated Key : " + permutated_key);

            String left_key_part = permutated_key.Substring(0,permutated_key.Length / 2);
            String right_key_part = permutated_key.Substring(permutated_key.Length / 2, permutated_key.Length / 2);

            //Console.WriteLine("Left part of the key: " + left_key_part);
            //Console.WriteLine("Right part of the key: " + right_key_part);
            //Console.WriteLine();

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

        public static String DESEncode(List<String> keys, String text)
        {
            String hex_result = "";

            //Podział tesktu na bloki 8 bajtowe
            int numberOfBlocks = text.Length / 8;
            if(text.Length % 8 != 0) numberOfBlocks += 1;

            string[] textBlocks = new string[numberOfBlocks];

            int index = 0;
            String binaryLetter = "";
            for (int i = 0; i < text.Length; i++)
            {
                binaryLetter += Convert.ToString(text[i], 2).PadLeft(8, '0');

                if(binaryLetter.Length == 64)
                {
                    textBlocks[index++] = binaryLetter;
                    binaryLetter = "";
                }else if (i == text.Length - 1)
                {
                    textBlocks[index] = binaryLetter.PadRight(64, '0');
                }
            }




            //for (int i = 0; i < textBlocks.Length; i++)
            //{
            //    Console.WriteLine(textBlocks[i]);
            //}

            for (int b = 0; b < textBlocks.Length; b++)
            {

                String binary_text = textBlocks[b];


                //Console.WriteLine("Text in binary form: " + binary_text);

                String permutated_text = "";
                for (int i = 0; i < des_permutation_1.Length; i++)
                {
                    permutated_text += binary_text[des_permutation_1[i] - 1];
                }

                //Console.WriteLine("Permutated binary text: " + permutated_text);

                String left_part = permutated_text.Substring(0, permutated_text.Length / 2);
                String right_part = permutated_text.Substring(permutated_text.Length / 2, permutated_text.Length / 2);


                String column_binary;
                String row_binary;
                int column;
                int row;
                int value;

                foreach (String key in keys)
                {
                    String expanded_right_part = "";
                    for (int i = 0; i < expand_permutation.Length; i++)
                    {
                        expanded_right_part += right_part[expand_permutation[i] - 1];
                    }

                    String key_after_xor = "";
                    for (int j = 0; j < key.Length; j++)
                    {
                        key_after_xor += Convert.ToString(((expanded_right_part[j] - '0') + (key[j] - '0')) % 2);
                    }

                    String shirnked_right_part = "";
                    for (int i = 0; i < blocks.GetUpperBound(0) + 1; i++)
                    {
                        row_binary = Convert.ToString(key_after_xor[i * 6]) + Convert.ToString(key_after_xor[(i * 6) + 5]);
                        column_binary = key_after_xor.Substring((i * 6) + 1, 4);

                        column = Convert.ToInt32(column_binary, 2);
                        row = Convert.ToInt32(row_binary, 2);

                        value = blocks[i, row, column];

                        shirnked_right_part += Convert.ToString(value, 2).PadLeft(4, '0');
                    }

                    String permutated_shrinked_right_part = "";
                    for (int i = 0; i < permutation_after_blocks.Length; i++)
                    {
                        permutated_shrinked_right_part += shirnked_right_part[permutation_after_blocks[i] - 1];
                    }

                    String right_part_xored = "";
                    for (int j = 0; j < left_part.Length; j++)
                    {
                        right_part_xored += Convert.ToString(((permutated_shrinked_right_part[j] - '0') + (left_part[j] - '0')) % 2);
                    }

                    left_part = right_part;
                    right_part = right_part_xored;

                }

                String result = right_part + left_part;

                String permutated_result = "";
                for (int i = 0; i < final_permutation.Length; i++)
                {
                    permutated_result += result[final_permutation[i] - 1];
                }

                for (int i = 0; i < permutated_result.Length / 8; i++)
                {
                    hex_result += Convert.ToString(Convert.ToInt32(permutated_result.Substring(i * 8, 8), 2), 16).PadLeft(2, '0') + '-';
                }
            }
            hex_result = hex_result.Remove(hex_result.Length - 1, 1);
            
            return hex_result;
        }


        public static void DESDecryption(List<String> keys, String textInHEX)
        {
            String hex_result = "";
            keys.Reverse();

            string[] hex_ar = textInHEX.Split('-');

            int numberOfBlocks = hex_ar.Length / 8;
            if (hex_ar.Length % 8 != 0) numberOfBlocks += 1;

            string[] textBlocks = new string[numberOfBlocks];

            int index = 0;
            String binaryLetter = "";
            for (int i = 0; i < hex_ar.Length; i++)
            {
                binaryLetter += Convert.ToString(Convert.ToInt32(hex_ar[i], 16), 2).PadLeft(8, '0');

                if (binaryLetter.Length == 64)
                {
                    textBlocks[index++] = binaryLetter;
                    binaryLetter = "";
                }
                else if (i == hex_ar.Length - 1)
                {
                    textBlocks[index] = binaryLetter.PadRight(64, '0');
                }
            }



            for (int b = 0; b < textBlocks.Length; b++)
            {
                String binary_text = textBlocks[b];

                String permutated_text = "";
                for (int i = 0; i < des_permutation_1.Length; i++)
                {
                    permutated_text += binary_text[des_permutation_1[i] - 1];
                }

                //Console.WriteLine("Permutated binary text: " + permutated_text);

                String left_part = permutated_text.Substring(0, permutated_text.Length / 2);
                String right_part = permutated_text.Substring(permutated_text.Length / 2, permutated_text.Length / 2);


                String column_binary;
                String row_binary;
                int column;
                int row;
                int value;

                foreach (String key in keys)
                {
                    String expanded_right_part = "";
                    for (int i = 0; i < expand_permutation.Length; i++)
                    {
                        expanded_right_part += right_part[expand_permutation[i] - 1];
                    }

                    String key_after_xor = "";
                    for (int j = 0; j < key.Length; j++)
                    {
                        key_after_xor += Convert.ToString(((expanded_right_part[j] - '0') + (key[j] - '0')) % 2);
                    }

                    String shirnked_right_part = "";
                    for (int i = 0; i < blocks.GetUpperBound(0) + 1; i++)
                    {
                        row_binary = Convert.ToString(key_after_xor[i * 6]) + Convert.ToString(key_after_xor[(i * 6) + 5]);
                        column_binary = key_after_xor.Substring((i * 6) + 1, 4);

                        column = Convert.ToInt32(column_binary, 2);
                        row = Convert.ToInt32(row_binary, 2);

                        value = blocks[i, row, column];

                        shirnked_right_part += Convert.ToString(value, 2).PadLeft(4, '0');
                    }

                    String permutated_shrinked_right_part = "";
                    for (int i = 0; i < permutation_after_blocks.Length; i++)
                    {
                        permutated_shrinked_right_part += shirnked_right_part[permutation_after_blocks[i] - 1];
                    }

                    String right_part_xored = "";
                    for (int j = 0; j < left_part.Length; j++)
                    {
                        right_part_xored += Convert.ToString(((permutated_shrinked_right_part[j] - '0') + (left_part[j] - '0')) % 2);
                    }

                    left_part = right_part;
                    right_part = right_part_xored;

                }

                String result = right_part + left_part;

                String permutated_result = "";
                for (int i = 0; i < final_permutation.Length; i++)
                {
                    permutated_result += result[final_permutation[i] - 1];
                }

                
                for (int i = 0; i < permutated_result.Length / 8; i++)
                {
                    hex_result += Convert.ToString(Convert.ToInt32(permutated_result.Substring(i * 8, 8), 2), 16).PadLeft(2, '0') + "-";
                }
            }
            hex_result = hex_result.Remove(hex_result.Length - 1, 1);

            Console.WriteLine("Decrypted text in HEX: " + hex_result);

            string[] parts = hex_result.Split('-');

            String outText = "";
            for (int i = 0; i < parts.Length; i++)
            {
                outText += Convert.ToChar(Convert.ToInt32(Convert.ToString(Convert.ToInt32(parts[i], 16), 10)));
            }

            Console.WriteLine("Decrypted text: " +  outText);
        }


    }
}
