using Microsoft.AspNetCore.Mvc;
using Weight_Watchers.core.DTO;
using Weight_Watchers.core.interfaces_BAL;
using Weight_Watchers.core.Response;

namespace Project_Net.core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightWatchersController : ControllerBase
    {
        ISubscriberService _subscriberService;
        ICardService _cardService;
        public WeightWatchersController(ISubscriberService subscriberService, ICardService cardService)
        {
            _subscriberService = subscriberService;
            _cardService = cardService;
        }
       

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneral<int?>>> Login(string password,string email)
        {
            BaseResponseGeneral<int?> response=new BaseResponseGeneral<int?>();
            response = await _cardService.Login(password, email);
            if(response.Data==null)
                return Unauthorized(response);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<BaseResponseGeneral<SubscriberAndCard>>> GetById(int id)
        {
            BaseResponseGeneral<SubscriberAndCard> response = new BaseResponseGeneral<SubscriberAndCard>();
            response = await _cardService.GetById(id);
            if (response.Succed == false)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Register(SubscriberDTO s)
        {
            BaseResponse b = await _subscriberService.Register(s);
            if (b.Succed==false)
                return Conflict(b);
            return Ok(b);
        }
    }
}