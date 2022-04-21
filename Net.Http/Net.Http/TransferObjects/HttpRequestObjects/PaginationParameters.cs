using System.Text.Json.Serialization;

namespace Back.Zone.Net.Http.TransferObjects.HttpRequestObjects;

public sealed record PaginationParameters(
    [property: JsonPropertyName("page")] int Page,
    [property: JsonPropertyName("page_size")]
    int PageSize
)
{
    public int QueryPage => Page switch
    {
        0 => 1,
        1 => 1,
        _ => Page
    };

    public int RealPage => Page switch
    {
        0 => 0,
        1 => 0,
        _ => Page - 1
    };

    public static PaginationParameters BuildFrom(int page, int pageSize) =>
        new(page, pageSize);

    public static PaginationParameters WithDefaults() => BuildFrom(1, 10);
}