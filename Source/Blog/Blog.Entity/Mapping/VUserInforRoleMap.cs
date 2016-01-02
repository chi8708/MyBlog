using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Mapping
{
    public class VUserInforRoleMap : EntityTypeConfiguration<VUserInfoRole>
    {
        public VUserInforRoleMap() 
        {
            // Table & Column Mappings
            this.ToTable("V_UserInfo_Role");

            // Primary Key
            this.HasKey(t => t.UserInfo.Id);

            // Properties
            this.Property(t => t.UserInfo.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("Id");

            this.Property(t => t.UserInfo.Address)
                .HasColumnName("Address");

            this.Property(t => t.UserInfo.CreateTime).HasColumnName("CreateTime");

            this.Property(t => t.UserInfo.EditeTime).HasColumnName("EditeTime");

            this.Property(t => t.UserInfo.Editor).HasColumnName("Editor");

            this.Property(t => t.UserInfo.Email).HasColumnName("Email");

            this.Property(t => t.UserInfo.Gender).HasColumnName("Gender");

            this.Property(t => t.UserInfo.Password).HasColumnName("Password");

            this.Property(t => t.UserInfo.UserName).HasColumnName("UserName");

        }
    }
}
