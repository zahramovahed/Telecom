using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;


namespace Telecom.API.GlobalClasses
{
    public static class PersianDateTime
    {
        public static String GetPersionDateString(this DateTime dt)
        {
            PersianCalendar calendar = new PersianCalendar();
            int y = calendar.GetYear(dt);
            int m = calendar.GetMonth(dt);
            int day = calendar.GetDayOfMonth(dt);

            String sy = y.ToString();
            String sm = m.ToString();
            if (sm.Length == 1)
                sm = "0" + sm;
            String sd = day.ToString();
            if (sd.Length == 1)
                sd = "0" + sd;

            return sy + "/" + sm + "/" + sd;
        }

        public static String GetPersionDateString(DateTime? dt)
        {
            if (dt.HasValue == false)
                return "";

            return GetPersionDateString(dt.Value);
        }


        public static String GetPersionDateString_DayName(DateTime dt)
        {
            PersianCalendar calendar = new PersianCalendar();
            int y = calendar.GetYear(dt);
            int m = calendar.GetMonth(dt);
            int day = calendar.GetDayOfMonth(dt);

            var dayOfWeek =
                    calendar.GetDayOfWeek(dt);

            var dayName = "";
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    dayName = "جمعه";
                    break;
                case DayOfWeek.Saturday:
                    dayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    dayName = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    dayName = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    dayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    dayName = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    dayName = "پنجشنبه";
                    break;
            }

            return dayName;
        }
        public static String GetPersionDateString_DayMonth(DateTime dt)
        {
            PersianCalendar calendar = new PersianCalendar();
            int y = calendar.GetYear(dt);
            int m = calendar.GetMonth(dt);
            int day = calendar.GetDayOfMonth(dt);

            return m.ToString("D2") + "/" + day.ToString("D2");
        }

        public static String GetPersionSimpleDateString(DateTime dt)
        {
            PersianCalendar calendar = new PersianCalendar();
            int y = calendar.GetYear(dt);
            int m = calendar.GetMonth(dt);
            int day = calendar.GetDayOfMonth(dt);

            var dayOfWeek =
                    calendar.GetDayOfWeek(dt);

            var dayName = "";
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    dayName = "جمعه";
                    break;
                case DayOfWeek.Saturday:
                    dayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    dayName = "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    dayName = "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    dayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    dayName = "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    dayName = "پنجشنبه";
                    break;
            }

            var monthInYear = "";
            if (m == 1)
                monthInYear = "فروردین";
            else if (m == 2)
                monthInYear = "اردیبهشت";
            else if (m == 3)
                monthInYear = "خرداد";
            else if (m == 4)
                monthInYear = "تیر";
            else if (m == 5)
                monthInYear = "مرداد";
            else if (m == 6)
                monthInYear = "شهریور";
            else if (m == 7)
                monthInYear = "مهر";
            else if (m == 8)
                monthInYear = "آبان";
            else if (m == 9)
                monthInYear = "آذر";
            else if (m == 10)
                monthInYear = "دی";
            else if (m == 11)
                monthInYear = "بهمن";
            else if (m == 12)
                monthInYear = "اسفند";

            return dayName + day + monthInYear;
        }

        /// <summary>
        /// get day name
        /// </summary>
        /// <param name="dayIndex"> start from 1 to 7 </param>
        /// <returns></returns>
        public static String GetDayName(Int32 dayIndex)
        {
            String dayName = "";

            switch (dayIndex)
            {
                case 7:
                    dayName = "جمعه";
                    break;
                case 1:
                    dayName = "شنبه";
                    break;
                case 2:
                    dayName = "یکشنبه";
                    break;
                case 3:
                    dayName = "دوشنبه";
                    break;
                case 4:
                    dayName = "سه شنبه";
                    break;
                case 5:
                    dayName = "چهارشنبه";
                    break;
                case 6:
                    dayName = "پنجشنبه";
                    break;
            }

            return dayName;
        }

        public static Boolean ConvertPersionStringToDateTime(String str, ref DateTime res)
        {
            if (String.IsNullOrEmpty(str))
                return false;

            String[] vals = str.Split(new String[] { "/" }, StringSplitOptions.None);
            if (vals.Length != 3)
                return false;

            Int32 y = 0, m = 0, d = 0;
            try
            {
                y = Int32.Parse(vals[0]);
                m = Int32.Parse(vals[1]);
                d = Int32.Parse(vals[2]);
            }
            catch
            {
                return false;
            }

            DateTime dt;
            try
            {
                PersianCalendar calendar = new PersianCalendar();
                dt = calendar.ToDateTime(y, m, d, 0, 0, 0, 0);
            }
            catch
            {
                return false;
            }

            res = dt;

            return true;
        }


        public static string GetPersionDateTimeString(DateTime dateTime)
        {
            return GetPersionDateString(dateTime) + " " + dateTime.ToString("HH:mm");
        }

        public static string GetPersionDateTimeString(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
                return "";

            return GetPersionDateString(dateTime.Value) + " " + dateTime.Value.ToString("HH:mm");
        }

        public static string GetPersionDateTimeStringEmptyIfToday(DateTime? dateTime)
        {
            if (dateTime.HasValue == false)
                return "";

            if (dateTime.Value.Date != DateTime.Now.Date)
                return GetPersionDateString(dateTime.Value) + " " + dateTime.Value.ToString("HH:mm");
            else
            {
                return dateTime.Value.ToString("HH:mm");
            }
        }

        public static string GetTimeString(DateTime? date)
        {
            if (date.HasValue == false)
                return "";

            return date.Value.ToString("HH:mm");
        }

        public static int? GetHour(string time)
        {
            Int32? res = null;

            try
            {
                String[] hm = time.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                res = Convert.ToInt32(hm[0]);

                if (res < 0 || res > 23)
                    return null;

            }
            catch (Exception ax)
            {
                return null;
            }

            return res;
        }

        public static int? GetMin(string time)
        {
            Int32? res = null;

            try
            {
                String[] hm = time.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                if (hm.Length == 1)
                    return 0;

                res = Convert.ToInt32(hm[1]);

                if (res < 0 || res > 59)
                    return null;

            }
            catch (Exception ax)
            {
                Debug.WriteLine(ax.Message);
                return null;
            }

            return res;
        }



        public static DateTime? GetDateTime(string dateTime)
        {
            DateTime di = DateTime.Now;
            if (PersianDateTime.ConvertPersionStringToDateTime(dateTime, ref di) == false)
                return null;

            return di;
        }

        public static TimeSpan GetTimeValue(string time)
        {
            try
            {
                var str =
                    time.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                Int32 hour =
                    Convert.ToInt32(str[0]);
                Int32 min =
                    Convert.ToInt32(str[1]);
                TimeSpan timeSpan = new TimeSpan(hour, min, 0);

                return timeSpan;
            }
            catch (Exception ax)
            {
                return TimeSpan.MinValue;
            }
        }

        //for word and excel 
        // در فایل ورد و اکسل ترتیب تاریخ به هم میریزد
        public static string GetPersionDateString_DayMonth_Recursive(DateTime? date)
        {
            if (date == null)
                return "";

            var dt = date.Value;

            PersianCalendar calendar = new PersianCalendar();
            int y = calendar.GetYear(dt);
            int m = calendar.GetMonth(dt);
            int day = calendar.GetDayOfMonth(dt);

            return day.ToString("D2") + "/" + m.ToString("D2");
        }

        public static DateTime? ConvertPersianStringToDateTime(string date, string time)
        {
            DateTime? retValue = null;

            retValue = GetDateTime(date);

            if (retValue == null)
                return retValue;

            var t = GetTimeValue(time);

            retValue = new DateTime(retValue.Value.Year, retValue.Value.Month, retValue.Value.Day, t.Hours, t.Minutes, t.Seconds);

            return retValue;
        }

        public static DateTime? GetDateTimeOfDateAndTime(string date, string time)
        {
            DateTime? retValue = null;

            retValue = GetDateTime(date);
            if (retValue == null)
                return retValue;

            var hour = 0;
            var min = 0;
            try
            {
                var str = time.Split(':').ToList();

                hour = Int32.Parse(str[0]);

                if (str.Count > 1)
                    min = Int32.Parse(str[1]);
            }
            catch
            {

            }

            return new DateTime(retValue.Value.Year, retValue.Value.Month, retValue.Value.Day, hour, min, 0, 0);
        }
    }
}