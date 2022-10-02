using SmplSolutionsTech.Models.App;

namespace SmplSolutionsTech.Logic
{
    public interface IGeneratorLogic
    {
        public Task<OpenCodeGeneratorForm> GetOpenGeneratorModel();
    }
}
