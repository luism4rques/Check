using System;

namespace ValidationCheck
{
    public class Check
    {
        private TypeOfCheck _typeOfCheck;
        public bool _value;

        private Check(){}

        public static Check Is {
            get {
                var check = new Check();
                check._typeOfCheck = TypeOfCheck.Is;
                return check;
            }
        }

        public static Check IsNot{
            get {
                var check = new Check();
                check._typeOfCheck = TypeOfCheck.IsNot;
                return check;
            }
        }

//Verificar a ordem
//1. Deve ser definida a condição ex: True()
//2. Caso a condição não tenha sido definida com Message, deve ser chamado o metodo With("")
//3. Deve ser chamado o Validate() ou And()
// Regra todas as validações devem ser feitas com base nas propriedades da classe, ex: if _result = vazio e if _message = vazio

        public bool Validate()
        {
            if(_typeOfCheck == TypeOfCheck.Is)
                return _value;

            return !_value;
        }
    }
}