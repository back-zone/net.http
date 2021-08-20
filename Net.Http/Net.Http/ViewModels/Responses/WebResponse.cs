using System;

namespace Back.Zone.Net.Http.ViewModels.Responses
{
    public sealed record WebResponse<TA>(
        bool Result,
        string Message,
        DateTime HappenedAt,
        TA? Payload
    ) where TA : class
    {
        private const string SuccessMessage = "#SUCCEED#";
        private const string FailureMessage = "#FAILED#";

        public static WebResponse<TA> Succeed() => new(true, SuccessMessage, DateTime.Now, default);

        public static WebResponse<TA> SucceedWith(string message) =>
            new(true, message, DateTime.Now, default);

        public static WebResponse<TA> SucceedWith(TA payload) =>
            new(true, SuccessMessage, DateTime.Now, payload);

        public static WebResponse<TA> Failed() => new(false, FailureMessage, DateTime.Now, default);

        public static WebResponse<TA> FailedBecause(string message) => new(false, message, DateTime.Now, default);

        public static WebResponse<TA> FailedBecause(Exception exception) =>
            new(false, exception.Message, DateTime.Now, default);

        public static WebResponse<TA> FailedBecause(TA payload) => new(false, FailureMessage, DateTime.Now, payload);
    }

    public sealed record WebResponse(
        bool Result,
        string Message,
        DateTime HappenedAt,
        object Payload
    )
    {
        private const string SuccessMessage = "#SUCCEED#";
        private const string FailureMessage = "#FAILED#";

        public static WebResponse Succeed() => new(true, SuccessMessage, DateTime.Now, default);

        public static WebResponse SucceedWith(string message) =>
            new(true, message, DateTime.Now, default);

        public static WebResponse SucceedWith(object payload) =>
            new(true, SuccessMessage, DateTime.Now, payload);

        public static WebResponse Failed() => new(false, FailureMessage, DateTime.Now, default);

        public static WebResponse FailedBecause(string message) => new(false, message, DateTime.Now, default);

        public static WebResponse FailedBecause(Exception exception) =>
            new(false, exception.Message, DateTime.Now, default);

        public static WebResponse FailedBecause(object payload) => new(false, FailureMessage, DateTime.Now, payload);
    }
}