using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Common.Exeption
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string name, object key) : base($"Entity \"{name}\" ({key}) not found")
        {}
    }
}
