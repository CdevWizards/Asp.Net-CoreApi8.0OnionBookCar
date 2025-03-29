using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;

namespace Udemy.CarBook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values =_commentRepository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum Başarıyla Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi.");
        }
          [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _commentRepository.GetById(id);
            return Ok(value);
        }
              [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlogID(int id)
        {
            var value = _commentRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }
    }
}