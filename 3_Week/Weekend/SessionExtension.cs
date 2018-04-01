using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace weekend_session
{
    public static class Extensions
    {

        public static string ToAwesomeFormat(this DateTime dateTime, string formatter = "D")
        {
            return dateTime.ToString(formatter);
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // HttpContext.Session.SetString(key, value.CovertedToJsonString)
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string val = session.GetString(key);
            return val == null ? default(T) : JsonConvert.DeserializeObject<T>(val);
        }
    }
}
