using ModelVitae.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelVitae.Data.Services
{
    public class SqlModelData : IModelData
    {
        private readonly ModelDbContext db;

        public SqlModelData(ModelDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Model> GetModels()
        {
            IQueryable<Model> query = db.Models;
            return query.ToArray();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IQueryable<Customer> query = db.Customers;
            return query.ToArray();
        }
    }
}
