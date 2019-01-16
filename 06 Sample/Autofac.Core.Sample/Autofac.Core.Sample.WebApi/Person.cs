using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac.Core.Sample.WebApi
{
    public class Person : IPerson, ITransientDependency
    {
        public int getAge()
        {
            return 31;
        }
    }
}
