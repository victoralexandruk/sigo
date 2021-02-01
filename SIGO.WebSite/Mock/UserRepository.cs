using SIGO.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIGO.WebSite.Mock
{
    public class UserRepository : IRepository<AppUser>
    {
        private static readonly AppUser[] Users = new[]
        {
            new AppUser { Id = 1, Username = "demo", Password = "demo" }
        };

        public IEnumerable<AppUser> GetAll()
        {
            return Users;
        }

        public AppUser GetById(long id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void Save(AppUser model)
        {
            if (model.Id > 0)
            {
                var original = GetById(model.Id);
                Users.SetValue(model, Array.IndexOf(Users, original));
            }
            else
            {
                Users.Append(model);
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUser> Search(IDictionary<string, object> where, bool strict = true)
        {
            throw new NotImplementedException();
        }
    }
}
