using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weight_Watchers.core.interfaces_BAL;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.core.Response;
using Weight_Watchers.data.Entities;
using Weight_Watchers.core.DTO;

namespace Weight_Watchers.service.BL
{
    public class SubscriberService : ISubscriberService
    {
        readonly IMapper _mapper;
        readonly ISubscriberRepository _SubscriberRepository;
        public SubscriberService(IMapper mapper, ISubscriberRepository SubscriberRepository)
        {
            this._mapper = mapper;
            this._SubscriberRepository = SubscriberRepository;
        }
        public async Task<BaseResponse> Register(SubscriberDTO s)
        {
            BaseResponse b = new BaseResponse();
            if (_SubscriberRepository.IsSubscriberExist(s.Email,s.Password))
            {
                b.Succed = false;
                b.message = "Subscriber is exists!";
                return b;
            }
            return await _SubscriberRepository.Register(_mapper.Map<Subscriber>(s), s.Height);
        }
    }
}
