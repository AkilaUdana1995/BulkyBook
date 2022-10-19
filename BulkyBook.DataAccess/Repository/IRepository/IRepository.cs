using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    //this repo shoud be able to handle all the classes......this is Genaric repo
    public interface IRepository <T> where T : class
    {
        //T - Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);  //this is for edit record......
        IEnumerable<T> GetAll ();  //this will return all categories

        void Add (T entity); //this for adding
        void Remove(T entity); //this for delete
        void RemoveRange(IEnumerable<T> entity); //this for delete more than one at a  time, T is collection of entities here

        //update is not genaric, method, I dont undertand it for now...................

    }
}
