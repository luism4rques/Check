
namespace ValidationCheck
{
    public class Result
    {
        public Result(bool value, string msg)
        {
            Value = value;
            Msg = msg;
        }
        public bool Value{ get; private set; }
        public string Msg { get; private set; }
    }
}