using Publi24.BMs;
using Publi24.Entities;

namespace Publi24
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Company, CompanyCreateBM>();
            CreateMap<CompanyCreateBM, Company>();
        }
    }
}
