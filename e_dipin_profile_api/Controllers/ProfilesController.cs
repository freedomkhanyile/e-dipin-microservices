using Microsoft.AspNetCore.Mvc;
using e_dipin_profile_api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace e_dipin_profile_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ILogger<ProfilesController> _logger;

        public ProfilesController(ILogger<ProfilesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetProfiles());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var profiles = GetProfiles();
            var item = profiles.Find(x => x.Id == id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserProfile model)
        {
            var profiles = GetProfiles();
            profiles.Add(model);
            return Ok(Get());
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserProfile model)
        {
            var profiles = GetProfiles();
            var item = profiles.Find(x => x.Id == id);
            if (item == null) return BadRequest();
            item.Email = model.Email;
            item.Cellphone = model.Cellphone;
            item.IsDeleted = model.IsDeleted;

            return Ok(item);
        }

        private List<UserProfile> GetProfiles()
        {
            return new List<UserProfile>() {
                new UserProfile()
                {
                    Id = "1",
                    Email = "Busani Zulu",
                    Cellphone = "+2114454214",
                    Password = null,
                    IsDeleted = false
                },
                new UserProfile()
                {
                    Id = "2",
                    Email = "Velile Zondo",
                    Cellphone = "+21145457845",
                    Password = null,
                    IsDeleted = false
                },
                new UserProfile()
                {
                    Id = "3",
                    Email = "Bongani Zulu",
                    Cellphone = "+21124548754",
                    Password = null,
                    IsDeleted = false
                }
            };
        }
    }
}