using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Managment_Demo.Models
{
    public class EmployeeEditViewModel{
        public int ID{get;set;}
        public string First_Name{get;set;}
        public string Last_Name{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
        public decimal Pay{get; set;}
        public int PositionID{get;set;}
        public SelectList positions { get; set; }
    }
}
