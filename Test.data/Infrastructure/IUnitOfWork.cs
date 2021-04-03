using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.data.Models;

namespace Test.data
{


    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Tokens> TokenRepository { get; }

        Task Commit();

        Task SaveChanges();

        void BeginTransaction();

        void Rollback();

        void Dispose();

        //DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);
    }
}