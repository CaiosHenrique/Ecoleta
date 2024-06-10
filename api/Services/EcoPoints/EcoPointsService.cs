using api.Data;
using api.Models;
using api.Services.Exceptions;

namespace api.Services.EcoPoints
{
    public class EcoPointsService : IEcoPointsService
    {

    private readonly DataContext _context;
    
    public EcoPointsService(DataContext context)
    {
        _context = context;
    }

    public async Task GetMaterial(int IdMaterial)
    {
        var ecopoint = _context.TB_ECOPOINTS.Find((EcopointsModel e) => e.IdMaterial == IdMaterial);

            if (ecopoint == null)
            {
                throw new NotFoundException("Material não encontrado");

            }
    }

    public async Task GetUtilizador(int IdUtilizador)
    {
        var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

            if (utilizador == null)
            {
                throw new NotFoundException("Utilizador não encontrado");
            }
    }

    public async Task PutAsync(int IdUtilizador)
    {

        var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

                // Verifique se o usuário existe
                if (utilizador == null)
                {
                    throw new ConflictException("Utilizador não existe");
                }

    }

    public async Task DeleteAsync(int IdUtilizador)
    {
        var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

            // Verifique se o usuário existe
            if (utilizador == null)
            {
                throw new NotFoundException("Utilizador não encontrado");
                
            }

    }



   }
}