namespace M4Facturation.Application.ResponseDto.Common
{
    public class FilterPaged
    {
        [Required] public int Page { get; set; }
        [Required] public int PageSize { get; set; }
    }
}