using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarDeligate
{
    public class NegativeExeption: Exception
    {
        NegativeExeption()
        {

        }
        public NegativeExeption(string message): base(message) 
        {

        }

        public NegativeExeption(string message, Exception ex) : base(message, ex)
        {

        }


    }
}
