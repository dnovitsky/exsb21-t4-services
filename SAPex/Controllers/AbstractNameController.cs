using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using System;

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractNameController<T> : AbstractController<T> where T : AbstractNameViewModel
    {
        private bool IsValidData(T requestData)
        {
            return requestData.Name != null;
        }

        private void UpdateFields(T responce, T requestData)
        {
            responce.Name = requestData.Name != null ? requestData.Name : responce.Name;
        }

        protected override IActionResult PostValidation(T requestData)
        {
            if (this.IsValidData(requestData))
            {
                var responce = this.storageList.Find(item => item.Name == requestData.Name);
                if (responce == null)
                {
                    requestData.Id = Guid.NewGuid();
                    this.storageList.Add(requestData);

                    return Ok("record has been added");
                }

                return NotFound();
            }

            return Conflict();
        }
        protected override IActionResult PutValidation(Guid id, T requestData)
        {
            var responce = this.storageList.Find(this.FindByIdCallback(id));

            if(responce != null)
            {
                var index = this.storageList.IndexOf(responce);

                if(this.IsValidData(requestData))
                {
                    this.UpdateFields(responce, requestData);
                    this.storageList[index] = responce;

                    return Ok("record has been updated");
                } else
                {
                    return Conflict();
                }
            }

            return NotFound();
        }
    }
}
