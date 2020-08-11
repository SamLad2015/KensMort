namespace KensMort.Entities
{
    public class PortfolioEntity: BaseEntity
    {
        public string PortfolioName { get; set; }
        public long CategoryId { get; set; }
    }
}