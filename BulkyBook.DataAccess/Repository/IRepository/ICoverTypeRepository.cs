using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        //since our genaric repository has no method to update records, we need to implement method to update records/......

        //method to update records ....

        void Update(CoverType obj);
        //void Save();
    }
}
