using System;
namespace BookIt.Core.Application.Utilities
{
	public static class DateTimeUtilities
	{
        
        public static DateTime GetCurrentDateTime() => DateTime.UtcNow;

        public static DateTime AddTime(int time, TimeUnitEnum timeUnitEnum = TimeUnitEnum.Minute)
        {
            DateTime dateTime = GetCurrentDateTime();
            switch (timeUnitEnum)
            {
                case (TimeUnitEnum.Second):
                    dateTime = dateTime.AddSeconds(time);
                    break;
                case (TimeUnitEnum.Minute):
                    dateTime = dateTime.AddMinutes(time);
                    break;
                case (TimeUnitEnum.Hour):
                    dateTime = dateTime.AddHours(time);
                    break;

                case (TimeUnitEnum.Day):
                    dateTime = dateTime.AddDays(time);
                    break;
            }

            return dateTime;
        }
    }
}

