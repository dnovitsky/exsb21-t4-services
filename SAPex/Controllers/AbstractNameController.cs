using Microsoft.AspNetCore.Mvc;
using SAPex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex.Controllers
{
    [ApiController]
    public abstract class AbstractNameController<T> : AbstractController<T> where T : AbstractNameViewModel
    {
        protected abstract bool IsValidPostData(T requestData);
        protected abstract bool IsValidPutData(T requestData);
        protected abstract void UpdateFields(T responce, T requestData);

        protected override int PostValidation(T requestData)
        {
            if (this.IsValidPostData(requestData))
            {
                var responce = this.storageList.Find(item => item.name == requestData.name);
                if (responce == null)
                {
                    requestData.id = Guid.NewGuid();
                    this.storageList.Add(requestData);

                    return 200;
                }

                return 409;
            }

            return 400;
        }
        protected override int PutValidation(Guid id, T requestData)
        {
            var responce = this.storageList.Find(this.FindByIdCallback(id));

            if(responce != null)
            {
                var index = this.storageList.IndexOf(responce);

                if(this.IsValidPutData(requestData))
                {
                    this.UpdateFields(responce, requestData);
                    this.storageList[index] = responce;

                    return 200;
                } else
                {
                    return 400;
                }
            }

            return 404;
        }
    }
}
