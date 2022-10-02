using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmplSolutionsTech.Models.App
{
    public class OpenCodeGeneratorForm : BaseCodeGeneratorForm
    {
        [Required]
        [DisplayName("Model Name")]
        public string ModelName { get; set; }
        [DisplayName("Inherits From")]
        public string InheritsFrom { get; set; }
        [DisplayName("Interface")]
        public bool IsInterface { get; set; }
        [DisplayName("Member Access")]
        public int MemberAccess { get; set; } // not used AccessModifierEnum dropdown
        public int ReturnType { get; set; } // not used at this point

    }
}
