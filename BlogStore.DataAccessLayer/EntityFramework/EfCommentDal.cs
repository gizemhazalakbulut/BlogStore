using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.EntityFramework;
using BlogStore.DataAccessLayer.Repositories;
using BlogStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly BlogContext _context;
        public EfCommentDal(BlogContext context) : base(context) 
        {
            _context = context;
        }
    }
}
// base(context) ifadesi; EfCommentDal'ın miras aldığı GenericRepository<Comment> sınıfının constructor'ını çalıştırır. Ona context parametresini aktarır.


//Bu Kod Ne Yapıyor? (EfCommentDal)
//Bu sınıf:

//EfCommentDal, Comment entity'si için oluşturulmuş özel bir repository sınıfı.

//GenericRepository<Comment>’ten kalıtıyor → tüm CRUD işlemleri hazır geliyor.

//ICommentDal interface’ini uyguluyor.

//BlogContext tipinde özel bir _context alanı tanımlıyor ve kurucuda atama yapıyor.


//Neden _context Alanını Ayrı Tanımladık?
//Bu çok önemli bir detay: Çünkü bu sınıf içinde ileride EF’ye özel işlemler yapabilmek için BlogContext nesnesine doğrudan erişmek istiyoruz.

//Örnek Senaryo:
//Diyelim ki bir yorumun yazarı, ait olduğu makale gibi ilişkili verileri birlikte getirmek istiyoruz:

//public List<Comment> GetCommentsWithArticleTitle()
//{
//    return _context.Comments.Include(x => x.Article).ToList();
//}
//İşte bu satırı yazabilmek için, BlogContext tipindeki _context alanına ihtiyacın var. Eğer sadece base(context) deseydik ve _context alanını tanımlamasaydık, bu sınıf içinde doğrudan EF'nin DbSet'lerine erişemezdin.

//Yani, bu yapının güzelliği şu: Hem ortak işlemleri GenericRepository'de bırakıyorsun, hem de bu DAL sınıfında özel ihtiyaçlar olduğunda BlogContext ile doğrudan çalışabiliyorsun.