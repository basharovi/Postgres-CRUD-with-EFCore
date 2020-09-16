using System.Collections.Generic;
using PostgresCRUD.Models;

namespace PostgresCRUD.Data
{
    public interface IRepository
    {
        void AddPatientRecord(Patient patient);

        void UpdatePatientRecord(Patient patient);

        void DeletePatientRecord(string id);

        Patient GetPatientSingleRecord(string id);

        List<Patient> GetPatientRecords();
    }
}
