using StructureMap;
using assignment2C2P.Infrastructure.EF.Repositories;
using assignment2C2P.Validations;

namespace assignment2C2P.IoC
{
    public class StructureMap : Registry
    {
        public StructureMap()
        {
            For<IRepository>().Use<Repository>();
            For<IValidation>().Use<Validation>();
        }
    }
}
