
  
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTask
{
    
      
        class Manager
        {
            public List<Person> people;

            public Manager()
            {
                people = new List<Person>();
               
                printMenu();
            }
            public void printMenu()
            {
                string[] menuOptions = new string[]
                {
                    "Print all users",
                    "Add user",
                    "Edit user",
                    "Search user",
                    "Remove user",
                    "Exit",
                };

                Console.WriteLine("Welcome to my management system!" + Environment.NewLine);

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + menuOptions[i]);
                }

                Console.Write("Enter your menu option: ");

                bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

                if (tryParse)
                {
                    if (menuOption == 1)
                    {
                        PrintAll();
                    }
                    else if (menuOption == 2)
                    {
                        AddPerson();
                    }
                    else if (menuOption == 3)
                    {
                        EditPerson();
                    }
                    else if (menuOption == 4)
                    {
                    SearchPerson();
                    }
                    else if (menuOption == 5)
                    {
                        RemovePerson();
                    }

                    if (menuOption >= 1 && menuOption <= menuOptions.Length - 1)
                    {
                        printMenu();
                    }
                }
                else
                {
                    OutputMessage("Incorrect menu choice."); 
                    printMenu();
                }
            }

            public bool isSystemEmpty()
            {
                if (people.Count == 0)
                {
                    Console.WriteLine("There are no users in the system.");
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void PrintAllUsers()
            {
            var gropedBySalary = people.OrderByDescending(x => x.salary).ToList();
                for (int i = 0; i < gropedBySalary.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + gropedBySalary[i].returnDetails());
                }
            }
            public void PrintAll()
            {
                StartOption("Printing all users:");

                if (!isSystemEmpty())
                {
                    PrintAllUsers();
                }

                FinishOption();

            }

            public Person returnPerson()
            {
                try
                {
                    Console.WriteLine("Please enter the employee ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the employee name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please enter the employee age");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the employee salary");
                    double salary = Convert.ToDouble(Console.ReadLine());

                if (people.Any(x => x.id == id))
                {
                    Console.WriteLine("Person with the same ID already present");
                }
                else
                {
                    if (age >= 0 && age <= 150)
                    {
                        return new Person(id, name, age, salary);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a sensible human age");
                    }
                }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return null;
            }
            public void AddPerson()
            {
                StartOption("Adding a user:");

                    Person person = returnPerson();

                    if (person != null)
                    {
                        people.Add(person);
                        Console.WriteLine("Successfully added a person.");
                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Something has went wrong.");
                        AddPerson();
                    }
                }
           
            public void EditPerson()
            {
                StartOption("Editing a user:");

              

                if (!isSystemEmpty())
                {
                    PrintAllUsers(); 

                    try
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.Write("Enter an index: ");
                        int indexSelection = Convert.ToInt32(Console.ReadLine()) -1;


                        if (indexSelection >= 0 && indexSelection <= people.Count - 1)
                        {
                            try
                            {
                                Console.WriteLine("Please enter the employee name");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter the employee age");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Please enter the employee salary");
                                double salary = Convert.ToDouble(Console.ReadLine());

                                people[indexSelection].name = name;
                                people[indexSelection].age = age;
                                people[indexSelection].salary = salary;

                            }
                            catch (Exception e)
                            {
                                OutputMessage("Something has went wrong." + e.Message);
                            Console.WriteLine("Please type e  to proceed or any key for exit to main menu");
                            string selected = Console.ReadLine().ToLower();
                            if(selected == "e")
                                EditPerson();
                            else
                                printMenu();
                            }
                        }
                        else
                        {
                            OutputMessage("Enter a valid index range.");
                            EditPerson();
                        }
                    }
                    catch (Exception e)
                    {
                        OutputMessage(e.Message);
                        printMenu();
                    }
                }
            else
            {
                OutputMessage("");
            }
        }
            public void SearchPerson()
            {
            int flag_searching;
                
                StartOption("Searching users:");

                if (!isSystemEmpty())
                {
                PrintAllUsers();

                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("Please type 1 for searching by NAME, \n 2 for searching who is ELDER \n or 3 for searching by ID");
                    
                try
                {
                    flag_searching = int.Parse(Console.ReadLine());

                    Console.Write("Enter please a searching value: ");
                    string searchInput = Console.ReadLine();

                    bool bFound = false;

                    if (!string.IsNullOrEmpty(searchInput))
                    {
                        if (flag_searching == 1)
                        {
                            var item = people.Find(x => x.name == searchInput);
                            Console.WriteLine(item.returnDetails());
                            bFound = true;
                        }
                        else if (flag_searching == 2)
                        {
                            try
                            {
                                var itemList = people.Where(x => x.age > int.Parse(searchInput));
                                foreach (var item in itemList)
                                {
                                    Console.WriteLine(item.returnDetails());
                                    bFound = true;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Please type a number for searching persons age who is elder");
                                SearchPerson();
                            }
                        }
                        else
                        {
                            var item = people.Find(x => x.id.ToString() == searchInput);
                            Console.WriteLine(item.returnDetails());
                            bFound = true;
                        }

                        if (!bFound)
                        {
                            Console.WriteLine("No users found with that value.");
                        }

                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Please enter a value.");
                        SearchPerson();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    SearchPerson();
                }                    
                }
            else
            {
                OutputMessage("");
            }

        }
        
        public void RemovePerson()
            {
                StartOption("Removing a user:");

                if (!isSystemEmpty())
                {
                    PrintAllUsers();

                    Console.Write("Enter an index: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    index--;


                    if (index >= 0 && index <= people.Count - 1)
                    {
                        people.RemoveAt(index);
                        Console.WriteLine("Successfully removed a person.");

                        FinishOption();
                    }
                    else
                    {
                        OutputMessage("Enter a valid index inside the range.");
                        RemovePerson();
                    }
                }
                else
                {
                    OutputMessage("");
                }
            }
            public void FinishOption()
            {
                Console.WriteLine(Environment.NewLine + "You have finished this option. Press <Enter> to return to the menu.");
                Console.ReadLine();
                Console.Clear();
            }
            public void StartOption(string message)
            {
                Console.Clear();
                Console.WriteLine(message + Environment.NewLine);
            }
            public void OutputMessage(string message)
            {
                if (message.Equals(string.Empty))
                {
                    Console.Write("Press <Enter> to return to the menu.");
                }
                else
                {
                    Console.WriteLine(message + " Press <Enter> to try again.");
                }
                Console.ReadLine();
                Console.Clear();
            }
           
           
          
        }
      
    
}
