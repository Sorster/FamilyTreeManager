using System;
using System.Collections.Generic;
using Inputs;

namespace FamilyTree
{
    public class Person
    {
        public List<Person> Children = new List<Person>();
        public Person Partner { get; set; }

        static int _countId;
        int _id;
        string _name;
        string _surname;
        int _age;
        string _gender;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (Age >= 0)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Age can not be lesser than 0!");
                }
            }
        }
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        public Person()
        {
            ID = _countId;
            _countId++;
        }

        public Person(string name, string surname, int age, string gender)
        {
            _countId++;
            ID = _countId;
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        public int ShowPersonId()
        {
            return ID;
        }

        public virtual void InputPersonInformation()
        {
            Console.Write("Name: ");
            Name = StringInput.InputStringWithLettersOnly("Name: ");
            Console.Write("Surname: ");
            Surname = StringInput.InputStringWithLettersOnly("Surname: ");
            Console.Write("Age: ");
            Age = NumbersInput.Integer("Age");
            Console.Write("Gender: ");
            Gender = StringInput.InputGender();
        }

        public virtual void ShowAllPersonInformation()
        {
            ShowPersonIdAndName();
            Console.WriteLine($"{Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
        }

        public void ShowPersonIdAndName()
        {
            Console.WriteLine($"ID: {_id}");
            Console.WriteLine($"{Name}");
        }
    }
}
