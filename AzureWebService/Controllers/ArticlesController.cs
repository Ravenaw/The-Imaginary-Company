using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;
using AzureWebService.DBAccess;
using InventoryLibrary;

//SQL methods converted to C#
namespace AzureWebService.Controllers
{
    public class ArticlesController : ApiController
    {
        //Instance of DBAccess class
        //
        DBAccess.DBAccess articleAccess = new DBAccess.DBAccess();
        // GET: api/Articles
        public IEnumerable<Article> Get()
        {
            return articleAccess.GetAllArticles();
        }

        // GET: api/Articles/5
        public Article Get(string id)
        {
            return articleAccess.GetArticleByTIC(id);
        }
        //custom get functions because these are not included by default
        [HttpGet]
        [Route("api/Articles/byIAN/{ian}")]
        public Article GetByIAN(string ian)
        {
            return articleAccess.GetArticleByIAN(ian);
        }

        [HttpGet]
        [Route("api/Articles/byLoc/{loc}")]
        public Article GetByLocation(string loc)
        {

            return articleAccess.GetArticleByLocation(loc);
        }

        // POST: api/Articles---- add smth new
        public void Post([FromBody] Article article)
        {
            if (Get(article.TIC).TIC != article.TIC && article.Location.Length == 6 && article.TIC.IsInt() && article.isIANnumeric() && article.Quantity > 0 && article.Weight > 0 && article.TIC.Length == 4 && (article.IAN.Length == 8 || article.IAN.Length == 16))
            {
                articleAccess.createArticle(article);
            }
        }

        // PUT: api/Articles/5 update
        public void Put(string id, [FromBody] Article article)
        {
            if (article.Location.Length == 6 && article.isIANnumeric() && article.Weight > 0 && (article.IAN.Length == 8 || article.IAN.Length == 16))
            {
                articleAccess.updateArticle(id, article);
            }
        }

        // DELETE: api/Articles/5
        public void Delete(string id)
        {
            articleAccess.deleteArticle(id);
        }
    }
}
