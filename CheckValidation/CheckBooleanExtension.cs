
namespace ValidationCheck
{
    public static class CheckBooleanExtension
    {
        public static Check True(this Check check, bool value)
        {
            //Verificar se já foi setado algum valor, caso já tenha sido, retornar Exception
            check._value = value;
            return check;
        }
    }
}