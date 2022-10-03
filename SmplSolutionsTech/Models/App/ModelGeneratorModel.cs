using System.ComponentModel;

namespace SmplSolutionsTech.Models.App
{
    public class ModelGeneratorModel
    {
        [DisplayName("Data Type")]
        public int CSharpDataTypeId { get; set; } //=> EnumHelper.GetSelectList(typeof(CSharpDataTypesEnum));// DataTypesEnum dropdown
        [DisplayName("Data Type")]
        public int SqlDataTypeId { get; set; } //=> EnumHelper.GetSelectList(typeof(SqlDataTypesEnum));
        [DisplayName("Domain Access")]
        public int DomainAccess { get; set; } //=> EnumHelper.GetSelectList(typeof(AccessModifierEnum)); // AccessModifierEnum dropdown
        public string Name { get; set; }
        //[DisplayName("Custom Data Type")]
        //public string DataTypeName { get; set; } // used for custom datatypes
        [DisplayName("Nullable")]
        public bool IsNullable { get; set; }
    }
}