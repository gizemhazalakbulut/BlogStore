using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Article> Articles { get; set; }  // Kullanıcının yazdığı makaleler listesi

        public List<Comment> Comments { get; set; }  // Kullanıcının yaptığı yorumlar listesi
    }
}
