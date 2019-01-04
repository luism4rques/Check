using System;

namespace ValidationCheck
{
    public class Check
    {
        private TypeOfCheck typeOfCheck;

        public static Check Is {
            get {
                var check = new Check();
                check.typeOfCheck = TypeOfCheck.Is;
                return check;
            }
        }

        public static Check IsNot{
            get {
                var check = new Check();
                check.typeOfCheck = TypeOfCheck.IsNot;
                return check;
            }
        }
    }
}