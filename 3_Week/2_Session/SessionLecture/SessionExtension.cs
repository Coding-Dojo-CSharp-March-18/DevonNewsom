using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SessionLec
{
    public static class SessionExtension
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        // HttpContext.Session.GetObjectAsJson<List<string>>("names");
        public static T GetObjectAsJson<T>(this ISession session, string key)
        {
            string val = session.GetString(key);
            return val == null ? default(T) : JsonConvert.DeserializeObject<T>(val);
        }

    }
    
}