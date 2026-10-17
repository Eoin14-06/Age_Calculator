namespace Age_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your date of birth (yyyy-MM-dd):");
            string input = Console.ReadLine();
            DateTime dateOfBirth = DateTime.Parse(input);
            Console.WriteLine("Enter your time of birth (HH:mm):");
            DateTime timeOfBirth = DateTime.Parse(Console.ReadLine());
            int Years = new AgeCalculator().Years(dateOfBirth);
            int Months = new AgeCalculator().Months(dateOfBirth);
            int Days = new AgeCalculator().Days(dateOfBirth);
            int Hours = new AgeCalculator().Hours(timeOfBirth);
            int minutes = new AgeCalculator().Minutes(timeOfBirth);
            double seconds = new AgeCalculator().Total_seconds(dateOfBirth, timeOfBirth);
            Console.WriteLine($"You are {Years} years, {Months} months, {Days} days, {Hours} hours and {minutes} minutes old!");
            Console.WriteLine($"This is equivalent to {seconds} seconds");

        }
    }
    class AgeCalculator
    {
        public int Years(DateTime DateOFBirth)
        {
            DateTime today = DateTime.Today;
            DateTime This_birthday = new DateTime(today.Year, DateOFBirth.Month, DateOFBirth.Day);
            if (This_birthday > today)
            {
                return today.Year - DateOFBirth.Year - 1;
            }
            else
            {
                return today.Year - DateOFBirth.Year;
            }

        }
        public int Months(DateTime DateOfBirth)
        {
            DateTime today = DateTime.Today;
            int months = today.Month - DateOfBirth.Month;
            if (months < 0)
            {
                months += 12;
            }
            return months;
        }
        public int Days(DateTime DateOfBirth)
        {
            DateTime today = DateTime.Today;
            int days = today.Day - DateOfBirth.Day - 1;
            int start_year = DateOfBirth.Year;
            if (days <0)
            {
                DateTime lastMonth = today.AddMonths(-1);
                days += DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month);
            }
            int last_leap = today.Year;
            while (last_leap % 4 != 0)
            {
                last_leap -= 1;
            }
            while (start_year < last_leap)
            {
                days += 1;
                start_year += 4;
            }
            return days;
        }
        public int Hours(DateTime TimeOfBirth)
        {
            DateTime current = DateTime.Now;
            int hours = current.Hour - TimeOfBirth.Hour - 1;
            if (hours < 0)
            {
                hours += 24;
            }
            return hours;
        }
        public int Minutes(DateTime TimeOfBirth)
        {
            DateTime current = DateTime.Now;
            int minutes = current.Minute - TimeOfBirth.Minute - 1;
            if (minutes < 0)
            {
                minutes += 60;
            }
            return minutes;
        }
        public double Total_seconds(DateTime DateofBirth, DateTime TimeOfBirth)
        {
            DateTime current = DateTime.Today;
            DateTime current_time = DateTime.Now;
            double Second_elapsed = (current - DateofBirth).TotalSeconds + ( current_time - TimeOfBirth).TotalSeconds;
            int last_leap = current.Year;
            int start_year = DateofBirth.Year;
            while (last_leap % 4 != 0)
            {
                last_leap -= 1;
            }
            while (start_year < last_leap)
            {
                Second_elapsed += 86400;
                start_year += 4;
            }
            return Second_elapsed;


        }
    }
}
