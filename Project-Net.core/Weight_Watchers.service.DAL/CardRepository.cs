using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.Response;
using Weight_Watchers.data;
using Weight_Watchers.data.Entities;
using Weight_Watchers.core.interfaces_DAL;
namespace WeightWatchers.service.DAL
{
    public class CardRepository : ICardRepository
    {
        readonly Weight_Watchers_Context _weightWatcherContext;
        public CardRepository(Weight_Watchers_Context weightWatcherContext)
        {
            _weightWatcherContext = weightWatcherContext;
        }

        public bool IsCardExist(int cardId)
        {
            Card c = _weightWatcherContext.Card.Where(x => x.Id == cardId).FirstOrDefault();
            return c != null;
        }
        public bool IsSubscriberExist(string email,string password)
        {
            Subscriber s = _weightWatcherContext.Subscriber.Where(x => x.Email.Equals(email)&&x.Password== password).FirstOrDefault();
            return s != null;
        }

        public async Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id)
        {
            //הפונקציה הזאת מקבלת כבר את וד הכרטיס של בנ"א מסוים!!!!!
            try
            {
                //if(s == null) return null;
                Card c = _weightWatcherContext.Card.Where(x => x.Id == id).FirstOrDefault();
                BaseResponseGeneral<SubscriberAndCard> result = new BaseResponseGeneral<SubscriberAndCard>();
                Subscriber s = _weightWatcherContext.Subscriber.Where(x => x.Id == c.SubscriberId).FirstOrDefault();

                if (c != null)
                {
                    result.Data = new SubscriberAndCard();
                    result.Data.FirstName = s.FirstName;
                    result.Data.LastName = s.LastName;
                    result.Data.Height = c.Height;
                    result.Data.Weight = c.Weight;
                    result.Data.BMI = c.BMI;
                    result.Succed= true;
                    result.message = "Found by Id!!!!!";
                    return result;
                }
                else
                {
                    result.Succed = false;
                    result.message = "cannot get details!";
                }
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Failed return card Details;");
            }

        }
        public async Task<int?> Login(string password, string email)
        {
            Card c;
            Subscriber s = _weightWatcherContext.Subscriber.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (s.Password.Equals(password))
            {
                c = _weightWatcherContext.Card.Where(x => s.Id == x.SubscriberId).FirstOrDefault();
                return c.Id;
            }
            return null;
        }
    }
}
