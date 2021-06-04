using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface IMessageService:IBaseService<Message>
    {
    }
    public partial class MessageService:BaseService<Message>,IMessageService
    {
        public MessageService(IMessageRepository repository):base(repository){}
    }
}
