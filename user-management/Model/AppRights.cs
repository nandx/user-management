using FluentNHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Model
{
    public class AppRights : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string RightsCode { get; set; }
        
        public virtual string RightsName { get; set; }
    }
    
    public class AppRightsMap : ClassMap<AppRights>
    {
        public AppRightsMap()
        {
            Table("app_rights");
            
            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(x => x.RightsCode).Column("rights_code").Unique().Not.Nullable();
            Map(x => x.RightsName).Column("rights_name").Not.Nullable();
        }
    }
    
}