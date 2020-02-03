using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Reflection
{
    public static class Reflection
    {
        public static void Set(this object @object, string propertyName, object value)
        {
            @object.GetType().GetProperty(propertyName).SetValue(@object,value);
        }
        //public static dynamic Get(this object Object)
        //{

        //}
    }
}
