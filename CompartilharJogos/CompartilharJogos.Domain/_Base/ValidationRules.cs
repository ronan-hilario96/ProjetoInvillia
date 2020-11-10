using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompartilharJogos.Domain._Base
{
    public class ValidationRules
    {
        private List<string> _menssageErrors;
        private ValidationRules()
        {
            _menssageErrors = new List<string>();
        }
        public static ValidationRules New()
        {
            return new ValidationRules();
        }
        public ValidationRules When(bool error, string messageError)
        {
            if (error)
            {
                _menssageErrors.Add(messageError);
            }
            return this;
        }
        public void TriggerException()
        {
            if (_menssageErrors.Any())
            {
                throw new ExceptionDomain(_menssageErrors);
            }
        }
    }
    public class ExceptionDomain : ArgumentException
    {
        public List<string> MessagemErrors { get; }
        public ExceptionDomain(List<string> messagemErrors)
        {
            MessagemErrors = messagemErrors;
        }
    }
}
