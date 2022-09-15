using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSystem.Domain.Models
{
    public interface ICommandResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
        string Type { get; }
        int ErrorCode { get; }
        IList<ValidationFailure> Errors { get; }
        object Payload { get; }
    }
}
