using System;
using System.Text.Json.Serialization;

namespace Back.Zone.Net.Http.TransferObjects.HttpResponseObjects;

public sealed record ApiResponse<TPayload>(
    [property: JsonPropertyName("result")] bool Result,
    [property: JsonPropertyName("message")]
    string Message,
    [property: JsonPropertyName("happened_at")]
    DateTime HappenedAt,
    [property: JsonPropertyName("payload")]
    TPayload? Payload
) where TPayload : class
{
    private const string SuccessMessage = "#SUCCEED#";

    private const string FailureMessage = "#FAILED#";

    public static ApiResponse<TPayload> Succeed() => new(true, SuccessMessage, DateTime.Now, default);

    public static ApiResponse<TPayload> SucceedWithMessage(string message) =>
        new(true, message, DateTime.Now, default);

    public static ApiResponse<TPayload> SucceedWithPayload(TPayload payload) =>
        new(true, SuccessMessage, DateTime.Now, payload);

    public static ApiResponse<TPayload> SucceedWithMessageAndPayload(string message, TPayload payload) =>
        new(true, message, DateTime.Now, payload);

    public static ApiResponse<TPayload> Failed() => new(false, FailureMessage, DateTime.Now, default);

    public static ApiResponse<TPayload> FailedWithMessage(string message) =>
        new(false, message, DateTime.Now, default);

    public static ApiResponse<TPayload> FailedWithException(Exception exception) =>
        new(false, exception.Message, DateTime.Now, default);

    public static ApiResponse<TPayload> FailedWithPayload(TPayload payload) =>
        new(false, FailureMessage, DateTime.Now, payload);

    public static ApiResponse<TPayload> FailedWithMessageAndPayload(string message, TPayload payload) =>
        new(false, message, DateTime.Now, payload);
}

public sealed record ApiResponse(
    [property: JsonPropertyName("result")] bool Result,
    [property: JsonPropertyName("message")]
    string Message,
    [property: JsonPropertyName("happened_at")]
    DateTime HappenedAt,
    [property: JsonPropertyName("payload")]
    object? Payload
)
{
    private const string SuccessMessage = "#SUCCEED#";

    private const string FailureMessage = "#FAILED#";

    public static ApiResponse Succeed() => new(true, SuccessMessage, DateTime.Now, default);

    public static ApiResponse SucceedWithMessage(string message) => new(true, message, DateTime.Now, default);

    public static ApiResponse SucceedWithPayload(object payload) => new(true, SuccessMessage, DateTime.Now, payload);

    public static ApiResponse SucceedWithMessageAndPayload(string message, object payload) =>
        new(true, message, DateTime.Now, payload);

    public static ApiResponse Failed() => new(false, FailureMessage, DateTime.Now, default);

    public static ApiResponse FailedWithMessage(string message) => new(false, message, DateTime.Now, default);

    public static ApiResponse FailedWithException(Exception exception) =>
        new(false, exception.Message, DateTime.Now, default);

    public static ApiResponse FailedWithPayload(object payload) => new(false, FailureMessage, DateTime.Now, payload);

    public static ApiResponse FailedWithMessageAndPayload(string message, object payload) =>
        new(false, message, DateTime.Now, payload);
}