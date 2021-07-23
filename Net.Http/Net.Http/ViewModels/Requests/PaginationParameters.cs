namespace Back.Zone.Net.Http.ViewModels.Requests
{
    public sealed record PaginationParameters(
        int Page,
        int PageSize,
        int RealPage
    )
    {
        public static PaginationParameters From(int page, int pageSize) =>
            new(
                page switch
                {
                    0 => 1,
                    1 => 1,
                    _ => page
                },
                pageSize,
                page switch
                {
                    0 => 0,
                    1 => 0,
                    _ => page - 1
                }
            );

        public static PaginationParameters FromDefaultParameters() => From(1, 10);

        public static PaginationParameters FromDefaultPageSize(int page) => From(page, 10);

        public static PaginationParameters FromQueryParameters(int? page, int? pageSize)
        {
            if (page != null && pageSize != null)
            {
                return From(page.Value, pageSize.Value);
            }

            return From(1, 10);
        }
    }
}