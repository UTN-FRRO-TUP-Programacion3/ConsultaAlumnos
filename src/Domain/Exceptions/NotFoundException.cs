using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaAlumnosClean.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            : base($"Entity {name} ({key}) was not found.")
        {
        }
    }
}
