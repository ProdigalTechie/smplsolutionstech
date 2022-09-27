using System.Configuration;

namespace SmplSolutionsTech.Models.App
{
    public class ModelGeneratorModel
    {
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public string CustomDataTypeName { get; set; }
        public bool IsNullable { get; set; }
    }
}