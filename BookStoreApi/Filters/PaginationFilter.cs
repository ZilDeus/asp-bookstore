namespace BookStoreApi.Filters;
public class PaginationFilter
{
  public int CurrentPage { get; set; }
  public int PageSize { get; set; }
  public PaginationFilter()
  {
    this.CurrentPage = 1;
    this.PageSize = 10;
  }
  public PaginationFilter(int pageNumber, int pageSize)
  {
    this.CurrentPage = pageNumber < 1 ? 1 : pageNumber;
    this.PageSize = pageSize > 10 ? 10 : pageSize;
  }
}
