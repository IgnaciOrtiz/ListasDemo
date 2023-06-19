using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListasDemo.Model;
using SQLite;

namespace ListasDemo.Data
{
    public class FriendDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public FriendDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Friend>().Wait();
        }

        public async Task<List<Friend>> GetItemsAsync()
        {
            return await database.Table<Friend>().ToListAsync();
        }

        public Task<Friend> GetItemAsync(int id)
        {
            return database.Table<Friend>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Friend item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Friend item)
        {
            return database.DeleteAsync(item);
        }
    }
}
