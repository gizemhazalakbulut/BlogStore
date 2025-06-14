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

    }
}
