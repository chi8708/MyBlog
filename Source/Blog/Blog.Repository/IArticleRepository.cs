﻿using Blog.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository
{
   public partial interface  IArticleRepository
    {
       bool DeleteArt_CatByArtId(string articleId);
       Task<bool> UpdateArticleHit(Article article);
    }
}
