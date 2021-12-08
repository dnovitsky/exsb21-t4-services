using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmailBuilderService : IEmailBuilderService
    {
        private EmailBodyBuilderModel model;

        public void Init(EmailBodyBuilderModel emailBodyBuilderModel)
        {
            this.model = emailBodyBuilderModel;
        }

        public Task<string> BuildEmailSubject()
        {
            var subject = $"Exadel Education Department: test task from {model.SandboxName} sandbox.";
            return Task.FromResult(subject);
        }

        public Task<string> BuildEmailBody()
        {
            StringBuilder sb = new StringBuilder();

            string header = $"Hello dear {model.Name},";
            sb.Append(header);

            sb.AppendFormat("<br>we are happy to tell you that you have passed the next stage of the internship {0}", model.SandboxName);
            sb.Append("<br><br>");
            sb.AppendFormat("If you want continue your adventure you should download test task from {0} .", model.TestTaskDownloadUrl);
            sb.Append("<br><br>");
            sb.AppendFormat("After that you should upload your solution at {0}", model.TestTaskUploadUrl);
            sb.Append("<br><br>");
            sb.AppendFormat("You have {0} hours to upload your solution.", model.TestTaskLifeTime);

            string signature = $"With best wishes,<br>your Exadel Education Department";
            sb.Append("<br><br><br><br>");
            sb.Append(signature);

            return Task.FromResult(sb.ToString());
        }
    }
}
