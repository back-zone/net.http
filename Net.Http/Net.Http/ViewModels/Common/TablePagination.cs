using System;
using System.Collections.Generic;
using Back.Zone.Net.Http.TransferObjects.HttpResponseObjects;

namespace Back.Zone.Net.Http.ViewModels.Common;

public sealed record TablePagination(
    int? PreviousPage,
    int CurrentPage,
    int? NextPage,
    long TotalPages,
    int PageSize
)
{
    public List<int> GetPaginationNumbers(int firstPage = 1)
    {
        var paginationNumbers = new List<int>();
        var totalPages = (int)TotalPages;
        var paginationSize = totalPages switch
        {
            < 5 => totalPages,
            _ => 5
        };

        var startingPage = CurrentPage - paginationSize;
        startingPage = Math.Max(startingPage, firstPage);
        startingPage = Math.Min(startingPage, firstPage + totalPages - paginationSize);

        for (var i = 0; i < paginationSize; i++)
        {
            paginationNumbers.Add(startingPage + i);
        }

        return paginationNumbers;
    }

    public static TablePagination BuildFrom<T>(PaginatedApiResponse<T> paginatedResponse) =>
        new(
            paginatedResponse.PreviousPage,
            paginatedResponse.CurrentPage,
            paginatedResponse.NextPage,
            paginatedResponse.TotalPages,
            paginatedResponse.PageSize
        );
}