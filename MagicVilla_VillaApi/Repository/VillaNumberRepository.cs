using System.Linq.Expressions;
using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly AplicationDBContext _dbCon;

        public VillaNumberRepository(AplicationDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }


        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
           
            entity.UpdatedDate = DateTime.Now;
            _dbCon.VillaNumbers.Update(entity);
            await _dbCon.SaveChangesAsync();
            return entity;
        }




    }
}
