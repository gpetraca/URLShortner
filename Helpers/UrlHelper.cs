using System;
using System.Web;
using System.Web.Mvc;

namespace UrlShortner.Helpers
{
    public static class UrlHelper
    {
        public static string ShortURL(this HtmlHelper helper, HttpRequestBase request, string hash)
        {
            string shortURL = request.Url.Scheme + "://" + request.Url.Authority + "/" + hash;
            return String.Format("<a target='_blank' href='{0}'>{0}</a>", shortURL);
        }
        public static string RelativeTime(this HtmlHelper helper, DateTime date)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            if (delta < 0)
            {
                return "ainda não";
            }
            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "um segundo atrás" : ts.Seconds + " segundos atrás";
            }
            if (delta < 2 * MINUTE)
            {
                return "um minuto atrás";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " minutos atrás";
            }
            if (delta < 90 * MINUTE)
            {
                return "uma hora atrás";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " horas atrás";
            }
            if (delta < 48 * HOUR)
            {
                return "ontem";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " dias atrás";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "um mês atrás" : months + " meses atrás";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "um ano atrás" : years + " anos atrás";
            }
        }
    }
}