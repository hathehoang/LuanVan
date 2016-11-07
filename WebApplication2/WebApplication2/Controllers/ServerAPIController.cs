using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [RoutePrefix("api/Server")]
    
    public class ServerAPIController : ApiController
    {
        private systemdbEntities db = new systemdbEntities();
        [HttpGet]
        [Route("getReward")]
        public ICollection<MerchantReward> getReward()
        {
            List<MerchantReward> result = new List<MerchantReward>();
            for(int i = 0; i < db.rewards.Count(); i++)
            {
                MerchantReward temp = new MerchantReward();
                temp.ChanceToGet = db.rewards.ToList()[i].ChanceToGet;
                temp.ChanceToRoll = db.rewards.ToList()[i].ChanceToRoll;
                temp.Id = db.rewards.ToList()[i].Id;
                temp.Name = db.rewards.ToList()[i].Name;
                temp.Status = db.rewards.ToList()[i].Status;
                temp.TimeRemain = db.rewards.ToList()[i].TimeRemain;
                result.Add(temp);
            }
            
            return result;
        }

        [HttpGet]
        [Route("getListPromotion")]
        public ICollection<dbPromotion> getPromotion()
        {
            List<dbPromotion> result = new List<dbPromotion>();
            for(int i = 0; i < db.promotions.Count(); i++)
            {
                dbPromotion temp = new dbPromotion();
                temp.DateBegin = db.promotions.ToList()[i].DateBegin;
                temp.DateEnd = db.promotions.ToList()[i].DateEnd;
                temp.Description = db.promotions.ToList()[i].Description;
                temp.Id = db.promotions.ToList()[i].Id;
                temp.IdSTORE = db.promotions.ToList()[i].IdSTORE;
                temp.Name = db.promotions.ToList()[i].Name;
                temp.Status = db.promotions.ToList()[i].Status;
                temp.listReward = new List<dbItemListReward>();
                int id = Convert.ToInt32(db.promotions.ToList()[i].IdListReward);
                var q = (from e in db.listrewards
                         join f in db.rewards on e.IdReward equals f.Id
                         where e.IdList == id
                         select new
                         {
                             ChancetoGet = f.ChanceToGet,
                             ChancetoRoll = f.ChanceToRoll,
                             Status = f.Status,
                             TimeRemain = f.TimeRemain,
                             Quantity = e.Quantity
                         }).ToList();
                for (int j = 0; j < q.Count(); j++)
                {
                    dbItemListReward tmp = new dbItemListReward();
                    tmp.ChanceToGet = q[j].ChancetoGet;
                    tmp.ChanceToRoll = q[j].ChancetoRoll;
                    tmp.quantity = Convert.ToInt32(q[j].Quantity);
                    tmp.Status = q[j].Status;
                    tmp.TimeRemain = q[j].TimeRemain;
                    temp.listReward.Add(tmp);
                }
                result.Add(temp);
            }

            return result;
        }
    }
}
