using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfVodovoz.Enums;

namespace WpfVodovoz.Models
{
    public class Employee
    {
        public virtual int EmployeeId {  get; set; }
        public virtual string FullName { get; set; } = string.Empty;
        public virtual DateTime BirthDate {  get; set; } = new DateTime(1900, 1, 1);
        public virtual EmployeePosition Position { get; set;  }
    }

    
}
