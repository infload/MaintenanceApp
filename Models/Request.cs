using System;

namespace MaintenanceApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int EquipmentId { get; set; }
        public int EmployeeId { get; set; }
        public string EquipmentName { get; set; }
        public string EmployeeName { get; set; }
    }
}