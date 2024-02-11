using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Request;
using Weight_Watchers.core.Response;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.core.interfaces_DAL
{
    public interface ISubscriberRepository
    {
       public  Task<BaseResponse> Register(Subscriber s,double h);
        public bool IsSubscriberExist(string email,string password);
    }
}
