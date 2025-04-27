using System;

namespace ARManager_REMAKE.Classes.Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int TotalCost { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}