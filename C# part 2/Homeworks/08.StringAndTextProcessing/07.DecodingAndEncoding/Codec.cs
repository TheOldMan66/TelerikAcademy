using System;

    class Codec
    {
        static string Encode(string s, string cypher)
        {
            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (char)(arr[i] ^ cypher[i % (cypher.Length)]);
            }
            return new string(arr);
        }

        static void Main()
        {
            string cypher = "telerik";
            Console.WriteLine("Enter some string to decode (or press <ENTER> to see some test string): ");
            string input = Console.ReadLine();
            if (input == "")
            {
                input = StringConstants.submarine;
            }
            Console.WriteLine("Input text is:");
            Console.WriteLine(input);
            string encoded = Encode(input,cypher);
            Console.WriteLine();
            Console.WriteLine("Encoded string (not all chars are printable on console):");
            Console.WriteLine(encoded);
            Console.WriteLine();
            string decoded = Encode(encoded, cypher);
            Console.WriteLine("Decoded string:");
            Console.WriteLine(decoded);
        }
    }