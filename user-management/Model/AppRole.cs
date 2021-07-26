using FluentNHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Model
{
    public class AppRole : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Rolecode { get; set; }
        
        public virtual string Rolename { get; set; }
    }

    public class AppRoleMap : ClassMap<AppRole>
    {
        public AppRoleMap()
        {
            Table("app_role");
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(x => x.Rolecode).Column("role_code").Unique().Not.Nullable();
            Map(x => x.Rolename).Column("role_name").Not.Nullable();
        }
    }
}