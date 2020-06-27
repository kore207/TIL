using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkStrudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var db = new EfStudyDbContext())
            {
                var userList = db.Users;

                foreach (var user in userList)
                {
                    Console.WriteLine(user.UserName);
                }
            }
        }
    }

    public class EfStudyDbContext : DbContext //DB context를 상속 받음.
    {
        public DbSet<User> Users { get; set; } //테이블 명과 일치시켜야 한다.

        //local DB 와 Db Context 를 연결해주는 connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //붙여넣기한 \ (escape) 오류는 \\ 하거나 @를 붙여서 오류를 해결한다.
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AspnetCoreDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Birth { get; set; }
    }
}
