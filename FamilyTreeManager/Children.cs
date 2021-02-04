using System;
using Inputs;

namespace FamilyTree
{
    public class Children : Person
    {
        bool _attendSchool;
        string _hobby;

        public bool AttendSchool
        {
            get
            {
                return _attendSchool;
            }
            set
            {
                _attendSchool = value;
            }
        }
        public string Hobby
        {
            get
            {
                return _hobby;
            }
            set
            {
                _hobby = value;
            }
        }

        public Children()
           : base()
        {

        }

        public Children(string name, string surname, int age, string gender)
          : base(name, surname, age, gender)
        {

        }

        public Children(string name, string surname, int age, string gender, bool attendSchool, string hobby)
          : base(name, surname, age, gender)
        {
            AttendSchool = attendSchool;
            Hobby = hobby;
        }

        public override void InputPersonInformation()
        {
            base.InputPersonInformation();
            Console.Write("Attend school(yes/no)");
            AttendSchool = BoolInput.YesOrNo();
            Console.Write("Hobby: ");
            Hobby = StringInput.InputStringWithLettersOnly("Hobby: ");
        }

        public override void ShowAllPersonInformation()
        {
            base.ShowAllPersonInformation();
            Console.WriteLine($"Does {Name} attend school? -{AttendSchool}");

        }
    }
}
