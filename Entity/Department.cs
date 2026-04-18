using System.ComponentModel.DataAnnotations;
namespace entityframeworkcodebaseapproachwithdiftdb.Entity
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
    }
}
