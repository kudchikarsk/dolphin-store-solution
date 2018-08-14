using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.TonerJob.Data
{
    class TonerJobContext : DbContext
    {
        public TonerJobContext():base("name=DolphinContext")
        {

        }
    }
}
