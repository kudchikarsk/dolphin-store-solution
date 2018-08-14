using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDatabaseManagement.Models
{
    public class Stock
    {
        public long Id { get; set; }

        public virtual IList<TonerPart> TonerParts { get; set; }
    }
}
