using System;

namespace chocolate_review
{
    class ValidatedInput
    {
        public static string ReadString(string prompt, int minLength, int maxLength)
        {
            string comment = "";
            Console.Write("prompt");
            comment = Console.ReadLine();
            while (comment.Length < minLength || comment.Length > maxLength)
            {
                Console.Write(prompt);
                comment = Console.ReadLine();
            }
            return comment;
        }

        public static int ReadInt (string prompt)
        {
            int value = 0;
            Console.Write("prompt");
            while(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a number  ");
            }
            return value;
        }
    }
}