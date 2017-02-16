using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Sdk.Groove.Models.Extensions
{
    public static class DoubleExtensions
    {
        public static DateTime UnixTimeStampToDateTime(this double unixTimeStamp)
        {
            DateTime UnixDate = new DateTime(1970, 1, 1, 0, 0, 0);
            Double todayDateTimestamp = Convert.ToDouble((DateTime.UtcNow - UnixDate).TotalSeconds);
            Double totalOffset = todayDateTimestamp + unixTimeStamp;

            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(totalOffset).ToLocalTime();
            return dtDateTime;
        }
    }
}
