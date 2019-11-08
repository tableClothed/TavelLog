using databaseApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace databaseApp.Data
{
    public class NoteDatabase
    {
        private SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _database.Table<Note>().ToListAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _database.Table<Note>()
                .FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0) {
                return await _database.UpdateAsync(note);
            } else
            {
                return await _database.InsertAsync(note);
            }
            
        }

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return await _database.DeleteAsync(note);
        }
    }
}
