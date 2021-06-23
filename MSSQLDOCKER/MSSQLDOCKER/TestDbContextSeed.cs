using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MSSQLDOCKER
{
    public static class TestDbContextSeed
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var context = new TestDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TestDbContext>>()))
            {
                context.Database.Migrate();
                if(context.TestEntries.Any()) return;
                context.TestEntries.Add(new TestEntry() {TestText = "test"});
                context.SaveChanges();
            }
        }
    }
}
