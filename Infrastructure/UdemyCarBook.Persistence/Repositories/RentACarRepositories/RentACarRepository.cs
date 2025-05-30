using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository :IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }
        /*
        {
            var values = await _context.RentACars.Where(filter).ToListAsync();
            return values;
        }
        */
        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values=await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(y=>y.Brand).ToListAsync();
            return values;
        }
    }
}
 