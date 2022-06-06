namespace EntityLayer
{
    public class Orders
    {
        private int docEntry;
        private int docNum;
        private int cardCode;
        private string cardName;
        private int groupNum;
        private string groupName;
        private string docDate;
        private decimal docTotal;
        private int numAtCard;
        private List<OrderDetail> details = new List<OrderDetail>();

        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int DocNum { get => docNum; set => docNum = value; }
        public int CardCode { get => cardCode; set => cardCode = value; }
        public string CardName { get => cardName; set => cardName = value; }
        public int GroupNum { get => groupNum; set => groupNum = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string DocDate { get => docDate; set => docDate = value; }
        public decimal DocTotal { get => docTotal; set => docTotal = value; }
        public int NumAtCard { get => numAtCard; set => numAtCard = value; }
        public List<OrderDetail> Details { get => details; set => details = value; }
    }
}