using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidationCheck
{
    public class Check
    {
        private TypeOfCheck _typeOfCheck;

        //_value deve ser nullable
        public bool _value;
        public string _msg;
        public IList<Result> _lstResult;

        private Check() {}

        private Check(TypeOfCheck typeOfCheck) {
            _lstResult = new List<Result>();
            _typeOfCheck = typeOfCheck;
        }

        public static Check Is => new Check(TypeOfCheck.Is);
        public static Check IsNot => new Check(TypeOfCheck.IsNot);
        private bool GetValue() => _typeOfCheck == TypeOfCheck.Is ? _value : !_value;

        public Check AndIs{
            get {
                _lstResult.Add(new Result(){ Value = GetValue(), Msg = _msg});
                _msg = string.Empty;
                _value = false;
                _typeOfCheck = TypeOfCheck.Is;
                return this;
            }
        }

        public Check AndIsNot{
            get {
                _lstResult.Add(new Result(){ Value = GetValue(), Msg = _msg});
                _msg = string.Empty;
                _value = false;
                _typeOfCheck = TypeOfCheck.IsNot;
                return this;
            }
        }

//Verificar a ordem
//1. Deve ser definida a condição ex: True()
//2. Caso a condição não tenha sido definida com Message, deve ser chamado o metodo With("")
//3. Deve ser chamado o Validate() ou And()
// Regra todas as validações devem ser feitas com base nas propriedades da classe, ex: if _result = vazio e if _message = vazio

        public bool IsValid()
        {
            _lstResult.Add(new Result(){ Value = GetValue(), Msg = _msg});
            var result = _lstResult.FirstOrDefault(o => o.Value == false);
            return result == null ? true : false;
        }

        public bool Validate()
        {
            return false;
        }
    }
}