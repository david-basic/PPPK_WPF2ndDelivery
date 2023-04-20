using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_WPF2ndDelivery.Dal
{
    public static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> repository = new Lazy<IRepository>(() =>
            new SqlRepository()
        );

        public static IRepository GetRepository() => repository.Value;
    }
}
