using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkCS10._06._24.Exceptions
{
    public class NameAlreadyExists : Exception
    {
        public NameAlreadyExists(string message)
        : base(message)
        {
        }
    }
}
