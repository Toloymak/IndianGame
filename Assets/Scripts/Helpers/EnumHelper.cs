using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class EnumHelper
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum
            => Enum.GetValues(typeof(T)).Cast<T>();
    }
}