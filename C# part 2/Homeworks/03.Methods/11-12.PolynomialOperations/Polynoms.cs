using System;
using System.Collections.Generic;

class Polynomial
{
    SortedList<int, int> elements;

    public Polynomial()
    {
        elements = new SortedList<int, int>();
    }

    public Polynomial(string s)
    {
        elements = new SortedList<int, int>();
        int pos = 0;
        bool finish = false;
        while (!finish)
        {
            pos = s.IndexOfAny(new char[] { '+', '-' }, 1);
            string[] s1;
            if (pos == -1)
            {
                pos = s.Length;
                s1 = s.Split('x');
                finish = true;
            }
            else
                s1 = s.Substring(0, pos).Split('x');
            if (s1.GetLength(0) == 1)
            {
                this.AddElement(0, int.Parse(s1[0]));
                s = s.Substring(pos);
                continue;
            }
            if (s1[1] == "")
            {
                int val = 0;
                if (s1[0] == "" || s1[0] == "+")
                    val = 1;
                else if (s1[0] == "-")
                    val = -1;
                else
                    val = int.Parse(s1[0]);
                this.AddElement(1, val);
                s = s.Substring(pos);
                continue;
            }
            if (s1[0] == "" || s1[0] == "+")
            {
                this.AddElement(int.Parse(s1[1].Substring(1)), 1);
                s = s.Substring(pos);
                continue;
            }
            if (s1[0] == "-")
            {
                this.AddElement(int.Parse(s1[1].Substring(1)), -1);
                s = s.Substring(pos);
                continue;
            }
            this.AddElement(int.Parse(s1[1].Substring(1)), int.Parse(s1[0]));
            s = s.Substring(pos);
        }
    }

    private void AddElement(int key, int value)
    {
        if (this.elements.ContainsKey(key))
            this.elements[key] = this.elements[key] + value;
        else
            this.elements.Add(key, value);
    }

    public override string ToString()
    {
        string result = "";
        for (int i = elements.Count - 1; i >= 0; i--)
        {
            if (this.elements.Values[i] == 0)
                continue;
            if (this.elements.Values[i] > 0 && i < elements.Count - 1)
                result = result + "+";
            if (this.elements.Values[i] < 0)
                result = result + "-";
            if (Math.Abs(this.elements.Values[i]) != 1 || this.elements.Keys[i] == 0)
                result = result + Math.Abs(this.elements.Values[i]).ToString("G");
            if (this.elements.Keys[i] != 0)
                result = result + "x";
            if (Math.Abs(this.elements.Keys[i]) > 1)
                result = result + "^" + this.elements.Keys[i];
        }
        return result;
    }

    public static Polynomial operator +(Polynomial polyA, Polynomial polyB)
    {

        Polynomial result = new Polynomial();
        for (int i = 0; i < polyA.elements.Count; i++)
            result.AddElement(polyA.elements.Keys[i], polyA.elements.Values[i]);
        for (int i = 0; i < polyB.elements.Count; i++)
        {
            result.AddElement(polyB.elements.Keys[i], polyB.elements.Values[i]);
            if (result.elements[polyB.elements.Keys[i]] == 0)           // check if afther operation coefficient is 0
                result.elements.Remove(polyB.elements.Keys[i]);         // for example it's useless to store 0x^5 
        }
        return result;
    }

    public static Polynomial operator -(Polynomial polyA, Polynomial polyB)
    {

        Polynomial result = new Polynomial();
        for (int i = 0; i < polyA.elements.Count; i++)
            result.AddElement(polyA.elements.Keys[i], polyA.elements.Values[i]);
        for (int i = 0; i < polyB.elements.Count; i++)
        {
            result.AddElement(polyB.elements.Keys[i], -polyB.elements.Values[i]);
            if (result.elements[polyB.elements.Keys[i]] == 0)           // check if afther operation coefficient is 0
                result.elements.Remove(polyB.elements.Keys[i]);         // for example it's useless to store 0x^5
        }
        return result;
    }

    public static Polynomial operator *(Polynomial polyA, Polynomial polyB)
    {

        Polynomial result = new Polynomial();
        for (int i = 0; i < polyA.elements.Count; i++)
            for (int j = 0; j < polyB.elements.Count; j++)
                result.AddElement(polyA.elements.Keys[i] + polyB.elements.Keys[j], polyA.elements.Values[i]*polyB.elements.Values[j]);                
        return result;
    }
}


class PolynomsManipulation
{
    static void Main()
    {

        /* 11. Write a method that adds two polynomials. Represent them as arrays of 
         * their coefficients as in the example below: x2 + 5 = 1x2 + 0x + 5  5, 0 ,1
         * 12. Extend the program to support also subtraction and multiplication of polynomials. */

        Console.WriteLine("Polyonomials manipulation");
        Console.WriteLine("Please use polynomial format as shown here -> 'ax^n+bx^m+cx+d+...'");
        Console.WriteLine("where 'a','b','c' are coefficients, 'n','m' is a powers.");
        Console.WriteLine("You may not follow descending order for powers and can enter more");
        Console.WriteLine("than once same power (for example: 1 + x^2+x +5x^3+2x^3 + 5 is acceptable)");
        Console.WriteLine("Just use 'x' for variable and '^' for power sign");

        Console.Write("Polynom 1 (or just press 'Enter' for hardcoded sample): ");
        string sPoly2;
        string sPoly1 = Console.ReadLine();
        if (sPoly1 == "")
        {
            Console.WriteLine();
            sPoly1 = "x+x^2+x^3+x^2+x+1+x+x^2+x^3+x^2+x+1";
            Console.WriteLine("Polynomial 1 is {0}",sPoly1);
            sPoly2 = "12x^6+3x^3-x^8+2x^5";
            Console.WriteLine("Polynomial 2 is {0}", sPoly2);
        }
        else
        {
            Console.Write("Polynom 2: ");
            sPoly2 = Console.ReadLine();
        }
        sPoly1 = sPoly1.Replace(" ", string.Empty); // remove any spaces 
        sPoly2 = sPoly2.Replace(" ", string.Empty); // remove any spaces 
        Console.WriteLine();
        Polynomial p1 = new Polynomial(sPoly1);
        Polynomial p2 = new Polynomial(sPoly2);
        Console.Write("Polynom 1 (simplified and sorted) is ");
        Console.WriteLine(p1);
        Console.Write("Polynom 2 (simplified and sorted) is ");
        Console.WriteLine(p2);
        Console.WriteLine();
        Console.Write("Sum of two polynoms. Result is: ");
        Console.WriteLine(p1 + p2);
        Console.Write("Subtraction of two polynoms. Result is: ");
        Console.WriteLine(p1 - p2);
        Console.Write("Multiplication of two polynoms. Result is: ");
        Console.WriteLine(p1 * p2);
    }
}