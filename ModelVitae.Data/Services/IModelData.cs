using ModelVitae.Data.Models;
using System.Collections.Generic;

namespace ModelVitae.Data.Services
{
    public interface IModelData
    {
        IEnumerable<Model> GetModels();

        IEnumerable<Customer> GetCustomers();
    }
}
