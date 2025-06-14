using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.EntityLayer.Entities
{
    public class Tag // Etiket
    {
        public int TagId { get; set; }
        public string Title { get; set; }
    }
}

// Etiket bulutu, bir blog yazısı yazdık onun etiket bulutu hastag mantıgında yazıyı öne çıkaracak etiketler oluyor. Google aramalrında projeyi nasıl ön plana çıkarabiliriz? Etiketler ile. Etiketler ile ilgili bir bulut oluşturacağız. Etiketler, yazının içeriğini özetleyen veya yazıyla ilgili anahtar kelimeleri temsil eden kelimelerdir. Bu etiketler, yazının daha kolay bulunmasını sağlar ve okuyucuların ilgisini çeker.