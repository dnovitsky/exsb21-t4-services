using System;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractNameController<T> : AbstractController<T>
        where T : AbstractNameViewModel
    {
        protected override IActionResult PostValidation(T requestData)
        {
            if (IsValidData(requestData))
            {
                var responce = storageList.Find(item => item.Name == requestData.Name);
                if (responce == null)
                {
                    requestData.Id = Guid.NewGuid();
                    storageList.Add(requestData);

                    return Ok("record has been added");
                }

                return NotFound();
            }

            return Conflict();
        }

        protected override IActionResult PutValidation(Guid id, T requestData)
        {
            var responce = storageList.Find(FindByIdCallback(id));

            if (responce != null)
            {
                var index = storageList.IndexOf(responce);

                if (IsValidData(requestData))
                {
                    UpdateFields(responce, requestData);
                    storageList[index] = responce;

                    return Ok("record has been updated");
                }
                else
                {
                    return Conflict();
                }
            }

            return NotFound();
        }

        private bool IsValidData(T requestData)
        {
            return requestData.Name != null;
        }

        private void UpdateFields(T responce, T requestData)
        {
            responce.Name = requestData.Name != null ? requestData.Name : responce.Name;
        }
    }
}
