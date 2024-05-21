using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnNET.Core.Results.Errors
{
    public interface IError
    {
        string Code { get; init; }
        string Message { get; init; }
    }
}
