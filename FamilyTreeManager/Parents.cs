using System;
using Inputs;

namespace FamilyTree
{
    public class Parents : Person
    {
        bool _hasWork;
        int _income;

        public bool HasWork
        {
            get
            {
                return _hasWork;
            }
            set
            {
                _hasWork = value;
            }
        }
        public int Income
        {
            get
            {
                return _income;
            }
            set
            {
                if (HasWork)
                {
                    _income = value;
                }
                else
                {
                    Console.WriteLine($"{Name} has no work!");
                    _income = 0;
                }
            }
        }

        public Parents()
           : base()
        {

        }

        public Parents(string name, string surname, int age, string gender)
           : base(name, surname, age, gender)
        {

        }

        public Parents(string name, string surname, int age, string gender, bool haswork, int income)
            : base(name, surname, age, gender)
        {
            HasWork = haswork;
            Income = income;
        }

        public override void InputPersonInformation()
        {
            base.InputPersonInformation();
            Console.Write("Has work(yes/no): ");
            HasWork = BoolInput.YesOrNo();
            Console.Write("Income: ");
            Income = NumbersInput.Integer("Income: ");
        }

        public override void ShowAllPersonInformation()
        {
            base.ShowAllPersonInformation();
            Console.WriteLine($"Does {Name} has work? -{HasWork}");
            Console.WriteLine($"Income: {Income}$");
        }
    }
}
