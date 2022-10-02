using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using SmplSolutionsTech.Resources;

namespace SmplSolutionsTech.Helpers.Enums
{
    public enum OpenGeneratorLanguagesEnum
    {
        [Display(ResourceType = typeof(CodeGeneratorResource), Name = nameof(CodeGeneratorResource.CSharp))]
        CSharp = 0,
        SQL = 1,
        //JavaScript = 2,
    }
}
