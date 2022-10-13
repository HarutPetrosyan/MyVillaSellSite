using System.Linq.Expressions;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly AplicationDBContext _dbCon;

        public VillaRepository(AplicationDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        

        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdateDate=DateTime.Now;
            _dbCon.Villas.Update(entity);
           await _dbCon.SaveChangesAsync();
           return entity;
        }

        

        
    }
}
