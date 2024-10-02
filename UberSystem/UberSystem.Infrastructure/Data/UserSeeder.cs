using Microsoft.EntityFrameworkCore;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;

namespace UberSystem.Infrastructure.Data
{
    public static class UserSeeder
    {
        public static void SeedUserInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("4407944b-ce49-4ca4-990a-4acbc9a644e0"),
                    UserName = "UberSystem Admin",
                    Email = "ubersystem.admin.123@example.com",
                    Password = "uberad123!",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = new Guid("98388595-6f18-4518-acb1-0718fd336864"),
                    UserName = "Trần Minh Toàn",
                    Email = "totrogias@gmail.com",
                    Password = "matkhau123!",
                    EmailVerified = true,
                    Role = UserRole.Driver,
                },
                new User
                {
                    Id = new Guid("dced0a0e-ca60-4014-b23d-796c5d4d3a02"),
                    UserName = "janedoe",
                    Email = "jane.doe@ubersystem.com",
                    Password = "secure_x1!_password",
                    EmailVerified = true,
                    Role = UserRole.Customer,
                }
            );
        }
    }
}
