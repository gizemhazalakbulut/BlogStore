using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticlesWithCategories(); // Kategorilerle birlikte makaleleri getiren özel bir metot

        public AppUser GetAppUserByArticleId(int id);

        List<Article> GetTop3PopularArticles(); // En popüler 3 makaleyi getiren özel bir metot

        List<Article> GetArticlesByAppUser(string id);

        List<Article> GetArticlesByUserId(string id);

        public List<Article> GetArticlesByCategoryId(int id);

        public Article GetArticleBySlug(string slug);

        public Article GetArticleWithUser(int id);
    }
}
// Article sınıfım için crud işlemlerini tek tek yazmaktan kurtulduk. IGenericDal interface’inden kalıtım alarak crud işlemlerini yapabilirim.