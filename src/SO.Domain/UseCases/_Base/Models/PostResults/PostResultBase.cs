using System;

namespace SO.Domain.UseCases._Base.Models.PostResults
{
    public class PostResultBase
    {
        internal PostResultBase()
        {
            
        }

        public bool IsSucceeded { get; internal set; }

        public string Message { get; internal set; }

        public Exception Exception { get; internal set; }
    }
}
