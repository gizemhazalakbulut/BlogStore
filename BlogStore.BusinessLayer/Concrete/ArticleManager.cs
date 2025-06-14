﻿using BlogStore.BusinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            // Bu işlemi yapmaya yetkiniz var mı kontrolü yapılabilir. Listeleme yapacak kişinin gerçekten bu işlemi yapmaya yetkisi olup olmadığı kontrol edilebilir.
            return _articleDal.GetAll();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void TInsert(Article entity)
        {
            if(entity.Title.Length>=10 && entity.Title.Length<=100 && entity.Description!="" && entity.ImageUrl.Contains("a"))
            {
                _articleDal.Insert(entity);
            }
            else
            {
                // Hata mesajı verilebilir.
            }
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }
    }
}
