using System.Collections.Generic;
using System.Linq;
using PostgresCRUD.Models;

namespace PostgresCRUD.Data
{
    public class Repository : IRepository
    {
        private readonly PostgresDbContext _context;

        public Repository(PostgresDbContext context)
        {
            _context = context;
        }

        public void AddPatientRecord(Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatientRecord(Patient patient)
        {
            _context.patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(string id)
        {
            var entity = _context.patients.FirstOrDefault(x => x.id == id);
            _context.patients.Remove(entity);
            _context.SaveChanges();
        }

        public Patient GetPatientSingleRecord(string id)
        {
            return _context.patients.FirstOrDefault(x => x.id == id);
        }

        public List<Patient> GetPatientRecords()
        {
            return _context.patients.ToList();
        }
    }
}
