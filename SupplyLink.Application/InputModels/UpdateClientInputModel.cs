using SupplyLink.Core.Enums;


namespace SupplyLink.Application.InputModels
{
    public class UpdateClientInputModel
    {
        public UpdateClientInputModel(int id, string name, ClientStatusEnum status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public ClientStatusEnum Status { get; private set; }
       
    }
}
