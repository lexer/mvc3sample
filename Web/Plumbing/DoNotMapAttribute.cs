using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Plumbing
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DoNotMapAttribute : Attribute
    {
    }
}