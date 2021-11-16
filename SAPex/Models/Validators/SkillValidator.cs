using FluentValidation;

namespace SAPex.Models.Validators
{
    public class SkillValidator : AbstractValidator<SkillViewModel>
    {
        public SkillValidator()
        {
            RuleFor(skill => skill.Name).NotEmpty().WithMessage("Skill name can't be empty");
        }
    }
}
