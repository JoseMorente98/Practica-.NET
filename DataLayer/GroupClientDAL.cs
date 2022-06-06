using EntityLayer;
using Microsoft.Data.SqlClient;

namespace DataLayer
{
    public class GroupClientDAL
    {
        private readonly static GroupClientDAL instance = new GroupClientDAL();
        public static GroupClientDAL Instance { get { return instance; } }

        public List<GroupClient> GetGroupClients()
        {
            List<GroupClient> groupClients = new List<GroupClient>();
            SqlConnection connection = new SqlConnection(StringConnection.Instance.connectionString());

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM GroupClients", connection);
                command.CommandType = System.Data.CommandType.Text;

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.SingleResult);

                if (reader != null)
                {
                    int posGroupNum = reader.GetOrdinal("GroupNum");
                    int posGroupName = reader.GetOrdinal("GroupName");

                    GroupClient group;

                    while (reader.Read())
                    {
                        group = new GroupClient();
                        group.GroupNum = reader.IsDBNull(posGroupNum) ? 0 : reader.GetInt32(posGroupNum);
                        group.GroupName = reader.IsDBNull(posGroupName) ? "" : reader.GetString(posGroupName);
                        groupClients.Add(group);
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                connection.Close();
            }

            return groupClients;
        }
    }
}
