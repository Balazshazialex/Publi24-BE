using AutoMapper;
using Publi24.BMs;
using Publi24.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publi24.Services
{
    public class CompanyService : ICompanyService<Company>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Company> Add(object value)
        {
            var company = _mapper.Map<Company>(value);
            await _dbContext.Companies.AddAsync(company); 
            _dbContext.SaveChanges();   
            return company;
        }

        public Company Get(int id)
        {
            return  _dbContext.Companies.Where(c=> c.Id == id).FirstOrDefault();
        }

        public Company Get(string isin)
        {
            return _dbContext.Companies.Where(c => c.Isin ==isin).FirstOrDefault();
        }

        public List<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        public Company Put(object value)
        {
            var company = value as Company;
            _dbContext.Companies.Update(company);
            _dbContext.SaveChanges();
            return company;
        }
    }
}
