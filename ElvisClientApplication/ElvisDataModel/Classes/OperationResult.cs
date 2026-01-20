using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElvisDataModel.Classes
{
    public class OperationResult
    {
        public Boolean Success { get; set; }
        public List<string>  Messages { get; private set; }

        public OperationResult()
        {
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public OperationResult ValidateEmail(string email)
        {
            var op = new OperationResult();

            if(string.IsNullOrWhiteSpace(email))
            {
                op.Success = false;
                op.AddMessage("Email address is null");
            }

            return op;
        }
    }

    
}
