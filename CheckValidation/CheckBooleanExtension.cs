
using System;

namespace ValidationCheck
{
    public static class CheckBooleanExtension
    {
        public static Check True(this Check check, bool value)
        {
            check.Value = value;
            return check;
        }

        public static Check True(this Check check, Func<bool> func)
        {
            check.Value = func();
            return check;
        }
    }
}