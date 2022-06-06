using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class GroupClientBAL
    {
        private readonly static GroupClientBAL instance = new GroupClientBAL();
        public static GroupClientBAL Instance { get { return instance; } }

        public List<GroupClient> GetGroupClients()
        {
            return GroupClientDAL.Instance.GetGroupClients();
        }
    }
}
