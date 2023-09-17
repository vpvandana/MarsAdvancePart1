using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancePart1.Model
{
    public class UserInformationModel
    {

        private String Email;
        private String Password;
        private String FirstName;


        public void setEmail(String Email)
        {
            this.Email = Email;
        }


        public String getEmail()
        {
            return Email;
        }


        public void setPassword(String Password)
        {
            this.Password = Password;
        }

        public String getPassword()
        {
            return Password;
        }


        public void setFirstName(String FirstName)
        {
            this.FirstName = FirstName;
        }


    }
}
