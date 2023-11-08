using ArticlesBack.Entities;
using ArticlesBack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticlesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ArticleController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        [HttpGet]
        public IEnumerable<ArticleModel> Get()
        {
            return this.dataContext.Articles.Select(a=> new ArticleModel
            { Author=a.Author,
            Id = a.Id,
            Img = a.ImageUrl,
            PublicationDate= a.DateOfpublication,
            Title = a.Title
            }
            ).ToArray();
        }
    }
}
