using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tutor_Database.Exceptions
{
    [Serializable]
    internal class WrongPasswordException : ApplicationException
    {
        public WrongPasswordException()
        {
        }

        public WrongPasswordException(string message) : base(message)
        {

        }

        public WrongPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
