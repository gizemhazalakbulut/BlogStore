using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string UserNameSurname { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentDetail { get; set; }
        public bool IsValid { get; set; } //Onaylanmış demek olabilir. Onaylanmamış yorumları göstermeyelim diye mesela hakaret içeren bir yorum yapıldıysa

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; } //AppUser ile ilişkilendiriyoruz. Bir kullanıcı birden fazla yorum yapabilir. Yani 1'e çok ilişki var.
        public int ArticleId { get; set; }
        public Article Article { get; set; } //Article ile ilişkilendiriyoruz. Bir makale birden fazla yorum alabilir. Yani 1'e çok ilişki var.

        public bool IsToxic { get; set; }

        public float ToxicityScore { get; set; }

    }
}
