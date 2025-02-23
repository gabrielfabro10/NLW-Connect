using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TechLibrary.Exception;

namespace TechLibrary.Exception
{
    public class ErrorOnValidatationException : TechLibraryException
    {
        private readonly List<string> _errors;

        public ErrorOnValidatationException(List<string> errorMessages)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrorMessages()
        {
            throw new NotImplementedException();
        }

        public override HttpStatusCode getStatusCode() => HttpStatusCode.BadRequest;
    }
}
