using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheProjector.Models
{
    public class PersonModel
    {

        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

    }
}