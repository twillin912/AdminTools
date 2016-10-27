using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AdminTools.Services
{
    public interface IPasswordServices
    {
        ICollection<string> GeneratePasswords(int length, bool symbol, int count);
        string GetPhoneticPassword(string password);
    }

    public class PasswordServices : IPasswordServices //TODO: Fixup for Allow Symbols = false
    {
        private const string UPPER_CASE = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const string LOWER_CASE = "abcdefghijkmnopqrstuvwxyz";
        private const string NUMBERS = "23456789";
        private const string SYMBOLS = "!@#$%*";
        private const string INVALIDCHARS = "O01lI=><(){}[]`'"; // TODO: Update characters

        Random r = new Random();

        public ICollection<string> GeneratePasswords(int length = 0, bool symbol = true, int count = 1)
        {
            string password;
            var passwords = new List<string>();
            for (int i = 0; i < count; i++)
            {
                password = GeneratePassword(length, symbol);
                passwords.Add(password);
            }
            return passwords;
        }

        public string GeneratePassword(int length = 0, bool symbol = true)
        {

            var rng = RandomNumberGenerator.Create();
            if (length == 0) { length = r.Next(8, 12); };
            int rndlength = r.Next(48, 96);
            int start = r.Next(1, rndlength - length);

            // TODO: Remove invalid characters
            string required = "";
            string password = "";
            required += RandomChar(UPPER_CASE);
            required += RandomChar(LOWER_CASE);
            required += RandomChar(NUMBERS);
            if (symbol == true)
            {
                required += RandomChar(SYMBOLS);
            }


            var buff = new byte[rndlength];
            rng.GetBytes(buff);
            var encoding = new ASCIIEncoding();
            password = Convert.ToBase64String(buff);
            password = RandomizeString(password).Substring(start, length - 4);
            return RandomizeString(required + password);
        }

        private string RandomChar(string str)
        {
            return str.Substring(r.Next(0, str.Length - 1), 1);
        }

        private string RandomizeString(string str)
        {
            string result = "";
            while (str.Length > 0)
            {
                int i = r.Next(0, str.Length - 1);
                result += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return result;
        }

        public string GetPhoneticPassword(string Passsord)
        {
            string PhoneticString = string.Empty;
            char[] pswChar = Passsord.ToCharArray();
            foreach (char chr in pswChar)
            {
                if (PhoneticString == string.Empty)
                {
                    PhoneticString = GetPhoneticSting(chr);
                }
                else
                {
                    PhoneticString += " - " + GetPhoneticSting(chr);
                }
            }

            return PhoneticString;
        }


        private string GetPhoneticSting(char Chr)
        {
            string PhString = string.Empty;

            string Newchar = Chr.ToString();

            switch (Newchar.ToLower())
            {
                case "a":
                    PhString = "Alpfa";
                    break;
                case "b":
                    PhString = "Bravo";
                    break;
                case "c":
                    PhString = "Charlie";
                    break;
                case "d":
                    PhString = "Delta";
                    break;
                case "e":
                    PhString = "Echo";
                    break;
                case "f":
                    PhString = "Foxtrot";
                    break;
                case "g":
                    PhString = "Golf";
                    break;
                case "h":
                    PhString = "Hotel";
                    break;
                case "i":
                    PhString = "India";
                    break;
                case "j":
                    PhString = "Juliet";
                    break;
                case "k":
                    PhString = "Kilo";
                    break;
                case "l":
                    PhString = "Lima";
                    break;
                case "m":
                    PhString = "Mike";
                    break;
                case "n":
                    PhString = "November";
                    break;
                case "o":
                    PhString = "Oscar";
                    break;
                case "p":
                    PhString = "Papa";
                    break;
                case "q":
                    PhString = "Quebec";
                    break;
                case "r":
                    PhString = "Romeo";
                    break;
                case "s":
                    PhString = "Sierra";
                    break;
                case "t":
                    PhString = "Tango";
                    break;
                case "u":
                    PhString = "Uniform";
                    break;
                case "v":
                    PhString = "victor";
                    break;
                case "w":
                    PhString = "whiskey";
                    break;
                case "x":
                    PhString = "x-ray";
                    break;
                case "y":
                    PhString = "yankee";
                    break;
                case "z":
                    PhString = "zulu";
                    break;
                case "1":
                    PhString = "One";
                    break;
                case "2":
                    PhString = "Two";
                    break;
                case "3":
                    PhString = "Three";
                    break;
                case "4":
                    PhString = "Four";
                    break;
                case "5":
                    PhString = "Five";
                    break;
                case "6":
                    PhString = "Six";
                    break;
                case "7":
                    PhString = "Seven";
                    break;
                case "8":
                    PhString = "Eight";
                    break;
                case "9":
                    PhString = "Nine";
                    break;
                case "0":
                    PhString = "Zero";
                    break;
                case " ":
                    PhString = "Space";
                    break;
                case "!":
                    PhString = "Exclamation";
                    break;
                case "@":
                    PhString = "At";
                    break;
                case "#":
                    PhString = "Hash";
                    break;
                case "$":
                    PhString = "Dollar";
                    break;
                case "%":
                    PhString = "Percent";
                    break;
                case "^":
                    PhString = "Caret";
                    break;
                case "&":
                    PhString = "Ampersand";
                    break;
                case "*":
                    PhString = "Asterisk";
                    break;
                case "+":
                    PhString = "Plus ";
                    break;
                default:
                    PhString = "Unknown";
                    break;
            }

            if (CheckUpper(Chr.ToString()))
            {
                PhString = PhString.ToUpper();
            } else
            {
                PhString = PhString.ToLower();
            }

            return PhString;

        }

        private bool CheckUpper(string strCheck)
        {
            if (string.Compare(strCheck, strCheck.ToUpper()) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
