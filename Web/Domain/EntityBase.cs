namespace Web.Domain
{
    using FluentNHibernate.Data;

    public abstract class EntityBase 
    {
        public virtual int Id { get;  set; }
    }
}