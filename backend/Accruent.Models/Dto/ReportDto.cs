namespace Accruent.Models.Dto
{
    public sealed class ReportDto
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Inbounds { get; set; }
        public int Outbounds { get; set; }
        public int Balance { get; set; }
    }
}
