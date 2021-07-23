using System.Collections.Generic;
using Back.Zone.Net.Http.ViewModels.Common;
using Back.Zone.Net.Http.ViewModels.Requests;

namespace Back.Zone.Net.Http.ViewModels.Responses
{
    public sealed record PaginatedResponse<T>(
        int? PreviousPage,
        int CurrentPage,
        int? NextPage,
        long TotalPages,
        long TotalRecords,
        int PageSize,
        List<T> Records
    )
    {
        public static PaginatedResponse<T> From(
            long recordCount,
            PaginationParameters paginationParameters,
            List<T> records
        )
        {
            var (page, pageSize, _) = paginationParameters;
            var totalPages = recordCount / pageSize +
                             (recordCount % pageSize == 0 ? 0 : 1);

            int? previousPage = default;
            int? nextPage = default;

            if (page - 1 >= 1)
                previousPage = page - 1;

            if (page + 1 <= totalPages)
                nextPage = page + 1;

            return new PaginatedResponse<T>(
                previousPage,
                page,
                nextPage,
                totalPages,
                recordCount,
                pageSize,
                records
            );
        }

        public TablePagination GetTablePagination() =>
            new(PreviousPage, CurrentPage, NextPage, TotalPages, PageSize);
    }
}