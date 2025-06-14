using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {

    }
}
// kategori sınıfım için crud işlemlerini tek tek yazmaktan kurtulduk IGenericDal interface’inden kalıtım alarak crud işlemlerini yapabilirim.