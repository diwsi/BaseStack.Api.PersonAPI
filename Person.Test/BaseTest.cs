using EFAdapter;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Person.Domain.Entities;
using Repository;

namespace Person.Test
{
    public abstract class BaseTest
    {


        private static PersonAppContext db;
        public static PersonAppContext DB
        {
            get
            {
                if (db == null)
                {
                    var dbContextOptions = new DbContextOptionsBuilder<PersonAppContext>().UseInMemoryDatabase(databaseName: "TestDB").Options;
                      db = new PersonAppContext(dbContextOptions);
                }
                return db;
            }

        }


        public IUOW InitUOW()
        {

            return new EFUnitOfWork(DB);
        }
    }
}
