using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.EntityFramework;
using BlogStore.DataAccessLayer.Repositories;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(BlogContext context) : base(context)
        {
        }
    }
}

//EfCategoryDal Nedir?

//Ef = Entity Framework.

//CategoryDal = Data Access Layer (Kategori için veri erişim katmanı).

//Yani bu sınıf Category tablosuna özel veri işlemleri için kullanılacak.


//GenericRepository<Category> Ne Anlama Geliyor?

//EfCategoryDal sınıfı, bir generic repository sınıfını kalıtıyor (miras alıyor).

//GenericRepository<T> zaten CRUD işlemlerini içeriyor.

//Burada T = Category verilmiş. Yani artık EfCategoryDal, Category için çalışan bir repository oldu.

//ICategoryDal Nedir?

//EfCategoryDal sınıfı aynı zamanda ICategoryDal arayüzünü (interface) uyguluyor(implements).

//ICategoryDal muhtemelen IGenericDal<Category> arayüzünden türemiştir ve özel metotlar da eklenebilir.


//Constructor: EfCategoryDal(BlogContext context) : base(context)
//Bu satır, sınıfın kurucu metodudur. Ne yapar?

//🔹 BlogContext context
//EF’nin DbContext sınıfından türetilmiş senin uygulamana özel bir sınıftır.

//Yani bu context, veritabanıyla bağlantıyı sağlar.

//🔹 : base(context)
//Bu ifade, base class (yani GenericRepository) kurucusuna bu context’i gönderiyor.

//GenericRepository<Category> içinde bir DbContext (veya BlogContext) varsa, onu initialize eder.

