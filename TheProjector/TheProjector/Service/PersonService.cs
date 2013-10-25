using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TheProjector.DAO;
using TheProjector.Models;

namespace TheProjector.Service
{
    public class PersonService
    {

        ProjectDAL projector = new ProjectDAL();

        public Object CreateUserResponse(PersonModel person)
        {
            var status = projector.CreatePerson(person);

            var data = new { status };

            return data;
        }

        public Object AuthenticateUserResponse(PersonModel person)
        {
            var status = projector.AuthenticateUser(person);

            if (status == "User found...")
            {
                FormsAuthentication.SetAuthCookie(person.UserName, false);
            }

            var data = new { status };

            return data;
        }

    }
}