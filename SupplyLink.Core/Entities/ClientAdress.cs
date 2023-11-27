using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyLink.Core.Entities
{
    public  class ClientAdress : BaseEntity
    {
        public ClientAdress(int idClient, int idAdress)
        {
            IdClient = idClient;
            IdAdress = idAdress;
        }

        public int IdClient { get; private set; }
        public int IdAdress { get; private set; }
    }
}
