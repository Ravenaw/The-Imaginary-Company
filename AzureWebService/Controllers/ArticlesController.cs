using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AzureWebService.DBAccess;
using InventoryLibrary;

namespace AzureWebService.Controllers
{
    public class ArticlesController : ApiController
    {
        DBAccess.DBAccess articleAccess = new DBAccess.DBAccess();
        // GET: api/Articles
        public IEnumerable<Article> Get()
        {
            return articleAccess.GetAllArticles();
        }

        // GET: api/Articles/5
        public Article Get(int id)
        {
            return articleAccess.GetArticleByTIC(id);
        }

        [HttpGet]
        [Route("api/Articles/byIAN/{ian}")]
        public Article GetByIAN(int ian)
        {
            return articleAccess.GetArticleByIAN(ian);
        }

        [HttpGet]
        [Route("api/Articles/byLoc/{loc}")]
        public Article GetByLocation(string loc)
        {
            return articleAccess.GetArticleByLocation(loc);
        }

        // POST: api/Articles
        public void Post([FromBody] Article article)
        {
            articleAccess.createArticle(article);
        }

        // PUT: api/Articles/5
        public void Put(int id, [FromBody] Article article)
        {
            articleAccess.updateArticle(id, article);
        }

        // DELETE: api/Articles/5
        public void Delete(int id)
        {
            articleAccess.deleteArticle(id);
        }
    }
}
