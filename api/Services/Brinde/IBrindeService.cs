namespace api.Services.Brinde
{
    public interface IBrindeService
    {
        public Task GetAsync(int id);
        public Task PutAsync(int id);
        public Task DeleteAsync(int id);
    }

}