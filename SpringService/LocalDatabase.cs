using SpringService.Models;
using SQLite;

namespace SpringService
{
    public class LocalDatabase
    {
        /*private const string DB_NAME = "spring_service.db3";
        private readonly SQLiteAsyncConnection connection;

        public LocalDatabase(SQLiteAsyncConnection connection)
        {
            this.connection = connection; // could be removed
            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            connection.CreateTableAsync<Db>();
        }

        public async Task<Db> GetUser(int id)
        {
            return await connection.Table<Db>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateUser(Db user)
        {
            await connection.InsertAsync(user);
        }

        public async Task UpdateUser(Db user)
        {
            await connection.UpdateAsync(user);
        }
        public async Task DeleteUser(Db user)
        {
            await connection.DeleteAsync(user);
        }*/
    }

}
