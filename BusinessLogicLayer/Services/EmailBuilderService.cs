using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmailBuilderService : IEmailBuilderService
    {
        private EmailBodyBuilderModel emailBodyBuilderModel;

        public void Init(EmailBodyBuilderModel emailBodyBuilderModel)
        {
            this.emailBodyBuilderModel = emailBodyBuilderModel;
        }

        public Task<string> BuildEmailBody()
        {
            StringBuilder message = new StringBuilder();

            string header = $"\t Hello dear {emailBodyBuilderModel.Name}, we are happy to tell you that you have passed the next stage of the internship {emailBodyBuilderModel.SandboxName}";

            message.Append(header);

            string text = $"\n\tIf u want continue your adventure you should download test task from" +
                $"\n{emailBodyBuilderModel.TestTaskDownloadUrl}" +
                $"\n\tAfter that you should upload your solution at" +
                $"\n{emailBodyBuilderModel.TestTaskUploadUrl}" +
                $"\n\tYou have {emailBodyBuilderModel.TestTaskLifeTime} hours to upload your solution.";

            message.Append(text);

            string signature = $"\n\n\tWith best wishes, your Exadel Education Department";

            message.Append(signature);

            return Task.FromResult(message.ToString());
        }

        public Task<string> BuildEmailSubject()
        {
            StringBuilder subject = new StringBuilder($"Hello {emailBodyBuilderModel.Name}, you will go to the next stage in {emailBodyBuilderModel.SandboxName}");

            return Task.FromResult(subject.ToString());
        }
    }
}
