using EntityLayer;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class OrdersDAL
    {
        private readonly static OrdersDAL instance = new OrdersDAL();
        public static OrdersDAL Instance { get { return instance; } }

        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();
            SqlConnection connection = new SqlConnection(StringConnection.Instance.connectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ListarPedidos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if(reader != null)
                {
                    int posDocEntry = reader.GetOrdinal("DocEntry");
                    int posDocNum = reader.GetOrdinal("DocNum");
                    int posCardCode = reader.GetOrdinal("CardCode");
                    int posCardName = reader.GetOrdinal("CardName");
                    int posDocDate = reader.GetOrdinal("DocDate");
                    int posDocTotal = reader.GetOrdinal("DocTotal");
                    int posNumAtCard = reader.GetOrdinal("NumAtCard");
                    int posGroupNum = reader.GetOrdinal("GroupNum");
                    int posGroupName = reader.GetOrdinal("GroupName");

                    Orders order;

                    while (reader.Read())
                    {
                        order = new Orders();
                        order.DocEntry = reader.IsDBNull(posDocEntry) ? 0 : reader.GetInt32(posDocEntry);
                        order.DocNum = reader.IsDBNull(posDocNum) ? 0 : reader.GetInt32(posDocNum);
                        order.CardCode = reader.IsDBNull(posCardCode) ? 0 : reader.GetInt32(posCardCode);
                        order.CardName = reader.IsDBNull(posCardName) ? "" : reader.GetString(posCardName);
                        order.DocDate = reader.IsDBNull(posDocDate) ? "" : reader.GetDateTime(posDocDate).ToString();
                        order.DocTotal = reader.IsDBNull(posDocTotal) ? 0 : reader.GetDecimal(posDocTotal);
                        order.NumAtCard = reader.IsDBNull(posNumAtCard) ? 0 : reader.GetInt32(posNumAtCard);
                        order.GroupNum = reader.IsDBNull(posGroupNum) ? 0 : reader.GetInt32(posGroupNum);
                        order.GroupName = reader.IsDBNull(posGroupName) ? "" : reader.GetString(posGroupName);
                        orders.Add(order);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }

            return orders;
        }

        public Orders GetOrder(int docEntry)
        {
            Orders order = new Orders();

            SqlConnection connection = new SqlConnection(StringConnection.Instance.connectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ListarPedido", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@docEntry", docEntry);

                SqlDataReader reader = command.ExecuteReader();

                if (reader != null)
                {
                    int posDocEntry = reader.GetOrdinal("DocEntry");
                    int posDocNum = reader.GetOrdinal("DocNum");
                    int posCardCode = reader.GetOrdinal("CardCode");
                    int posCardName = reader.GetOrdinal("CardName");
                    int posDocDate = reader.GetOrdinal("DocDate");
                    int posDocTotal = reader.GetOrdinal("DocTotal");
                    int posNumAtCard = reader.GetOrdinal("NumAtCard");
                    int posGroupNum = reader.GetOrdinal("GroupNum");
                    int posGroupName = reader.GetOrdinal("GroupName");

                    while (reader.Read())
                    {
                        order.DocEntry = reader.IsDBNull(posDocEntry) ? 0 : reader.GetInt32(posDocEntry);
                        order.DocNum = reader.IsDBNull(posDocNum) ? 0 : reader.GetInt32(posDocNum);
                        order.CardCode = reader.IsDBNull(posCardCode) ? 0 : reader.GetInt32(posCardCode);
                        order.CardName = reader.IsDBNull(posCardName) ? "" : reader.GetString(posCardName);
                        order.DocDate = reader.IsDBNull(posDocDate) ? "" : reader.GetDateTime(posDocDate).ToString();
                        order.DocTotal = reader.IsDBNull(posDocTotal) ? 0 : reader.GetDecimal(posDocTotal);
                        order.NumAtCard = reader.IsDBNull(posNumAtCard) ? 0 : reader.GetInt32(posNumAtCard);
                        order.GroupNum = reader.IsDBNull(posGroupNum) ? 0 : reader.GetInt32(posGroupNum);
                        order.GroupName = reader.IsDBNull(posGroupName) ? "" : reader.GetString(posGroupName);
                    }

                }

                if(reader.NextResult())
                {
                    int posDocEntry = reader.GetOrdinal("DocEntry");
                    int posItemCode = reader.GetOrdinal("ItemCode");
                    int posItemName = reader.GetOrdinal("ItemName");
                    int posLineTotal = reader.GetOrdinal("LineTotal");
                    int posVatSum = reader.GetOrdinal("VatSum");

                    OrderDetail orderDetail;
                    while (reader.Read())
                    {
                        orderDetail = new OrderDetail();
                        orderDetail.DocEntry = reader.IsDBNull(posDocEntry) ? 0 : reader.GetInt32(posDocEntry);
                        orderDetail.ItemCode = reader.IsDBNull(posItemCode) ? 0 : reader.GetInt32(posItemCode);
                        orderDetail.ItemName = reader.IsDBNull(posItemName) ? "" : reader.GetString(posItemName);
                        orderDetail.LineTotal = reader.IsDBNull(posLineTotal) ? 0 : reader.GetDecimal(posLineTotal);
                        orderDetail.VatSum = reader.IsDBNull(posVatSum) ? 0 : reader.GetDecimal(posVatSum);
                        order.Details.Add(orderDetail);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }

            return order;
        }

        public List<Orders> FilterOrders(string dateInit, string dateFinish, int groupNum, int cardCode)
        {
            List<Orders> orders = new List<Orders>();
            SqlConnection connection = new SqlConnection(StringConnection.Instance.connectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("FiltrarOrden", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@groupNum", groupNum == 0 ? "": groupNum);
                command.Parameters.AddWithValue("@cardCode", cardCode == 0 ? "": cardCode);
                command.Parameters.AddWithValue("@dateInit", dateInit == null ? "":dateInit);
                command.Parameters.AddWithValue("@dateFinish", dateFinish == null ? "": dateFinish);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (reader != null)
                {
                    int posDocEntry = reader.GetOrdinal("DocEntry");
                    int posDocNum = reader.GetOrdinal("DocNum");
                    int posCardCode = reader.GetOrdinal("CardCode");
                    int posCardName = reader.GetOrdinal("CardName");
                    int posDocDate = reader.GetOrdinal("DocDate");
                    int posDocTotal = reader.GetOrdinal("DocTotal");
                    int posNumAtCard = reader.GetOrdinal("NumAtCard");
                    int posGroupNum = reader.GetOrdinal("GroupNum");
                    int posGroupName = reader.GetOrdinal("GroupName");

                    Orders order;

                    while (reader.Read())
                    {
                        order = new Orders();
                        order.DocEntry = reader.IsDBNull(posDocEntry) ? 0 : reader.GetInt32(posDocEntry);
                        order.DocNum = reader.IsDBNull(posDocNum) ? 0 : reader.GetInt32(posDocNum);
                        order.CardCode = reader.IsDBNull(posCardCode) ? 0 : reader.GetInt32(posCardCode);
                        order.CardName = reader.IsDBNull(posCardName) ? "" : reader.GetString(posCardName);
                        order.DocDate = reader.IsDBNull(posDocDate) ? "" : reader.GetDateTime(posDocDate).ToString();
                        order.DocTotal = reader.IsDBNull(posDocTotal) ? 0 : reader.GetDecimal(posDocTotal);
                        order.NumAtCard = reader.IsDBNull(posNumAtCard) ? 0 : reader.GetInt32(posNumAtCard);
                        order.GroupNum = reader.IsDBNull(posGroupNum) ? 0 : reader.GetInt32(posGroupNum);
                        order.GroupName = reader.IsDBNull(posGroupName) ? "" : reader.GetString(posGroupName);
                        orders.Add(order);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }

            return orders;
        }
    }
}