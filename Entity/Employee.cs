using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
namespace entityframeworkcodebaseapproachwithdiftdb.Entity
{
    public class Employee
    {
        [Key]// key attribute is used to apply the primar key +identity to this empid column
        //Without [key] attribute if you apply Add-migration migrationname it will not work.primary key throws the error.
        //
        public int empid { get; set; }
        public string empname { get; set; }

        public int salary { get; set; }
    }
}
