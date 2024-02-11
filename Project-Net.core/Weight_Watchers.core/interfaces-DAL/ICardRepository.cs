using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Response;

namespace Weight_Watchers.core.interfaces_DAL
{
    public interface ICardRepository
    {
        //להוסיף MIDDLEWARE
        //GET
        public Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id);

        public Task<int?> Login(string password, string email);
        public bool IsCardExist(int cardId);
        public bool IsSubscriberExist(string email,string password);


    }
}
