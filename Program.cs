using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chocolate_review
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = @"C:\tmp\Reviews.mdf";
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Database not found: copying a fresh version");
                File.Copy("Reviews.mdf", filename);
                if (!Directory.Exists(@"C:\tmp")) ;

            }


            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\tmp\Reviews.mdf;Integrated Security=True";
            connection.Open();
            Console.WriteLine("Hooray! We have a database!");
            connection.Close();


            Console.WriteLine("Welcome to the Chocolate Bar Review admin console");
            Console.WriteLine("Main Menu:");
            Console.WriteLine("==========");

            bool running = true;

            while (running)
            {
                // keep looping until the user presses Q or q
                Console.WriteLine("1) Show all reviews");
                Console.WriteLine("2) Add new review");
                Console.WriteLine("3) Update review");
                Console.WriteLine("4) Delete review");
                Console.WriteLine("5) Show all users");
                Console.WriteLine("6) Add user");
                Console.WriteLine("7) Edit user");
                Console.WriteLine("8) Delete user");
                Console.WriteLine("Q) Quit");

                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Showing all reviews:");
                        string sql = "SELECT * FROM Reviews";
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            Review existingReview = new Review(r);
                            Console.WriteLine(existingReview);
                        }
                        connection.Close();
                        break;
                    case "2":
                        Console.WriteLine("Adding new review:");
                        Review newReview = new Review(
                            -1,
                            ValidatedInput.ReadInt("Enter chocolate bar ID:  "),
                            ValidatedInput.ReadInt("Enter user ID:  "),
                            ValidatedInput.ReadInt("Enter review score:  "),
                            ValidatedInput.ReadString("Enter comment:  ", 5, 255)
                            );
                        connection.Open();
                        sql = $"INSERT INTO Reviews (ChocolateBarID, UserID, Score, Comment) VALUES ({newReview.ChocolateBarID}";
                        break;
                    case "3":
                        Console.WriteLine("Which review would you like to update? (enter ID):");
                        break;
                    case "4":
                        Console.WriteLine("Which review would you like to delete? (enter ID):");
                        break;
                    case "5":
                        Console.WriteLine("Show all users");
                        break;
                    case "6":
                        Console.WriteLine("Please enter the new user's first name:");
                        break;
                    case "7":
                        Console.WriteLine("Which user do you want to edit? (enter ID):");
                        break;
                    case "8":
                        Console.WriteLine("Which user would you like to delete? (enter ID):");
                        break;

                    case "q":
                        running = false;
                        break;
                }
            }
        }
    }
}
