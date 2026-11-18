using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominikADigitalNumeracyAssignment
{
    public class Cryptography
    {
        // You can reverse this by taking away shift from 26
        public static string CaesarEncrypt(string text, int shift)
        {
            string encryptedtext = "";
            //Change every character forward by shift, modulo 26 to wrap around (XYZ > ABC)
            foreach (char character in text.ToUpper())
            {
                //Check to change letters only
                if (char.IsLetter(character))
                {
                    char offset;
                    //Offset - checks which characters are uppercause and lowercase and keeps them the same
                    if (char.IsUpper(character))
                    {
                        offset = 'A';
                    }
                    else
                    {
                        offset = 'a';
                    }
                    encryptedtext += (char)(((character - offset + shift) % 26) + offset);
                }
                //Spaces, numbers and special characters stay the same
                else
                {
                    encryptedtext += character;
                }
            }
            return encryptedtext;
        }
        public static string AffineEncrypt(string text, int multiplier, int affineenshift)
        {
            string encryptedtext = "";
            foreach (char character in text.ToUpper())
            {
                //Check to change letters only
                if (char.IsLetter(character))
                {
                    //Gets the character position, removes 'A' (65) and then adds it back to convert it to a letter
                    int position = character - 'A';
                    int encryptedchar = (multiplier * position + affineenshift) % 26;
                    encryptedtext += (char)(encryptedchar + 'A');
                }
                //Spaces, numbers and special characters stay the same in affine encrypt as well
                else
                {
                    encryptedtext += character;
                }
            }
            return encryptedtext;
        }
        public static string AffineDecrypt(string text, int multiplier, int affinedeshift)
        {
            string decryptedtext = "";
            //Get inverse of the multiplier
            int inverse = Inverse(multiplier);
            foreach (char character in text.ToUpper())
            {
                //Change letters only
                if (char.IsLetter(character))
                {
                    int position = character - 'A';
                    int encryptedchar = (inverse * (position - affinedeshift + 26)) % 26;
                    decryptedtext += (char)(encryptedchar + 'A');
                }
                //Special characters unchanged
                else
                {
                    decryptedtext += character;
                }
            }
            return decryptedtext;
        }
        static int Inverse(int multiplier)
        {
            //Switches multiplier to it's inverse value
            switch (multiplier)
            {
                case 1: 
                    return 1;
                case 3: 
                    return 9;
                case 5: 
                    return 21;
                case 7: 
                    return 15;
                case 9: 
                    return 3;
                case 11: 
                    return 19;
                case 15: 
                    return 7;
                case 17: 
                    return 23;
                case 19: 
                    return 11;
                case 21: 
                    return 5;
                case 23: 
                    return 17;
                case 25: 
                    return 25;
                default: 
                    return -1;
            }
        }
        public static string AffineBruteForce(string text)
        {
            int[] multipliers = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            string results = "";
            //Repeat for each multiplier
            foreach (int multiplier in multipliers)
            {
                //Repeat 26 times - once per shift
                for (int i = 0; i < 26; i++)
                {
                    string decrypted = AffineDecrypt(text, multiplier, i);
                    results += $"a={multiplier}, b={i}: {decrypted}\n";
                }
            }
            return results;
        }
    }
}
