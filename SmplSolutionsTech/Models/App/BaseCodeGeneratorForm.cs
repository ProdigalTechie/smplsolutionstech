using System.ComponentModel;

namespace SmplSolutionsTech.Models.App
{
    public class BaseCodeGeneratorForm
    {
        [DisplayName("Select Language")]
        public int Language { get; set; }
        public List<int> Languages { get; set; }
        public List<ModelGeneratorModel> Properties { get; set; }
    }
}
