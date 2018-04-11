using System;
using Microsoft.Extensions.Caching.Memory;
namespace Secrets.Controllers
{
    [AttributeUsage(AttributeTargets.Method, Inherited=false, AllowMultiple=false)]
    public class MyAttribute : Attribute
    {
        
    }
    
}