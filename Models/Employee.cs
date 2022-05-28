using System.ComponentModel.DataAnnotations;

namespace Employee_Managment_Demo.Models
{
    public class Employee
    {
        [Key]
        public int ID{get;set;}
        public string First_Name{get;set;}
        public string Last_Name{get;set;}
        public string Email{get;set;}
    }
}