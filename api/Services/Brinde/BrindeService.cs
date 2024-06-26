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
        

        public async Task GetAsync(int id)
        {
            var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync((BrindeModel b) => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new NotFoundException("Brinde não encontrado");
            }
        }

        public async Task PutAsync(int id)
        {
            var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync((BrindeModel b) => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new ConflictException("Dados inválidos");
            }

        }

        public async Task DeleteAsync(int id)
        {
            var brinde = await _context.TB_BRINDE.FirstOrDefaultAsync(b => b.IdBrinde == id);
            if (brinde == null)
            {
                throw new NotFoundException("Brinde não encontrado");
            }
        }

        
    }
}