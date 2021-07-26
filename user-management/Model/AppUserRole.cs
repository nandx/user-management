using FluentNHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Model
{
    public class AppUserRole : IEntity
    {
        public virtual long Id { get; set; }

        public virtual AppUser appUser { get; set; }
        
        public virtual AppRole appRole { get; set; }
    }
    
    public class AppUserRoleMap : ClassMap<AppUserRole>
    {
        public AppUserRoleMap()
        {
            Table("app_userrole");
            
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            References(x => x.appUser).Column("app_user_id").Not.Nullable();
            References(x => x.appRole).Column("app_role_id").Not.Nullable();
        }
    }
}