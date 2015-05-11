namespace Domain.Entities
{
    public class UserTypeEntity : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long ProjectId { get; set; }
        public virtual bool Archived { get; set; }
        public virtual string UserTypeName { get; set; }
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
