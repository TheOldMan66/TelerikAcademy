namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// String extension class
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Compute MD5 hash checksum.
        /// </summary>
        /// <param name="input">String to calculate hash sum.</param>
        /// <returns>Returns calculated MD5 hash sum</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Return true if input string is any of "true", "ok", "yes", "1", "да"
        /// </summary>
        /// <param name="input">String which is checked</param>
        /// <returns>Return boolean if strig is any of "true", "ok", "yes", "1", "да"</returns>
        public static bool ToBoolean(this string input)
        {
            // chek if input string is any of recognisable words for confirmatin.
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Parse string to short integer
        /// </summary>
        /// <param name="input">String to parse</param>
        /// <returns>Return short with value, or 0 if string cannot be parsed</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Parse string to integer type
        /// </summary>
        /// <param name="input">String to parse</param>
        /// <returns>Return int with value, or 0 if string cannot be parsed</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Parse string to long integer
        /// </summary>
        /// <param name="input">String to parse</param>
        /// <returns>Return long with value, or 0 if string cannot be parsed</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Parse string to DateTime data type
        /// </summary>
        /// <param name="input">String to parse</param>
        /// <returns>Return DateTime, or date "01.01.0001 00:00" if string cannot be parsed</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Change first letter of string to upper case
        /// </summary>
        /// <param name="input">String to capitalize</param>
        /// <returns></returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Return substring, which is placed between two strigs.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="startString">String placed on left of searching substring</param>
        /// <param name="endString">String placed on right of searching substring</param>
        /// <param name="startFrom">Position from where search will start</param>
        /// <returns>Return founded substring, or empty string if start or end strings cannot be found.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString)) // start or end string is not present in input
            {
                return string.Empty;
            }

            //check if startString is after startFrom
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;  
            if (startPosition == -1) 
            {
                return string.Empty;
            }

            //check if endString is after startFrom
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Change cyrillic letters in string with their closest phonetic representatin of latin letters
        /// </summary>
        /// <param name="input">String with cyrillic letters</param>
        /// <returns>Return string with all cyrriilc leters in latin</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };

            // Transliteration of cyrillic letters with latin letters
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Cahnge latin letters in input string with their cyrillic analogue 
        /// </summary>
        /// <param name="input">String with latin letters which must be changed</param>
        /// <returns>Return string with all latin letter in cyrillic</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Ensure that string contains only small and capital latin letters, digits, underscore and dot.
        /// If string contain cyrillics letters, they are transliterated to latin. Every other forbidden letter is removed.
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>Return string, containing only latin letters, digits, underscore and dot.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// /// Ensure that string contains only small and capital latin letters, digits, underscore, minus and plus sign and dot.
        /// If string contain cyrillics letters, they are transliterated to latin. Every other forbidden letter is removed.
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>Return string, containing only latin letters, digits, underscore, minus and plus sign and dot.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Return first n character from string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="charsCount">Number of chars from beginning</param>
        /// <returns>N character long substring</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Return file extension
        /// </summary>
        /// <param name="fileName">String representing file name</param>
        /// <returns>extension of file name, or empty sting if file has no extension or input string is not a valid file name</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Return content-type of file, based on file extension
        /// </summary>
        /// <param name="fileExtension">file extension</param>
        /// <returns> Recognisable by extension file content or "application/octet stream" if unknown</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert string to one dimension byte array
        /// </summary>
        /// <param name="input">String to convert</param>
        /// <returns>Array of bytes, containing ASCII codes of input string.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
