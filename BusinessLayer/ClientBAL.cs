using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class ClientBAL
    {
        private readonly static ClientBAL instance = new ClientBAL();
        public static ClientBAL Instance { get { return instance; } }

        public List<Client> GetClients()
        {
            return ClientDAL.Instance.GetClients();
        }
    }
}
