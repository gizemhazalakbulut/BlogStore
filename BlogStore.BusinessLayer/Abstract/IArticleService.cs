using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        public List<Article> TGetArticlesWithCategories(); // Kategorilerle birlikte makaleleri getiren özel bir metot

        public AppUser TGetAppUserByArticleId(int id); // Makale ID'sine göre AppUser'ı getiren özel bir metot

        public List<Article> TGetTop3PopularArticles(); // En popüler 3 makaleyi getiren özel bir metot

        public List<Article> TGetArticlesByAppUser(string id);

        public List<Article> TGetArticlesByCategoryId(int id);

        public Article TGetArticleBySlug(string slug);

        public Article TGetArticleWithUser(int id);

        public List<Article> TGetArticlesByUserId(string id);
    }
}
