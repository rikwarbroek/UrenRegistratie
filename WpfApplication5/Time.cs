using System;

namespace WpfApplication5
{
    class Time
    {
        public static string ConvertTime(int secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
            return answer;
        }
    }
}
