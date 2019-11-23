using System;

namespace SO.Domain.UseCases._Base.Models.PostResults
{
    public class PostResultFactory
    {
        public T Success<T>(string message = null, Action<T> additionalSetup = null)
            where T : PostResultBase, new()
        {
            var result = new T
            {
                IsSucceeded = true,
                Message = message
            };

            additionalSetup?.Invoke(result);

            return result;
        }

        public T Error<T>(string message = null, Exception exception = null, Action<T> additionalSetup = null)
            where T : PostResultBase, new()
        {
            var result = new T
            {
                IsSucceeded = false,
                Message = message,
                Exception = exception
            };

            additionalSetup?.Invoke(result);

            return result;
        }
    }
}