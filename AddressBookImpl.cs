using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBook
{
    public class AddressBookImpl:IAddressBook
    {
        string firstName;
        string lastName;
        string address;
        string city;
        string state;
        long phone_Number;
        string email;
        bool isPresent;
        int zip;
        string pattern;
        string temp;
        string message="";
        Regex regex;
        List<ContactPers> arrayList=new List<ContactPers>();
        
       
        //Method To update a Person
        public void editPerson()
        {
            Console.WriteLine("Enter the Name ");
            string name = Console.ReadLine();
            foreach (ContactPers person in arrayList)
            {
                if (person.FirstName.Equals(name))
                {
                    addPerson();
                    return;
                }
            }
            try
            {
                throw new AddressBookInvalidUserException("!!!!!INVALID USER!!!!!");
            }
            catch (Exception e) { Console.WriteLine(e.ToString); }

        }


    }
}
