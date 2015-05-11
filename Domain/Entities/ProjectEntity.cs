namespace Domain.Entities
{
    public class ProjectEntity : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long UserId { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string ProjectDescription { get; set; }
        public virtual bool Archived { get; set; }
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
