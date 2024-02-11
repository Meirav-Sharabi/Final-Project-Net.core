using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Weight_Watchers.core.interfaces_BAL;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.core.Response;

namespace Weight_Watchers.service.BL
{
    public class CardService : ICardService
    {
        readonly IMapper _mapper;
        readonly ICardRepository _cardRepository;
        public CardService(IMapper mapper, ICardRepository cardRepository)
        {
            this._mapper = mapper;
            this._cardRepository = cardRepository;
        }
        public async Task<BaseResponseGeneral<SubscriberAndCard>> GetById(int id)
        {
            BaseResponseGeneral<SubscriberAndCard> result = new BaseResponseGeneral<SubscriberAndCard>();
            if (!_cardRepository.IsCardExist(id))
            {
                result.Succed = false;
                result.message = "Card is not Exist";
            }
            else
               result= await _cardRepository.GetById(id);
            return result;
        }

        public async Task<BaseResponseGeneral<int?>> Login(string password, string email)
        {
            BaseResponseGeneral<int?> BR = new BaseResponseGeneral<int?>();
       
            if(!IsValidEmail(email)||!IsValidPassword(password))
            {
                BR.Succed = false;
                BR.message = "the email or password inValid";
                BR.Data = 0;
                return BR;
            }
            if (!_cardRepository.IsSubscriberExist(email,password))
            {
                BR.Succed = false;
                BR.message = "subscriber is not found";
                BR.Data = 0;
                return BR;
            }
            BR.Succed = true;
            BR.message = "Enter Succesfuly";
            BR.Data = await _cardRepository.Login(password, email);
            return BR ;
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return true;
        }
    }
}
