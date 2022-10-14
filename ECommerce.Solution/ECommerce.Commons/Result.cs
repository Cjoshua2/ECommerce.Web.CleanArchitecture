using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Commons
{
    public class Result
    {
        public virtual bool Success { get; set; }
        public string? Error { get; set; }

        public Result() { }
        public Result(string errorMessage)
        {
            this.Error = errorMessage;
        }
    }
    public class Ok : Result
    {
        public override bool Success => true;
    }
    public class Error : Result
    {
        public override bool Success => false;
        public Error(string errorMessage) : base(errorMessage) { }
    }
    public class Result<T>
    {
        public T? Payload { get; set; }
        public virtual bool Success { get; set; }
        public string? Error { get; set; }

        public Result() { }
        public Result(T payload)
        {
            this.Payload = payload;
        }
        public Result(string errorMessage)
        {
            this.Error = errorMessage;
        }
    }
    public class Ok<T> : Result<T>
    {
        public override bool Success => true;

        public Ok() { }

        public Ok(T payload) : base(payload) { }
    }
    public class Error<T> : Result<T>
    {
        public override bool Success => false;

        public Error() { }
        public Error(string errorMessage) : base(errorMessage) { }
    }
}
