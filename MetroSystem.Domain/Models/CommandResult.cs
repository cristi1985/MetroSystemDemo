using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Models
{
    public class CommandResult : ICommandResult
    {
        public bool IsSuccessful {get; set;}
        public string Message { get; set; }

        public string Type { get; set; }

        public int ErrorCode { get; set; }

        public IList<ValidationFailure> Errors { get; set; }

        public object Payload { get; set; }

        public static CommandResult Error(string message)
        {
            return new CommandResult() { IsSuccessful = false, Message = message };
        }
    }
}
