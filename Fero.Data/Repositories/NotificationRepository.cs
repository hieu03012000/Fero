using Fero.Data.Models;
using Fero.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace Fero.Data.Repositories
{
    public partial interface INotificationRepository :IBaseRepository<Notification>
    {
    }
    public partial class NotificationRepository :BaseRepository<Notification>, INotificationRepository
    {
         public NotificationRepository(DbContext dbContext) : base(dbContext)
         {
         }
    }
}

