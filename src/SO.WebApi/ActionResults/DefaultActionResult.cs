using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SO.WebApi.ActionResults
{
    public class DefaultActionResult
    {
        private DefaultActionResult(bool isSucceeded, string message = null, object data = null)
        {
            IsSucceeded = isSucceeded;
            Message = message;
            Data = data;
        }

        public bool IsSucceeded { get; }

        public string Message { get; }

        public object Data { get; }

        public static DefaultActionResult Ok(string message = null, object data = null)
        {
            return new DefaultActionResult(true, message, data);
        }

        public static DefaultActionResult BadResult(string message = null)
        {
            return new DefaultActionResult(false, message);
        }
    }
}
