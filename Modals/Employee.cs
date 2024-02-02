using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeInfo.Modals
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Department { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
