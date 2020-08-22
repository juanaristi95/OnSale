using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnSale.Common.Entities
{
    public class Country
    {
        //Class Properties

        // Primary key - an identity field
        public int Id { get; set; }

        // Country name field (required) 
        [MaxLength(50, ErrorMessage = "The field {0} must contain less than {1} characters" )]
        [Required] 
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }

        [DisplayName("Departments Number")]
        public int DepartmentsNumber => Departments == null ? 0 : Departments.Count;

    }
}
