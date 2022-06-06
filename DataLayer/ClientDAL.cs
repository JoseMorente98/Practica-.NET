using EntityLayer;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class ClientDAL
    {
        private readonly static ClientDAL instance = new ClientDAL();
        public static ClientDAL Instance { get { return instance; } }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            SqlConnection connection = new SqlConnection(StringConnection.Instance.connectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Clients", connection);
                command.CommandType = System.Data.CommandType.Text;

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (reader != null)
                {
                    int posCardCode = reader.GetOrdinal("CardCode");
                    int posCardName = reader.GetOrdinal("CardName");

                    Client client;

                    while (reader.Read())
                    {
                        client = new Client();
                        client.CardCode = reader.IsDBNull(posCardCode) ? 0 : reader.GetInt32(posCardCode);
                        client.CardName = reader.IsDBNull(posCardName) ? "" : reader.GetString(posCardName);
                        clients.Add(client);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }

            return clients;
        }
    }
}
