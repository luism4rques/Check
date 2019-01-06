
namespace ValidationCheck
{
    public static class CheckBooleanExtension
    {
        public static Check True(this Check check, bool value)
        {
            check.Value = value;
            return check;
        }
    }
}