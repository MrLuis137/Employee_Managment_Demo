using namespace Enployee_Managment_Demo.Models
{
    public class Employee
    {
        [key]
        public int ID{get;set;}
        public string First_Name{get;set;}
        public string Last_Name{get;set;}
        public string Email{get;set;}
    }
}