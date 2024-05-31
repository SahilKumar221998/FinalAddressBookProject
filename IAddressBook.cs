using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
   interface IAddressBook
    {
        void addPerson();
        void editPerson();
        void removePerson();
        void showUserDetails();
        string userCredentialsCheck(string name);
    }
}
