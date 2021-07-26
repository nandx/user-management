using System;
using FluentNHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Model
{
    public class AppUser : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        
        public virtual string CreatedBy { get; set; }
    }

    public class AppUserMap : ClassMap<AppUser>
    {
        public AppUserMap()
        {
            Table("app_user");

            Id(x => x.Id).Column("id").GeneratedBy.Identity();
            Map(x => x.Username).Column("username").Unique().Not.Nullable();
            Map(x => x.Password).Column("password").Not.Nullable();
            Map(x => x.CreatedBy).Column("created_by");
        }
    }
}