using MeetingNotes.Data;
using MeetingNotes.Models;
using System.Numerics;

namespace MeetingNotes.Services
{
    public interface INotesService
    {
        Notes? GetNoteById(int id);

        int CreateNote(Notes notes);

        IEnumerable<Notes> GetNotes();

        void DeleteNote(int id);

        int EditNote(Notes notes);
    }

    public class NotesServices : INotesService
    {
        private readonly ApplicationDbContext _db;

        public NotesServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public Notes? GetNoteById(int id)
        {
            var note = _db.Notes.Where(w => w.NotesId == id).FirstOrDefault();
            return note;
        }
        public int CreateNote(Notes note)
        {
            _db.Notes.Add(note);
            _db.SaveChanges();
            return note.NotesId;
        }
        public IEnumerable<Notes> GetNotes()
        {
            return _db.Notes.ToList();
        }

        public void DeleteNote(int id)
        {
            var note = GetNoteById(id);
            _db.Notes.Remove(note);
            _db.SaveChanges();
        }

        public int EditNote(Notes note)
        {
            _db.Notes.Update(note);
            _db.SaveChanges();
            return note.NotesId;
        }
    }
}
