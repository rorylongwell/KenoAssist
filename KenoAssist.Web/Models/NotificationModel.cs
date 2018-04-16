using System;
namespace KenoAssist.Web.Models
{
    public class NotificationModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
