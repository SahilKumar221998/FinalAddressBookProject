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
        
        //Method to add a contact person with required fields
        public void addPerson()
        {
            ContactPers addressBookMain;
            Console.WriteLine("Enter your firstName :-");
            firstName=Console.ReadLine();
            message = "Ex:-Sahil";
            pattern = "([A-Z]{1})([a-z]){3,20}$";
            regex = new Regex(pattern);
            firstName = userCredentialsCheck(firstName);
                while (true)
                {
                    isPresent = false;
                    foreach (ContactPers person in arrayList)
                    {
                        if (person.FirstName.Equals(firstName))
                        {
                        isPresent = true;
                        try
                        {
                            throw new AddressBookInvalidUserException("!!!!!!!!INVALID USER!!!!!!!!!!!!!");
                        }
                        catch(Exception e) { Console.WriteLine(e.ToString); }

                        }
                    }
                    if (isPresent == false)
                        break;
                    Console.WriteLine("Enter your firstName :-");
                    firstName = Console.ReadLine();
                }
            
            Console.WriteLine("Enter your lastName :- ");
            lastName = Console.ReadLine();
            message = "Ex:-Kumar";
            lastName = userCredentialsCheck(lastName);

            Console.WriteLine("Enter your address :- ");
            address=Console.ReadLine();
            message = "Ex:-Banglore,Karnataka,zip-421101";
            pattern = @"[\w][^\w]*$";
            regex = new Regex(pattern);
            address = userCredentialsCheck(address);
          

            Console.WriteLine("Enter your city :- ");
            city=Console.ReadLine();
            message = "Ex:-Banglore";
            pattern = @"[\w\W]{4,16}";
            regex = new Regex(pattern);
            city = userCredentialsCheck(city);
           
            Console.WriteLine("Enter your state :- ");
            state=Console.ReadLine() ;
            pattern = @"[\w\W]*";
            message = "Ex-Karnataka";
            regex = new Regex(pattern);
           state = userCredentialsCheck(state);

            Console.WriteLine("Enter six Digit Zip Code :- ");
            zip=Convert.ToInt32(Console.ReadLine());
            message = "Ex:-112345";
            pattern = @"[1-9]{1}[0-9]{5}$";
            regex = new Regex(pattern);
            temp=zip.ToString();
           temp= userCredentialsCheck(temp);
            zip = Convert.ToInt32(temp);

           Console.WriteLine("Eneter the phone_Number :- ");
            phone_Number=long.Parse(Console.ReadLine());
            message = "Ex:-7788901122";
            pattern = @"[6-9][0-9]{9}$";
            regex = new Regex(pattern);
            temp=phone_Number.ToString();
            temp = userCredentialsCheck(temp);
            phone_Number = long.Parse(temp);


            Console.WriteLine("Enter the email_Id :- ");
            email=Console.ReadLine();
            message ="Ex:-Sahilja@gmail.com";
            pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            regex=new Regex(pattern);
            email = userCredentialsCheck(email);

            //Adding all the details of user as One object
            ContactPers contactPerson=new ContactPers(firstName,lastName,address,city,state,zip,phone_Number,email);
            
            //Now adding that user to a list
            arrayList.Add(contactPerson);
            Console.WriteLine(contactPerson.ToString());
            Console.WriteLine("Saved Successfully........");

        }
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
        //Method to remove a person
        public void removePerson()
        {
            Console.WriteLine("Enter the Name ");
            string name = Console.ReadLine();
            foreach (ContactPers person in arrayList)
            {
                if (person.FirstName.Equals(name))
                {
                    arrayList.Remove(person);
                    Console.WriteLine("Removed " + person.FirstName);
                    return;
                }
            }
            try
            {
                throw new AddressBookInvalidUserException("!!!!!INVALID USER!!!!!");
            }
            catch(Exception e) { Console.WriteLine(e.ToString); }
        }
        //Method to show all users
        public void showUserDetails()
        {
            Console.WriteLine("Enter the name:- ");
            string name=Console.ReadLine();
            foreach (ContactPers fields in arrayList)
            {
                if (fields.FirstName.Equals(name))
                {
                    Console.WriteLine(fields.ToString());
                    Console.WriteLine("-------------------------------------------------------------------------");
                    return;
                }
                
            }
            try
            {
                throw new AddressBookInvalidUserException("!!!!!INVALID USER!!!!!");
            }
            catch (Exception e) { Console.WriteLine(e.ToString); }
        }
        public string userCredentialsCheck(string name)
        {
            while (true)
            {
                isPresent = false;
                if (!(regex.IsMatch(name)))
                {
                  
                    isPresent = true;
                    try
                    {
                    throw new AddressBookInvalidUserException($"!!INVALID USER!!||{message}");
                    }catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (isPresent == false)
                    break;
                Console.WriteLine("Enter Again with Correct Credentials :-");
                name= Console.ReadLine();
            }
            return name;
        }

    }
}
