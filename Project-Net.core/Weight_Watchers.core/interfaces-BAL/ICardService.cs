using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Response;

namespace Weight_Watchers.core.interfaces_BAL
{
    public interface ICardService
    {
        public Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id);

        public Task<BaseResponseGeneral<int?>> Login(string password, string email);
    }
}
