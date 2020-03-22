using System;
using System.Collections.Generic;
using System.Text;

namespace exceptions
{
    class BoardException : Exception
    {
        public BoardException(string message)
            : base(message)
        {

        }
    }
}
