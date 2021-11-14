using FluentValidation;

namespace SAPex.Models.Validators
{
    public class SandboxValidator : AbstractValidator<SandboxViewModel>
    {
        public SandboxValidator()
        {
            // RuleFor(sandbox => sandbox.Id).NotNull();
            RuleFor(sandbox => sandbox.Name).NotEmpty().WithMessage("Sandbox name can t be empty");
            RuleFor(sandbox => sandbox.Description).NotEmpty();
            RuleFor(sandbox => sandbox.MaxCandidates).NotNull();
            RuleFor(sandbox => sandbox.CreateDate).NotNull();
            RuleFor(sandbox => sandbox.StartDate).NotNull();
            RuleFor(sandbox => sandbox.EndDate).NotNull();
            RuleFor(sandbox => sandbox.StartRegistration).NotNull();
            RuleFor(sandbox => sandbox.EndRegistration).NotNull();
        }
    }
}
