using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repositoy.IRepository
{
    public interface ICoverTypeRepository : Irepository<CoverType>
    {

        void Update(CoverType obj);
        
     
    }
}
