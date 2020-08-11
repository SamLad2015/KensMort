using System;

namespace KensMort.Helpers
{
    public static class RandomDate
    {
        public static DateTime NextDate(DateTime endDate)
        {
            Random gen = new Random();
            int range = (endDate - DateTime.Today).Days;           
            return DateTime.Today.AddDays(gen.Next(range));
        }
    }
}