using BlogStore.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class Article //makale
    {
        public int ArticleId { get; set; }           // Makalenin benzersiz ID'si
        public string Title { get; set; }            // Başlık
        public string Description { get; set; }      // Açıklama
        public string ImageUrl { get; set; }         // Görsel linki
        public DateTime CreatedDate { get; set; }    // Oluşturulma tarihi
        public int CategoryId { get; set; }          // Bu makalenin ait olduğu kategori ID'si (foreign key)
        public Category Category { get; set; }       // Navigation property (ilişkili Category nesnesi)
        public string? AppUserId { get; set; }      // Makalenin sahibi olan kullanıcının ID'si
        public AppUser AppUser { get; set; }        // Navigation property (ilişkili AppUser nesnesi)

        public List<Comment> Comments { get; set; }  // Bu makaleye ait yorumlar listesi

        public string Slug { get; set; }
    }

}

//| Yapı                 | Açıklama                                               |
//| -------------------- | ------------------------------------------------------ |
//| `Article.CategoryId` | Foreign Key(ilişkili kategori ID’si) |
//| `Article.Category`   | Navigation property(bir makalenin kategorisi) |
//| `Category.Articles`  | Navigation property(kategoriye ait makaleler listesi) |

