namespace Domain.Entities
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }
        public virtual bool Archived { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual bool IsAdmin { get; set; }
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
