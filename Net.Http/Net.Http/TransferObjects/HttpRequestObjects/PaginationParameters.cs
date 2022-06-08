using System.Text.Json.Serialization;

namespace Back.Zone.Net.Http.TransferObjects.HttpRequestObjects;

public sealed record PaginationParameters(
    [property: JsonPropertyName("page")] int Page
)
{
    private readonly int _pageSize;

    [property: JsonPropertyName("page_size")]
    public int PageSize
    {
        get => _pageSize;

        init
        {
            _pageSize = value switch
            {
                0 => 10,
                > 100 => 100,
                _ => value
            };
        }
    }

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
        new(page) { PageSize = pageSize };

    public static PaginationParameters WithDefaults() => BuildFrom(1, 10);
}