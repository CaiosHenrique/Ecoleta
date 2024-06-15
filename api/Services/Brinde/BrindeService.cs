using System;
using api.Models;
using api.Services.Exceptions;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Brinde
{
    public class BrindeService : IBrindeService
    {

        private readonly DataContext _context;

        public BrindeService(DataContext context)
        {
            _context = context;
        }
        

        public async Task<BrindeModel> GetAsync(int id)
        {
            var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync(b => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new NotFoundException("Brinde não encontrado");
            }
            return brinde;
        }

        public async Task<BrindeModel> PutAsync(int id)
        {
            var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync(b => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new ConflictException("Dados inválidos");
            }
            return brinde;

        }

        public async Task DeleteAsync(int id)
        {
            var brinde = _context.TB_BRINDE.Find((BrindeModel b) => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new NotFoundException("Brinde não encontrado");
            }
        }

        
    }
}