using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Patient.Models;
using Patient.Validations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientContext patientContext;

        public PatientController(PatientContext pc)
        {
            patientContext = pc;
        }

        // POST api/<PatientController>
        [HttpPost]
        public IActionResult Post([FromBody] AddPatientReq addPatientReq)
        {
            // Validate user
            var user = patientContext.User.Where(u => u.Name == addPatientReq.User).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(string.Format("Invalid user-{0}", addPatientReq.User));
            }

            // Basic validations on request
            bool basicValidationFlag = true;
            String basicErrors = "";
            basicValidationFlag &= Validate.ForenameValid(addPatientReq.ForeName, ref basicErrors);
            basicValidationFlag &= Validate.SurnameValid(addPatientReq.Surname, ref basicErrors);
            basicValidationFlag &= Validate.PhoneValid(addPatientReq.PrimaryContactNumber, ref basicErrors);
            basicValidationFlag &= Validate.AddressLine1Valid(addPatientReq.PrimaryAddressLine1, ref basicErrors);
            basicValidationFlag &= Validate.PostcodeValid(addPatientReq.PostCode, ref basicErrors);
            if ( basicValidationFlag == false )
            {
                return BadRequest(basicErrors);
            }

            // Validate patient is not in the DB. For the purpose of the exercise assume that Forname, Surname and DateOfBirth is all that is needed to uniquely identify a patient.
            // Clearly not 
            var checkPatient = patientContext.Patient.Where(p => p.Forename == addPatientReq.ForeName && p.Surname == addPatientReq.Surname && p.DateOfBirth == addPatientReq.DateOfBirth).FirstOrDefault();
            if (checkPatient != null )
            {
                return BadRequest(string.Format("Patient already in database. Forename: {0}, Surname: {1}, DOB: {2:yyyy-MM-dd}", addPatientReq.ForeName, addPatientReq.Surname, addPatientReq.DateOfBirth));
            }

            var address = patientContext.Address.Where(adr => adr.Line1 == addPatientReq.PrimaryAddressLine1 && adr.PostCode == addPatientReq.PostCode).FirstOrDefault();
            bool addAddress = false;
            if (address == null)
            {
                address = new Address
                {
                    Id = Guid.NewGuid(),
                    Line1 = addPatientReq.PrimaryAddressLine1,
                    Line2 = addPatientReq.PrimaryAddressLine2,
                    Line3 = addPatientReq.PrimaryAddressLine3,
                    PostCode = addPatientReq.PostCode
                };
                addAddress = true;
                
            }

            var phone = patientContext.Phone.Where(ph => ph.Number == addPatientReq.PrimaryContactNumber).FirstOrDefault();
            bool addPhone = false;
            if (phone == null)
            {
                phone = new Phone
                {
                    Id = Guid.NewGuid(),
                    Number = addPatientReq.PrimaryContactNumber
                };
                addPhone = true;
            }

            
            // Now add the database rows as required
            var newPatient = new Patient
            {
                Id = Guid.NewGuid(),
                Forename = addPatientReq.ForeName,
                Surname = addPatientReq.Surname,
                DateOfBirth = addPatientReq.DateOfBirth,
                PrimaryContactPhoneID = phone.Id,
                PrimaryAddressId = address.Id
            };
            patientContext.Add<Patient>(newPatient);


            if (addAddress == true)
            {
                patientContext.Add<Address>(address);
            }

            if (addPhone == true )
            {
                patientContext.Add<Phone>(phone);
            }

            // Audit Log record
            AuditLog auditRecord = new AuditLog
            {
                UserId = user.Id,
                PatientID = newPatient.Id,
                DateTime = DateTimeOffset.Now,
                Type = "Add",
                Notes = string.Format("Forename: {0}, Surname: {1}, DOB: {2:yyyy-MM-dd}", newPatient.Forename, newPatient.Surname, newPatient.DateOfBirth)
            };
            patientContext.Add<AuditLog>(auditRecord);

            // Finally commit the changes
            patientContext.SaveChanges();

            return Ok(string.Format("Added - Forename: {0}, Surname: {1}, DOB: {2:yyyy-MM-dd}", newPatient.Forename, newPatient.Surname, newPatient.DateOfBirth));
        }

    }
}
