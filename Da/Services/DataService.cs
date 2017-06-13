using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Backend.Entities;
using Backend.Utils;

namespace Da.Services
{
    class DataService
    {
        public IEnumerable<T> GetData<T>() where T: Entity
        {
            using (var context = new Context())
            {
                return context.Get<T>();
            }
        }

        public IEnumerable<T> GetData<T>(Context context) where T : Entity
        {
            return context.Get<T>();
        }

        // @gmrukwa: This one is useful for downloading lazily fetched deps
        public void GetData<T>(Action<DbSet<T>, Exception> callback) where T : Entity
        {
            using (var context = new Context())
            {
                try
                {
                    callback(context.Get<T>(), null);
                }
                catch (Exception ex)
                {
                    callback(null, ex);
                }
            }
        }
    }
}
