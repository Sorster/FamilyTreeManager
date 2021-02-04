using System;
using System.Collections.Generic;
using Inputs;

namespace FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to family tree creator!");
            Console.ResetColor();

            List<Person> People = new List<Person>();
            Person person = new GrandParents();
            People.Add(person);

            Console.WriteLine("Please input the main person");
            person.InputPersonInformation();
            Console.Clear();

            Person currentPerson = person;

            bool isGrandParent = false;
            bool isParent = false;

            do
            {
                Console.WriteLine("Current person: ");
                currentPerson.ShowPersonIdAndName();

                ShowMenu();
                MenuPoints menuPoint = InputMenu();

                if (menuPoint == MenuPoints.Exit) break;

                if (menuPoint == MenuPoints.SelectMainPerson)
                {
                    currentPerson = person;
                }

                isGrandParent = (currentPerson is GrandParents);
                isParent = (currentPerson is Parents);

                switch (menuPoint)
                {
                    case MenuPoints.ShowPerson:
                        {
                            currentPerson.ShowAllPersonInformation();
                            break;
                        }
                    case MenuPoints.SelectPerson:
                        {
                            int condition = 0;
                            Console.Write("ID: ");
                            currentPerson = SelectPerson(People, ref condition);

                            if (condition == 1)
                            {
                                Console.WriteLine("Selection failed!");
                                goto case MenuPoints.SelectMainPerson;
                            }
                            else
                            {
                                Console.WriteLine("Selection complete!");
                                break;
                            }
                        }
                    case MenuPoints.AddWife_Husband:
                        {
                            if (currentPerson.Partner != null)
                            {
                                Console.WriteLine($"{currentPerson.Name} can have one partner only!");
                                break;
                            }

                            AddPartner(People, currentPerson, isGrandParent, isParent);
                            break;
                        }
                    case MenuPoints.AddChildren:
                        {
                            AddChild(People, currentPerson, isGrandParent, isParent);
                            break;
                        }
                    case MenuPoints.ShowTree:
                        {
                            currentPerson = person;
                            ShowTree(currentPerson);
                            break;
                        }
                    case MenuPoints.SelectMainPerson:
                        {
                            currentPerson = person;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown command!");
                            Console.ResetColor();
                            break;
                        }
                }

                Console.WriteLine("Input any key to continue the program...");
                Console.ReadKey();
                Console.Clear();

            } while (true);
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---------Menu---------");
            Console.ResetColor();
            Console.WriteLine("1 - Show all information about selected person");
            Console.WriteLine("2 - Select person(by id)");
            Console.WriteLine("3 - Add wife/husband");
            Console.WriteLine("4 - Add children");
            Console.WriteLine("5 - Show tree");
            Console.WriteLine("6 - Select the main person");
            Console.WriteLine("7 - Exit");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Command: ");
            Console.ResetColor();
        }

        static MenuPoints InputMenu()
        {
            int condition;
            condition = NumbersInput.Integer("Menu point: ");
            return (MenuPoints)condition;
        }

        enum MenuPoints
        {
            ShowPerson = 1,
            SelectPerson,
            AddWife_Husband,
            AddChildren,
            ShowTree,
            SelectMainPerson,
            Exit
        }

        static void AddPartner(List<Person> People, Person currentPerson, bool isGrandParent, bool isParent)
        {
            Person partner = TypeOfPartner(isGrandParent, isParent);

            partner.InputPersonInformation();
            currentPerson.Partner = partner;
            People.Add(partner);
        }

        static Person TypeOfPartner(bool isGrandParent, bool isParent)
        {
            if (isGrandParent)
            {
                return new GrandParents();
            }

            else if (isParent)
            {
                return new Parents();
            }

            else
            {
                return new Children();
            }
        }

        static void AddChild(List<Person> People, Person currentPerson, bool isGrandParent, bool isParent)
        {
            Person child = TypeOfChildren(currentPerson, isGrandParent, isParent);

            if (child == null)
            {
                Console.WriteLine($"{currentPerson.Name} is granchildren!");
                return;
            }
            else
            {
                child.InputPersonInformation();
                currentPerson.Children.Add(child);
                People.Add(child);
            }
        }

        static Person TypeOfChildren(Person currentPerson, bool isGrandParent, bool isParent)
        {
            if (isGrandParent)
            {
                return new Parents();
            }

            if (isParent)
            {
                return new Children();
            }

            else
            {
                return null;
            }
        }

        static Person SelectPerson(List<Person> People, ref int condition)
        {
            int selectingId = InputId();

            Person temproraryPerson = null;
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].ShowPersonId() == selectingId)
                {
                    temproraryPerson = People[i];
                }
            }

            if (temproraryPerson == null)
            {
                Console.WriteLine("Wrong id!");
                condition = 1;
                return null;
            }
            else
            {
                return temproraryPerson;
            }
        }

        static int InputId()
        {
            int selectingID;
            selectingID = NumbersInput.Integer("Id: ");
            return selectingID;
        }

        static void ShowTree(Person currentPerson)
        {
            Console.WriteLine("Grandparents: ");
            currentPerson.ShowPersonIdAndName();
            Console.WriteLine();

            if (currentPerson.Partner != null)
            {
                currentPerson.Partner.ShowPersonIdAndName();
                Console.WriteLine();
            }

            if (currentPerson.Children != null)
            {
                int parentsNumber = currentPerson.Children.Count;
                if (parentsNumber != 0)
                {
                    Console.WriteLine("\tParents:");

                    for (int i = 0; i < parentsNumber; i++)
                    {
                        Parents parent = (Parents)currentPerson.Children[i];

                        if (parent.Children != null)
                        {
                            int childrenNumber = parent.Children.Count;
                            if (childrenNumber != 0)
                            {
                                Console.WriteLine("\t\tChildren: ");

                                for (int j = 0; j < childrenNumber; j++)
                                {
                                    Children child = (Children)parent.Children[j];
                                    child.ShowPersonIdAndName();
                                    Console.WriteLine();
                                }
                            }
                        }

                        parent.ShowPersonIdAndName();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
