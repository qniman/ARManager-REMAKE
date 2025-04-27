using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARManager_REMAKE.Classes.Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime CompletionDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
