using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    internal class CarIsDeadException: System.ApplicationException
    {
        private string messageDetails = string.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException() { }
        public CarIsDeadException(string message, DateTime time, string cause) 
        {
            messageDetails = message;
            ErrorTimeStamp = time;
            CauseOfError = cause;
        }
        public override string Message => $"Car Error Message: {messageDetails}";
    }
    
}