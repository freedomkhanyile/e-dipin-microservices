using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace e_dipin_post_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetPosts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var posts = GetPosts();
                var post = posts.Find(x => x.Id == id);
                return post != null ? Ok(post)
                                    : NotFound($"item {id} not found");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post model)
        {
            var posts = GetPosts();
            posts.Add(model);
            return Ok(posts);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Post model)
        {
            var posts = GetPosts();
            var item = posts.Find(x => x.Id == id);
            if (item == null) return BadRequest();
            item.Description = model.Description;
            item.Type = model.Type;
            item.CommentCount = model.CommentCount;
            item.InteractionCount = model.InteractionCount;
            return Ok(item);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>() {
                new Post() {
                    Id = "1",
                    Type = "Isimemezelo",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    CreateDate = DateTime.Now,
                    CommentCount = 10,
                    InteractionCount = 150,
                    UserId = 2
                },
                new Post() {
                    Id = "2",
                    Type = "Dip Date",
                    Description = "The next diping date is 25/08/2021 5AM - 3PM thank you.",
                    CreateDate = DateTime.Now,
                    CommentCount = 100,
                    InteractionCount = 500,
                    UserId = 1
                },
                new Post() {
                    Id = "3",
                    Type = "Isimemezelo",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book",
                    CreateDate = DateTime.Now,
                    CommentCount = 100,
                    InteractionCount = 500,
                    UserId = 3
                },
            };
        }

    }
}