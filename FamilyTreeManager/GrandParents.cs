using System;
using Inputs;

namespace FamilyTree
{
    public class GrandParents : Person
    {
        int _pensionAmount;
        bool _hasGrayHair;

        public int PensionAmount
        {
            get
            {
                return _pensionAmount;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Pension can not be lesser than 0!");
                }
                else
                {
                    _pensionAmount = value;
                }
            }
        }
        public bool HasGrayHair
        {
            get
            {
                return _hasGrayHair;
            }
            set
            {
                _hasGrayHair = value;
            }
        }

        public GrandParents()
           : base()
        {

        }

        public GrandParents(string name, string surname, int age, string gender)
            : base(name, surname, age, gender)
        {

        }

        public GrandParents(string name, string surname, int age, string gender, int pensionAmount, bool hasGrayHair)
            : base(name, surname, age, gender)
        {
            PensionAmount = pensionAmount;
            HasGrayHair = hasGrayHair;
        }

        public override void InputPersonInformation()
        {
            base.InputPersonInformation();
            Console.Write("Pension: ");
            PensionAmount = NumbersInput.Integer("Pension");
            Console.Write("Gray hair(yes/no): ");
            HasGrayHair = BoolInput.YesOrNo();
        }

        public override void ShowAllPersonInformation()
        {
            base.ShowAllPersonInformation();
            Console.WriteLine($"Pension: {PensionAmount}$");
            Console.WriteLine($"Gray hair: {HasGrayHair}");
        }
    }
}
