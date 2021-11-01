using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

namespace SAPex
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : AbstractController<RatingViewModel>
    {
        private void UpdateFields(RatingViewModel responce, RatingViewModel requestData)
        {
            responce.mark = requestData.mark == responce.mark ? responce.mark : requestData.mark;
            responce.skillId = requestData.skillId == responce.skillId ? responce.skillId : requestData.skillId;
        }
        
        protected override int PostValidation(RatingViewModel requestData)
        {
            var responce = this.storageList.Find(item => item.mark == requestData.mark && item.skillId == requestData.skillId);
            if (responce == null)
            {
                requestData.id = Guid.NewGuid();
                this.storageList.Add(requestData);

                return 200;
            }

            return 403;
        }
        protected override int PutValidation(Guid id, RatingViewModel requestData)
        {
            var responce = this.storageList.Find(this.FindByIdCallback(id));

            if (responce != null)
            {
                var index = this.storageList.IndexOf(responce);

                if (index < 0)
                {
                    return 405;
                } else
                {
                    this.UpdateFields(responce, requestData);
                    this.storageList[index] = responce;

                    return 200;
                }
            }

            return 403;
        }
    }
}
