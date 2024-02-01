using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;

namespace VolvoFinalProject.Exceptions
{
    public class ModelException : Exception
    {
        public int StatusCode { get; }
        public ModelException() : base() { }

        public ModelException(string message) : base(message)
        {
            
        }

        public ModelException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}