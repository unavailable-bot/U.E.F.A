using System;

namespace UEFA
{
    internal class Program
    {
        private static int userAge;
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("U.E.F.A |Underground Elite Fist Arena| ---> PEGI 12");
                    Console.Write("Enter your date of birth (dd/mm/yyyy): ");
            
                    string dateOfBirth = Console.ReadLine();
                    if (dateOfBirth?.Length != 10)
                    {
                        ResultMessage("Invalid date format");
                        continue;
                    }

                    CalculateAge(dateOfBirth);
                    if (userAge < 12)
                    {
                        return;
                    }

                    ResultMessage("Access granted!");
                }
                catch (Exception e)
                {
                    ResultMessage($"Error message: {e.Message}");
                }
            }
        }
        
        private static void CalculateAge(string dob)
        {
            int day = int.Parse(dob.Substring(0, 2));
            int month = int.Parse(dob.Substring(3, 2));
            int year = int.Parse(dob.Substring(6, 4));
            
            DateTime birthDate = new DateTime(year, month, day);
            DateTime today = DateTime.Today;
            userAge = today.Year - birthDate.Year;

            if (birthDate.Month < today.Month || (birthDate.Month == today.Month && birthDate.Day < today.Day))
            {
                userAge--;
            }
        }

        private static void ResultMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}