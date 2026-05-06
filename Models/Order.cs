using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfVodovoz.Models
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual DateTime OrderDate {  get; set; } = DateTime.Now;
        public virtual string OrderNum { get; set; }
        public virtual Double Amount {  get; set; } 
        public virtual Employee Employee { get; set; }
        public virtual Contractor Contractor {  get; set; }
    }
}
