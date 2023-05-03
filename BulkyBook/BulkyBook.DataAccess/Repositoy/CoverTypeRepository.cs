﻿using BulkyBook.DataAccess.Repositoy.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repositoy
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }

       
        public void Update(CoverType obj)
        {
          _db.CoverTypes.Update(obj);
        }

       
    }
}
