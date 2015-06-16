namespace POC.Repository.Model
{
    public class Entity
    {
        public virtual int Id { get; set; }
        public virtual int PublishingSourceId { get; set; }
        public virtual string CallbackUrl { get; set; }
        public virtual string CallbackParams { get; set; }
        public virtual string RecordStatus { get; set; }
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual int ClosePeriodId { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual int DefinitionId { get; set; }
        public virtual int TaskTreeId { get; set; }

    }
}
