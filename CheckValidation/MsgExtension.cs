
namespace ValidationCheck
{
    public static class MsgExtension
    {
        public static Check Msg(this Check check, string msg)
        {
            check._msg = msg;
            return check;
        }
    }
}