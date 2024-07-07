using SpringService.Models;

namespace SpringService
{
    public class LocalDatabase
    {
        private const string DB_NAME = "spring_service.db3";
        /*private readonly SQLiteAsyncConnection connection;

        public LocalDatabase(SQLLiteAsyncConnection connection)
        {
            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            connection.CreateTableAsync<Db>();
        }

        public async Task GetUser()
        {
            return await connection.Table<Db>().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task CreateUser(Db user)
        {
            await connection.InsetAsync(user);
        }

        public async Task UpdateUser(Db user)
        {
            await connection.UpdateAsync(user);
        }
        public async Task DeleteUser(Db user)
        {
            await connection.RemoveAsync(user);
        }*/
    }

}
