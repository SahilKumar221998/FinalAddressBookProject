using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{


    public class AddressMain
    {
        IAddressBook addressBook = new AddressBookImpl();
        public void personChoices()
        {
            Console.WriteLine("---------------------WELCOME TO ADDRESS BOOK----------------------------");
            
            while (true)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("Please Select form the menu below:- ");
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("1.ADD\n2.UPDATE\n3.DELETE\n4.USER RECORDS\n5.LOGOUT");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------------------------------------------------------");
                if (choice == 5)
                    break;

               switch (choice)
                    {
                        case 1:addressBook.addPerson();break;
                        case 2: addressBook.editPerson(); break;
                        case 3: addressBook.removePerson(); break;
                        case 4: addressBook.showUserDetails(); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                
                
            }
        }
        static void Main(string[] args)
        {
            AddressMain address = new AddressMain();
            address.personChoices();


        }
    }
}
