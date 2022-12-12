namespace Vindly1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vindly1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vindly1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vindly1.Models.ApplicationDbContext context)
        {
            MembershipType m1 = new MembershipType() { Id = 1, Name = "Pay as You Go", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 };
            MembershipType m2 = new MembershipType() { Id = 2, Name = "Monthly", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 };
            MembershipType m3 = new MembershipType() { Id = 3, Name = "Quarterly", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 };

            context.MembershipTypes.AddOrUpdate(m => m.Name, m1, m2, m3);

            Customer c1 = new Customer() { Id = 1, Name = "kostas", IsSubscidedToNewsletter = true, Birthdate = new DateTime(2009, 06, 02), MembershipTypeId = 1 };
            Customer c2 = new Customer() { Id = 2, Name = "zaraftis", IsSubscidedToNewsletter = true, Birthdate = new DateTime(2009, 07, 02), MembershipTypeId = 2 };
            Customer c3 = new Customer() { Id = 3, Name = "Tom", IsSubscidedToNewsletter = true, Birthdate = new DateTime(2009, 010, 02), MembershipTypeId = 3 };
            context.Customers.AddOrUpdate(c => c.Name, c1, c2, c3);

            Movie l1 = new Movie() { Id = 1, Name = "Tom Gun", IsRental = true, CustomerId=1 };
            Movie l2 = new Movie() { Id = 2, Name = "Tom Gun2", IsRental = true, CustomerId=2 };
            Movie l3 = new Movie() { Id = 3, Name = "Tom Gun3", IsRental = true, CustomerId=3 };
            context.Movies.AddOrUpdate(i => i.Name, l1, l2, l3);

        }
    }
}
