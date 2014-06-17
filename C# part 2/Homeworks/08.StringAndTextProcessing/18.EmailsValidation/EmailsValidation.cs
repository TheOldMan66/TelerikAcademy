using System;

/* Write a program for extracting all email addresses from given text. All substrings 
 * that match the format <identifier>@<host>…<domain> should be recognized as emails. */

class EmailsValidation
{
    static bool CheckForValidAddress(string address)
    {

        string[] parts = address.Split('@');
        if (parts[0].Length < 2 || parts[1].Length < 5) // if name < 2 or host+domain < 5... its not a valid address
            return false;
        string[] domainParts = parts[1].Split('.');
        if (domainParts.Length < 2) // these is no host and domain separated with '.' -> invalid address
            return false;
        foreach (string s in domainParts)
            if (s.Length < 2) // domain ot host are too short -> invalid address.
                return false;
        return true;
    }

    static void Main()
    {
        string input = "Please contact us by phone (+359 222 222 222) or by email at exa_mple@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
        Console.WriteLine("input sentence is:");
        Console.WriteLine(input);
        int beginOfMail = 0;
        int endOfMail = 0;
        int currentPosInString = input.IndexOf('@');
        Console.WriteLine();
        Console.WriteLine("Valid e-mail addresses in this sentence are:");
        while (currentPosInString > -1)
        {
            beginOfMail = input.Substring(0, currentPosInString).LastIndexOf(' '); //find first space in left of "@"
            endOfMail = input.IndexOf(' ', currentPosInString); //find first space in right of "@"
            if (endOfMail == -1) // if mail is on end of sentence
                endOfMail = input.Length; // assume that end of sentence is end of mail
            string possibileMail = input.Substring(beginOfMail + 1, endOfMail - beginOfMail - 1); // may be it is a valid e-mail, who knows... :)
            if (!char.IsLetter(possibileMail[possibileMail.Length - 1])) // remove trailing punctuation sign (if mail is on end of sentence or have coma ot dot right afther the address
                possibileMail = possibileMail.Remove(possibileMail.Length - 1);

            if (CheckForValidAddress(possibileMail)) // detailed check for validity
                Console.WriteLine(possibileMail); // YES!!! It's a valid address :)
            currentPosInString = input.IndexOf('@', endOfMail); // let's look for another address
        }
    }
}