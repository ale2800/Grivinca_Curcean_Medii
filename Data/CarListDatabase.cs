using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Grivinca_Curcean_Medii.Models;

namespace Grivinca_Curcean_Medii.Data
{
    public class CarListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CarListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CarList>().Wait();
        }
        public Task<List<CarList>> GetShopListsAsync()
        {
            return _database.Table<CarList>().ToListAsync();
        }
        public Task<CarList> GetShopListAsync(int id)
        {
            return _database.Table<CarList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(CarList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(CarList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
