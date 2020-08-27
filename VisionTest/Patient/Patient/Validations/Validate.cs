using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patient.Validations
{
    public class Validate
    {
        public static bool ForenameValid(String forename, ref String errorString )
        {
            if ( forename == null || forename.Length == 0 )
            {
                errorString += "forename missing. ";
                return false;
            }
            return true;
        }

        public static bool SurnameValid(string surname, ref String errorString )
        {
            if (surname == null || surname.Length == 0)
            {
                errorString += "surname missing. ";
                return false;
            }
            return true;
        }

        public static bool PhoneValid(String phone, ref String errorString)
        {
            if (phone == null || phone.Length == 0 )
            {
                errorString += "phone number missing. ";
                return false;
            }

            // Keep the validation very simple and just allow numbers
            Regex regex = new Regex("^[0-9]+$");
            if ( !regex.IsMatch(phone))
            {
                errorString += "phone number includes non-numberics. ";
                return false;
            }
            return true;
        }

        public static bool AddressLine1Valid(String line, ref String errorString)
        {
            if (line == null || line.Length == 0 )
            {
                errorString += "Address Line1 must containg something. ";
                return false;
            }
            return true;
        }

        public static bool PostcodeValid(String postcode, ref String errorString )
        {
            if (postcode == null || postcode.Length == 0)
            {
                errorString += "Post Code Missing. ";
                return false;
            }

            Regex regex = new Regex("^[A-Z0-9]+ [A-Z0-9]+$");
            if ( !regex.IsMatch(postcode))
            {
                errorString += "Postcode invalid";
                return false;
            }

            return true;
        }
    }
}
