using System.Collections.Generic;
using System.Text.Json.Serialization;
using Back.Zone.Net.Http.TransferObjects.HttpRequestObjects;

namespace Back.Zone.Net.Http.TransferObjects.HttpResponseObjects;

public sealed record PaginatedApiResponse<TPayload>(
    [property: JsonPropertyName("previous_page")]
    int? PreviousPage,
    [property: JsonPropertyName("current_page")]
    int CurrentPage,
    [property: JsonPropertyName("next_page")]
    int? NextPage,
    [property: JsonPropertyName("total_pages")]
    long TotalPages,
    [property: JsonPropertyName("total_records")]
    long TotalRecords,
    [property: JsonPropertyName("page_size")]
    int PageSize,
    [property: JsonPropertyName("payload")]
    List<TPayload> Payload
)
{
    public static PaginatedApiResponse<TPayload> BuildFrom(
        long totalRecords,
        PaginationParameters paginationParameters,
        List<TPayload> payload)
    {
        var pageSize = paginationParameters.PageSize == 0 ? 10 : paginationParameters.PageSize;
        var currentPage = paginationParameters.QueryPage;
        var totalPages = totalRecords / pageSize + (totalRecords % pageSize == 0 ? 0 : 1);

        int? previousPage = null;
        int? nextPage = null;

        if (currentPage - 1 >= 0)
            previousPage = currentPage - 1;

        if (currentPage + 1 <= totalPages)
            nextPage = currentPage + 1;

        return new PaginatedApiResponse<TPayload>(
            previousPage,
            currentPage,
            nextPage,
            totalPages,
            totalRecords,
            pageSize,
            payload);
    }
}