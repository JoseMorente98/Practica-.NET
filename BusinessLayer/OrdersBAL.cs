using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class OrdersBAL
    {
        private readonly static OrdersBAL instance = new OrdersBAL();
        public static OrdersBAL Instance { get { return instance; } }

        public List<Orders> GetOrders()
        {
            return OrdersDAL.Instance.GetOrders();
        }

        public Orders GetOrder(int docEntry)
        {
            return OrdersDAL.Instance.GetOrder(docEntry);
        }

        public List<Orders> FilterOrders(string dateInit, string dateFinish, int groupNum, int cardCode)
        {
            return OrdersDAL.Instance.FilterOrders(dateInit, dateFinish, groupNum, cardCode);
        }
    }
}