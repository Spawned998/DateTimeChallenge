namespace DateTimeChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string welcome = "Welcome to Nathan's attempt at Tim Corey's DateTime Challenge!";

            Console.WriteLine(welcome);

            DateTime currentDate = DateTime.Now;

            DateTime userDate = GetUserDate();

            TimeSpan duration = currentDate - userDate;

            Console.WriteLine($"--Difference--\nDays: {duration.Days}\nHours: {duration.Hours}\n Minutes: {duration.Minutes}");
        }

        internal static string GetUserTime()
        {
            string output = "";

            string message = "Please select time format:\n1.)12-Hour\n2.)24-Hour\n:";

            int userSelection = menuVerification(message, 1, 2);

            if (userSelection == 1)
            {
                Console.Write("Enter time(Ex. 12:01 AM): ");

                output = Console.ReadLine();

            }
            else if (userSelection == 2)
            {
                Console.Write("Enter time(Ex: 14:05): ");

                output = Console.ReadLine();

            }


            return output;
        }


        internal static DateTime GetUserDate()
        {
            string message = "Please select date format:\n1.)mm/dd/yyyy\n2.)dd/mm/yyyy\n:";

            int userSelection = menuVerification(message, 1, 2);

            DateTime output = new DateTime();

            if(userSelection == 1)
            {
                Console.Write("Enter date(mm/dd/yyyy): ");

                string date = Console.ReadLine();

                date += (" " + GetUserTime());

                output = DateTime.Parse(date, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if(userSelection == 2)
            {
                Console.Write("Enter date(dd/mm/yyyy): ");

                string date = Console.ReadLine();

                date += (" " + GetUserTime());

                output = DateTime.Parse(date, System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"));

            }

            return output;
        }

            

        internal static int menuVerification(string message, int firstSelection, int lastSelection)
        {
            int output = 0;
            bool isValid = false;

            do
            {
                Console.Write(message);

                string userEntry = Console.ReadLine();

                isValid = int.TryParse(userEntry, out output);

                if(isValid)
                {
                    if(output >= firstSelection && output <= lastSelection)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

            } while (isValid == false);

            return output;

        }
    }
}