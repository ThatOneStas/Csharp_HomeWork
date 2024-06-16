using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkCS10._06._24.Exceptions
{
    public class IncorrectEmail : Exception
    {
        public IncorrectEmail(string message)
        : base(message)
        {
        }
    }
}
