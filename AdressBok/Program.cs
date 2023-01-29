using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Adressbok;
                                            //LÄS PÅ : If and else statements + for loops + lists
                                            //SKRIV NER EN LISTA PÅ DET DU BEHÖVER ÖVA IN FÖR ATT KUNNA BYGGA DETTA UTANTILL

class Program
{
    private static List<Contact> contactList = new List<Contact>();         //In dymanic lists you can change the content while running the code.
    private static FileSave file = new FileSave();
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                contactList = JsonConvert.DeserializeObject<List<Contact>>(file.Read(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contactlist.json"))!;
            }
            catch { }

            PrintMainMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateContact(); break; 
                case 2: ViewAllContacts(); break;
                case 3: ViewSpecificContact(); break;
                case 4: DeleteSpecificContact(); break;
                case 5: Exit(); break;
                default: Console.WriteLine("Please answer by picking a number from 1 to 5. Try again."); break;
            }
        }
    }
    static void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n\n\n\t\t\tProgram closing down");
        Console.ReadKey();
        Environment.Exit(1);
    }
    static void DeleteSpecificContact()
    {
        Console.Clear();

        int num = 1;

        for (int i = 0; i < contactList.Count; i++)
        {
            Console.Write("Contact ");
            Console.WriteLine(" " + num + ". " + contactList[i].FirstName);

            num = num + 1;
        }
        Console.WriteLine("Select a contact to delete");

        int position;
        position = int.Parse(Console.ReadLine());
        position = position - 1;

        Console.WriteLine("Are you sure you want to delete this contact? (y/n)");
        string k = Console.ReadLine();

        k = k.ToUpper();

        if (k == "Y")
        {
            contactList.RemoveAt(position);
            Console.WriteLine("The contact has been deleted");
            Console.ReadKey();
            file.Save(@"C:\Users\Noah\Desktop\contactlist.json", JsonConvert.SerializeObject(contactList));

        }
        else
        {
            Console.WriteLine("The contact has not been deleted");
        }
       
    }
    static void ViewSpecificContact()
    {
        Console.Clear();

        int num = 1;

        for (int i = 0; i < contactList.Count; i++)
        {
            Console.WriteLine("Contact " + num + ": " + contactList[i].LastName);
            num++;
        }

        Console.Write("Enter the position of the contact number you want to see: ");
        int position;
        position = int.Parse(Console.ReadLine());
        position = position - 1;

        Console.Write("\nFirst Name: ");
        Console.WriteLine(contactList[position].FirstName);
        Console.Write("Last Name: ");
        Console.WriteLine(contactList[position].LastName);
        Console.Write("E-mail: ");
        Console.WriteLine(contactList[position].Email);
        Console.Write("Adress: ");
        Console.WriteLine(contactList[position].StreetAddress);
        Console.Write("ZipCode: ");
        Console.WriteLine(contactList[position].ZipCode);
        Console.Write("City: ");
        Console.WriteLine(contactList[position].City);
        Console.ReadKey();
    }
    static void ViewAllContacts()
    {
        Console.Clear();
        for (int i = 0; i < contactList.Count; i++)
        {
            Console.Write("FirstName: ");
            Console.WriteLine("\t" + contactList[i].FirstName);
            Console.Write("LastName: ");
            Console.WriteLine("\t" + contactList[i].LastName);
            Console.Write("E-mail: ");
            Console.WriteLine("\t" + contactList[i].Email);
            Console.Write("PhoneNumber: ");
            Console.WriteLine("\t" + contactList[i].PhoneNumber);
            Console.Write("Adress: ");
            Console.WriteLine("\t" + contactList[i].StreetAddress);
            Console.Write("Zipcode: ");
            Console.WriteLine("\t" + contactList[i].ZipCode);
            Console.Write("City: \t");
            Console.WriteLine("\t" + contactList[i].City);
            Console.Write("\n");
        }
        Console.ReadKey();
    }
    static void CreateContact()
    {
        Console.Clear();
        Contact Person = new Contact();

        Console.WriteLine("Please fill in the form below! \n");
        Console.Write("Firstname: ");
            Person.FirstName = Console.ReadLine();
        Console.Write("LastName: ");
            Person.LastName = Console.ReadLine();
        Console.Write("Email: ");
            Person.Email = Console.ReadLine();
        Console.Write("PhoneNr: ");
            Person.PhoneNumber = Console.ReadLine();
        Console.Write("Address: ");
            Person.StreetAddress = Console.ReadLine();
        Console.Write("Zipcode: ");
            Person.ZipCode = Console.ReadLine();
        Console.Write("City: ");
            Person.City = Console.ReadLine();
        contactList.Add(Person);

        file.Save(@"C:\Users\Noah\Desktop\contactlist.json", JsonConvert.SerializeObject(contactList));         //<<<<<<
    }
    static void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Address Book\n");
        Console.WriteLine("1. Create a contact");
        Console.WriteLine("2. View all contacts");
        Console.WriteLine("3. View a specific contact by index");
        Console.WriteLine("4. Delete a specific contact");
        Console.WriteLine("5. Exit");
        Console.Write("\nChoose one of the options above: ");
    }

}
