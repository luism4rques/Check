using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidationCheck
{
    public class Check
    {
        private TypeOfCheck _typeOfCheck;
        public bool? _value;
        public string _msg;
        public IList<Result> _lstResult;
        
        private Check() {}

        private Check(TypeOfCheck typeOfCheck) {
            _lstResult = new List<Result>();
            _typeOfCheck = typeOfCheck;
        }

        private void ClearCurrentCheck(TypeOfCheck typeOfCheck) {
            _value = null;
            _msg = null;
            _typeOfCheck = typeOfCheck;
        }

        public static Check Is => new Check(TypeOfCheck.Is);

        public static Check IsNot => new Check(TypeOfCheck.IsNot);

        public bool Value {
            get { 
                if(_value == null) throw new Exception("The validation must be declared.");

                return _typeOfCheck == TypeOfCheck.Is ? _value.Value : !_value.Value;
            }
        }

        public Check AndIs {
            get {
                _lstResult.Add(new Result(Value, _msg));
                ClearCurrentCheck(TypeOfCheck.Is);
                return this;
            }
        }

        public Check AndIsNot {
            get {
                _lstResult.Add(new Result(Value, _msg));
                ClearCurrentCheck(TypeOfCheck.IsNot);
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
            _lstResult.Add(new Result(Value, _msg));
            var result = _lstResult.FirstOrDefault(o => o.Value == false);
            return result == null ? true : false;
        }

        public bool Validate()
        {
            return false;
        }
    }
}