using api.Data;

public class UtilizadorService
{
    private readonly DataContext _context;

    public UtilizadorService(DataContext context)
    {
        _context = context;
    }

    public void AddEcoPoints(int IdUtilizador, int quantidade)
    {
        // Busque o usuário pelo ID
        var utilizador = _context.TB_UTILIZADOR.Find(IdUtilizador);

        // Verifique se o usuário existe
        if (utilizador == null)
        {
            throw new Exception("User not found");
        }

        // Adicione a quantidade de EcoPoints ao total de EcoPoints do usuário
        utilizador.TotalEcoPoints += quantidade;

        // Salve as alterações no banco de dados
        _context.SaveChanges();
    }
}