using System.ComponentModel.DataAnnotations;

namespace Employee_Managment_Demo.Models{
    public class Position
    {
        [Key]
        public int ID{get;set;}

        public string Position_Name{get;set;}
    }
}