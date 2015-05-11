namespace Domain.Entities
{
    public class UserHistoryEntity : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long ProjectId { get; set; }
        public virtual bool Archived { get; set; }
        public virtual string UserType { get; set; }
        public virtual string Goal { get; set; }
        public virtual string Reason { get; set; }
        public virtual void Archive()
        {
            Archived = true;
        }

        public virtual void Activate()
        {
            Archived = false;
        }
    }
}
