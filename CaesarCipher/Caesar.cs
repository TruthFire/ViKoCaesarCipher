using System;

namespace CaesarCipher
{
    internal class Caesar
    {
        public Caesar()
        {

        }

        char[] Letters =
       {
            'A','a','B','b','C','c','D','d','E','e','F','f','G','g','H','h','I','i','J','j','K','k',
            'L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s','T','t','U','u','V','v',
            'W','w','X','x','Y','y','Z','z'
        }; //Array of big and small letters

        // Array

        public string EncryptArray(string input, int key)
        {
            string output = "";
            int letterIndex, EncryptedLetterIndex;
            foreach (char c in input)
            {
                letterIndex = Array.IndexOf(Letters, c); //Get index of required letter in Letters array
                if (letterIndex == -1)
                {
                    output += c;
                    continue;
                }
                else if (letterIndex <= Letters.Length - key * 2)
                {
                    output += Letters[letterIndex + key * 2].ToString();
                    continue;
                }
                else if (letterIndex >= Letters.Length - key * 2) //
                {
                    EncryptedLetterIndex = letterIndex - (Letters.Length - key * 2);
                    output += Letters[EncryptedLetterIndex].ToString();
                }
            }

            return output;
        }

        public string DecryptArray(string input, int key)
        {
            string output = "";

            int letterIndex, EncryptedLetterIndex;
            foreach (char c in input)
            {
                letterIndex = Array.IndexOf(Letters, c); //Get index of required letter in Letters array
                if (letterIndex == -1) //If not letter
                {
                    output += c;
                    continue;
                }
                else if (letterIndex - (key * 2) < 0) //If letter is in range
                {
                    output += Letters[Letters.Length + (letterIndex - key * 2)].ToString();
                    continue;
                }
                else if (letterIndex - key * 2 > 0) //If letter is out of range
                {
                    EncryptedLetterIndex = letterIndex - key * 2;
                    output += Letters[EncryptedLetterIndex].ToString();
                    continue;
                }
                else
                {
                    output += Letters[0];
                }
            }

            return output;

        }

        //ASCII (Letters only)

        protected static bool IsASCIILetter(char c)
        {
            return ((int)c >= 65 && (int)c <= 90 || (int)c >= 97 && (int)c <= 122);
            //a - 65, z = 90, A = 97, Z = 122;
        }

        public string EncryptASCII_Letters(string input, int key)
        {
            string output = "";

            foreach (char c in input)
            {
                if (IsASCIILetter(c))
                {
                    if ((int)c + key > 90 && (int)c + key < 97) //If big letter out of range
                    {
                        output += Convert.ToChar(64 + ((int)c + key - 90));
                        continue;
                    }
                    else if ((int)c + key > 122) //If small letter out of range
                    {
                        output += Convert.ToChar(96 + ((int)c + key) - 122);
                        continue;
                    }
                    else //In range
                    {
                        output += Convert.ToChar(((int)c + key));
                    }
                }
                else //not a letter
                {
                    output += c;
                }
            }


            return output;
        }

        public string DecryptASCII_Letters(string input, int key)
        {
            string output = "";

            foreach (char c in input)
            {
                if (IsASCIILetter(c))
                {
                    if ((int)c - key < 65) //If big letter out of range
                    {
                        output += Convert.ToChar((int)c - key + 26);
                        continue;
                    }
                    else if ((int)c - key < 97 && (int)c - key > 90) //If small letter out of range
                    {
                        output += Convert.ToChar((int)c - key + 26);
                        continue;
                    }
                    else
                    {
                        output += Convert.ToChar((int)c - 3);
                    }


                }
                else
                {
                    output += c;
                }
            }

            return output;
        }

        // ASCII (Letters and symbols)


        protected static bool IsASCIIChar(char c)
        {
            return ((int)c >= 32 && (int)c <= 126);
            //space - 32, ~ = 126
        }

        public string EncryptASCII(string input, int key)
        {
            string output = "";

            foreach (char c in input)
            {
                if (IsASCIIChar(c))
                {
                    if ((int)c + key > 126)
                    {
                        output += Convert.ToChar(33 + (int)c + key - 126);
                    }
                    else
                    {
                        output += Convert.ToChar((int)c + key);
                    }
                }
                else
                {
                    output += c;
                }
            }

            return output;
        }

        public string DecryptASCII(string input, int key)
        {
            string output = "";

            foreach (char c in input)
            {
                if (IsASCIIChar(c))
                {
                    if ((int)c - key < 32)
                    {
                        output += Convert.ToChar((int)c - key + 93);
                    }
                    else
                    {
                        output += Convert.ToChar((int)c - key);
                    }
                }
                else
                {
                    output += c;
                }
            }

            return output;
        }

    }
}
