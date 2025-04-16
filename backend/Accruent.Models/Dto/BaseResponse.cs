namespace Accruent.Models.Dto
{
    public sealed class BaseResponse<T>
    {
        public T Data { get; set; } = default!;
        public int TotalRecords {  get; set; }
    }
}
