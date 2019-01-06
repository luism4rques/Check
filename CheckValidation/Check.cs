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

        private void Clear(TypeOfCheck newTypeOfCheck) {
            _value = null;
            _msg = null;
            _typeOfCheck = newTypeOfCheck;
        }

        private void Save(){
            _lstResult.Add(new Result(Value, _msg));
        }

        public static Check Is => new Check(TypeOfCheck.Is);

        public static Check IsNot => new Check(TypeOfCheck.IsNot);

        public bool Value {
            set {
                if(_value != null) throw new Exception("The validation has declared two times."); //Test
                _value = value;
            }
            get { 
                if(_value == null) throw new Exception("The validation must be declared."); //Test
                return _typeOfCheck == TypeOfCheck.Is ? _value.Value : !_value.Value;
            }
        }

        public string Msg {
            set {
                if(_msg != null) throw new Exception("The msg has declared two times."); //Test
                _msg = value;
            }
            get => _msg;
        }

        public Check AndIs {
            get {
                Save();
                Clear(TypeOfCheck.Is);
                return this;
            }
        }

        public Check AndIsNot {
            get {
                Save();
                Clear(TypeOfCheck.IsNot);
                return this;
            }
        }

        public bool IsValid()
        {
            Save();
            return !_lstResult.Any(o => o.Value == false);
        }

        public bool Validate()
        {
            throw new NotImplementedException("");
        }
    }
}