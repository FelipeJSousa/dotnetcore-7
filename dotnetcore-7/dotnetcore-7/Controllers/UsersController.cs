using AutoMapper;
using dotnetcore_7.Dto;
using dotnetcore_7.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore_7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _Mapper;

        private static readonly User[] Users = new User[]
        {
            new () 
            {
                Name = "Bob", 
                NickName = "b0bs",
                SureName = "Stuart"
            },
            new ()
            {
                Name = "Joseph", 
                NickName = "Flyer99",
                SureName = "Howard"
            },
            new ()
            {
                Name = "Philips", 
                NickName = "09Phalcon",
                SureName = "Holmes"
            },
            new ()
            {
                Name = "Wright", 
                NickName = "MasterC",
                SureName = "Cassidy"
            }
        };

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IMapper mapper)
        {
            _logger = logger;
            _Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var _ret = Users.Select(_Mapper.Map<UserGetAllDto>).OrderBy(x => x.NickName).ToArray();

            _logger.LogInformation($"Returned {_ret.Count()} users.");

            return _ret?.Any() == true ? Ok(_ret) : NoContent();
        }

        [HttpGet("Ranking")]
        public IActionResult GetAllRanking()
        {
            var _ret = Users.Select(_Mapper.Map<UserGetAllRankingDto>).OrderBy(x => x.Ranking).ToArray();

            _logger.LogInformation($"Returned {_ret.Count()} users.");

            return _ret?.Any() == true ? Ok(_ret) : NoContent();
        }
    }
}