using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface IMessageRepository :IBaseRepository<Message>
    {
    }
    public partial class MessageRepository :BaseRepository<Message>, IMessageRepository
    {
         public MessageRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

