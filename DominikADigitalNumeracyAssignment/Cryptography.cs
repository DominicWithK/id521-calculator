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
            foreach (char character in text)
            {
                //Check to change letters only
                if (char.IsLetter(character))
                {
                    char offset = char.IsUpper(character) ? 'A' : 'a';
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
        static string AffineDecrypt(string text, int a, int b)
        {
            string decrypted = "";
            int inverse = GetInverse(a);
            foreach (char c in text.ToUpper())
            {
                if (char.IsLetter(c))
                {
                    int y = c - 'A';
                    int x = (inverse * (y - b + 26)) % 26;
                    decrypted += (char)(x + 'A');
                }
                else
                {
                    decrypted += c;
                }
            }
            return decrypted;
        }
        public static string BruteForceAffine(string text) 
        { 
            return "";
        }
    }
}
