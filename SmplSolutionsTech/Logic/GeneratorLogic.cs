using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Logic
{
    public class GeneratorLogic : IGeneratorLogic
    {
        public async Task<OpenCodeGeneratorForm> GetOpenGeneratorModel()
        {
            return new OpenCodeGeneratorForm();
        }
    }
}
