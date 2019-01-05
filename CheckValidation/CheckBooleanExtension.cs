
namespace ValidationCheck
{
    public static class CheckBooleanExtensions
    {
        public static Check True(this Check check, bool value)
        {
            check._value = value;
            return check;
        }
    }
}