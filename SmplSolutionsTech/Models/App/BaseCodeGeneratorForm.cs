namespace SmplSolutionsTech.Models.App
{
    public class BaseCodeGeneratorForm
    {
        public int Language { get; set; }
        public List<int> Languages { get; set; }
        public List<ModelGeneratorModel> Properties { get; set; }
    }
}
