using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnos.Domain.Exceptions
{
    public class NotAllowedException : Exception
    {
        public NotAllowedException()
        : base()
        {
        }

        public NotAllowedException(string message)
            : base(message)
        {
        }

        public NotAllowedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
