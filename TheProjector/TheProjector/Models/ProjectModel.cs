using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheProjector.Models
{
    public class ProjectModel
    {

        public virtual int ProjectId { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string Remarks { get; set; }

        public virtual decimal Budget { get; set; }
    }
}