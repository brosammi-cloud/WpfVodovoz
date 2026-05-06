using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfVodovoz.Models
{
    public class Contractor
    {
        public virtual int СontractorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string INN { get; set; }
        //public virtual int EmployeeId {  get; set; }
        public virtual Employee Responsible { get; set; }
    }
}
