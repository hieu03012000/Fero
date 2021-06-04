using Fero.Data.Models;
using Fero.Data.Repositories;
using Fero.Data.Services.Base;

namespace Fero.Data.Services
{
    public partial interface INotificationService:IBaseService<Notification>
    {
    }
    public partial class NotificationService:BaseService<Notification>,INotificationService
    {
        public NotificationService(INotificationRepository repository):base(repository){}
    }
}
