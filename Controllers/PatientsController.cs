using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PostgresCRUD.Data;
using PostgresCRUD.Models;

namespace PostgresCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository _dataAccessProvider;

        public PatientsController(IRepository dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _dataAccessProvider.GetPatientRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            patient.id = Guid.NewGuid().ToString();
            _dataAccessProvider.AddPatientRecord(patient);
            return Ok();
        }

        [HttpGet("{id}")]
        public Patient Details(string id)
        {
            return _dataAccessProvider.GetPatientSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Patient patient)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            _dataAccessProvider.UpdatePatientRecord(patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _dataAccessProvider.GetPatientSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataAccessProvider.DeletePatientRecord(id);
            return Ok();
        }
    }
}
