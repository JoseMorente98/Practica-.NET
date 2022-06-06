namespace SBODemoGT.Models
{
    public class Order
    {
        private string dateInit;
        private string dateFinish;
        private int groupNum;
        private int cardCode;

        public string DateInit { get => dateInit; set => dateInit = value; }
        public string DateFinish { get => dateFinish; set => dateFinish = value; }
        public int GroupNum { get => groupNum; set => groupNum = value; }
        public int CardCode { get => cardCode; set => cardCode = value; }
    }
}
