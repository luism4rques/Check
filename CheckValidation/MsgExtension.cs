
namespace ValidationCheck
{
    public static class MsgExtension
    {
        public static Check Msg(this Check check, string msg)
        {
            check.Msg = msg;
            return check;
        }
    }
}