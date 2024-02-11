using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.core.Request;
using Weight_Watchers.core.Response;
using Weight_Watchers.data;
using Weight_Watchers.data.Entities;

namespace Weight_Watchers.service.DAL
{
    public class SubscriberRepository : ISubscriberRepository
    {
        readonly Weight_Watchers_Context _weightWatcherContext;
        public SubscriberRepository(Weight_Watchers_Context weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }

        public bool IsSubscriberExist(string email, string password)
        {
            Subscriber s = _weightWatcherContext.Subscriber.Where(x => x.Email.Equals(email)&&x.Password==password).FirstOrDefault();
            return s != null;
        }

        public async Task<BaseResponse> Register(Subscriber s,double h)
        {
            //Subscriber newSubscriber = new Subscriber()
            //{
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    Email = s.Email,
            //    Password = s.Password
            //};
            await _weightWatcherContext.Subscriber.AddAsync(s);
            await _weightWatcherContext.SaveChangesAsync();
            Card newCard = new Card()
            {
                SubscriberId = s.Id,
                Height = h,
                Weight = 0,
                BMI = 0,
                OpenDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
            _weightWatcherContext.Card.Add(newCard);
            await _weightWatcherContext.SaveChangesAsync();
            BaseResponse BR = new BaseResponse();
            BR.Succed = true;
            BR.message = "Added successfuly";
            return BR;
        }

    }
}
