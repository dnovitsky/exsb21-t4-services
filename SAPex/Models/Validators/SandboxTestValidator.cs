using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Models.Validators
{
    public class SandboxTestValidator : AbstractValidator<SandboxTestViewModel>
    {
        public SandboxTestValidator()
        {
            RuleFor(sandbox => sandbox.Name).NotEmpty().WithMessage("Name can t be empty");
        }
    }
}
