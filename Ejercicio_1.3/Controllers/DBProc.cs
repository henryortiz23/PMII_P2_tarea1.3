using Ejercicio_1._3.Models;
using SQLite;

namespace Ejercicio_1._3.Controllers
{
    public class DBProc : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;

        public DBProc()
        { }

        public DBProc(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            // todos objetos BD
            _connection.CreateTableAsync<Personas>().Wait();
        }

        /*  crud DBProc*/
        // create, read, update, delete

        public Task<int> AddPersona(Personas persona)
        {
            if (persona.id == 0)
            {
                return _connection.InsertAsync(persona);
            }
            else
            {
                return _connection.UpdateAsync(persona);
            }
        }

        public Task<List<Personas>> ListPersonas()
        {
            return _connection.Table<Personas>().ToListAsync();
        }

        public Task<Personas> GetPersonaID(int id)
        {
            return _connection.Table<Personas>()
                .Where(p => p.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePersona(Personas persona)
        {
            return _connection.DeleteAsync(persona);
        }

        public Task<int> UpdatePersona(Personas persona)
        {
            return _connection.UpdateAsync(persona);
        }
    }
}