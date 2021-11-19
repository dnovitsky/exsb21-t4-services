using FluentValidation;

namespace SAPex.Models.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbackViewModel>
    {
        public FeedbackValidator()
        {
            RuleFor(feedback => feedback.UserId).NotEmpty().WithMessage("Feedback should have user");
            RuleFor(feedback => feedback.RatingId).NotEmpty();
            RuleFor(feedback => feedback.CreateDate).NotNull();
            RuleFor(feedback => feedback.UserReview).NotNull();
        }
    }
}
