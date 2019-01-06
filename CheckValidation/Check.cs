using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidationCheck
{
    public class Check
    {
        private TypeOfCheck _typeOfCheck;
        private bool? _value;
        private string _msg;
        private IList<Result> _lstResult;

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
            set {
                if(_value != null) throw new Exception("The validation has declared two times.");
                _value = value;
            }
            get { 
                if(_value == null) throw new Exception("The validation must be declared.");
                return _typeOfCheck == TypeOfCheck.Is ? _value.Value : !_value.Value;
            }
        }

        public string Msg {
            set {
                if(_msg != null) throw new Exception("The msg has declared two times.");
                _msg = value;
            }
            get => _msg;
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