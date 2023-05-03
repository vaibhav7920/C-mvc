﻿using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repositoy.IRepository
{
    public interface ICategoryRepository : Irepository<Category>
    {

        void Update(Category obj);
        
     
    }
}
