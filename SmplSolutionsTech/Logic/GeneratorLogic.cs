using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Logic
{
    public class GeneratorLogic : IGeneratorLogic
    {
        public async Task<CodeGeneratorForm> GetOpenGeneratorModel()
        {
            return new CodeGeneratorForm();
        }
    }
}
