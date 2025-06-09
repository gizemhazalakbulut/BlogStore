using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class Tag // Etiketler
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

// Etiket bulutu, bir blog yazısı yazdık onun etiket bulutu hastag mantıgında yazıyı öne çıkaracak etiketler oluyor. 