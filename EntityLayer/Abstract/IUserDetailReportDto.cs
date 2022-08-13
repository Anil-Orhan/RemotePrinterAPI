namespace EntityLayer.Abstract
{
    public interface IUserDetailReportDto : IDto, IEntity
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string userFullName { get; set; }
        public double TotalExpense { get; set; }
        public double TotalBalance { get; set; }
        public double TotalPageAmounth { get; set; }
        public int DatedTransactionAmount { get; set; }
        public int IncorrectTransactionAmount { get; set; }

    }
}
