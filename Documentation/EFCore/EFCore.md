# EF Core

## New Features on 2.1

### EF6
* Lazy loading 
* GroupBy Translation
* Data seeding
* System.Transaction

### New
* Change tracking events
* Query Types
* Values Conversions

## Seeding

* Migration
```PS1
add-migration init
add-migration nochanges
```

* HasData
```C#
modelBuilder.Entity<BrewerType>().HasData(
    new BrewerType { BrewerTypeId = 1, Description = "Glass Hourglass Drip" },
    new BrewerType { BrewerTypeId = 2, Description = "Hand Press" },
    new BrewerType { BrewerTypeId = 3, Description = "Cold Brew" }
    );
```
* **The key value must be provided even if it's a auto increment column**

* Has data accepts anonymous types

```C#
modelBuilder.Entity<BrewerType>().HasData(
    new { BrewerTypeId = 1, Description = "Glass Hourglass Drip" },
    new { BrewerTypeId = 2, Description = "Hand Press" },
    new { BrewerTypeId = 3, Description = "Cold Brew" }
    );
```

* GUID Keys
    - you can't use hasdata to seed auto-generate values, they will be replaced becaouse of the neu value generated.

    - Use anonymous types, and use explicits GUID values.

* Own Types
    ```C#
    .OwnsOne(b => b.Recipe)
        .HasData(New {RecipeId = 1, ...})
    ```
    - Use anonymous type to seed because the owned type has no key, and EFCore needs the key
    - The properties on owned type will became columns on the parent table.

* EnsureCreated
    - EnsureCreate() Creates database if not exists
    - Builds from DbContext
    - Executes HasData on newly created database
    - Good for tests with in memory databases

* Migrate
    - Migrate() Creates or Migrates a database
    - Execute migrations

## Transactions

* TransactionScope, CommitableTransaction
* SQL Server, SQLCE, and PoestgerSQL Supported
* SQLite, and MySql **not** supported
* Distributed transactions **not** supported

* Share transactions across contexts using shared transaction
    - Share te options to use the same connection.
    - Use the ``context.Database.BeginTransaction()`` to get the transaction
    - Use the ``context2.Database.UseTransaction(transaction.GetDbTransaction());`` to force the use of the same transaction.
``` C#
var options = new DbContextOptionsBuilder<CoffeeShopContext>()
    .UseSqlite(new SqlConnection(sqlConnString)).Options;
var unit = new Unit { LocationId = 1, Acquired = DateTime.Now, BrewerTypeId = 1 };
using (var context = new CoffeeShopContext(options))
{
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Units.Add(unit);
            context.SaveChanges();
            var unitCount = context.Units.Where(l => l.LocationId == unit.LocationId).Count();
            using (var context2 = new CoffeeShopContext(options))
            {
                var milestone = new Milestone(1, DateTime.Now.Date, $"Unit #{unitCount} acquired for location");
                context2.Database.UseTransaction(transaction.GetDbTransaction());
                context2.Entry(milestone).State = EntityState.Added;
                Assert.AreEqual(1, context2.SaveChanges());
            }
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occured ({ex.Message})...transaction will rollback");
        }
    }
}
```

* Share transactions across contexts using transaction scope
    - Use ``new TransactionScope`` to create a scope.
    - Share te options to use the same connection.
    - use the ``scope.Complete();`` to commit the transaction.
``` C#
int resultCount = 0;
int unitCount = 0;
var unit = new Unit { LocationId = 1, Acquired = DateTime.Now, BrewerTypeId = 1 };
using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
{
    try
    {
        var options = new DbContextOptionsBuilder<CoffeeShopContext>()
                            .UseSqlServer(new SqlConnection(sqlConnString)).Options;
        using (var context = new CoffeeShopContext(options))
        {
            context.Units.Add(unit);
            context.SaveChanges();
            unitCount = context.Units.Where(l => l.LocationId == unit.LocationId).Count();
        }
        using (var context2 = new CoffeeShopContext(options))
        {
            var milestone = new Milestone(1, DateTime.Now.Date, $"Unit #{unitCount} acquired for location");
            context2.Entry(milestone).State = EntityState.Added;
            resultCount = context2.SaveChanges();
        }
        scope.Complete();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception occured ({ex.Message}, {ex.InnerException?.Message})...transaction will rollback");
    }
    Assert.AreEqual(1, resultCount);
}
```

## Events

* Change Tracker
    - Tracked - First time an object is tracked
        - Contains: EntityEntry, FromQuery bool
    - StateChanged - Any time tracked object changed.
        - Contains: EntityEntry, OldState, NewState


```C#
public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
: base(options)
{
    this.ChangeTracker.StateChanged += StateChanged;
    this.ChangeTracker.Tracked += Tracked;
}
private void StateChanged(object sender, EntityStateChangedEventArgs e)
{
    int idValue = GetKeyValue(e.Entry.Entity);
    Console.WriteLine($"State of {e.Entry.Entity.GetType()} with Id={idValue} changed from .OldState } to {e.NewState}");
}

private void Tracked(object sender, EntityTrackedEventArgs e)
{
    int idValue = GetKeyValue(e.Entry.Entity);
    Console.WriteLine($"Newly tracked {e.Entry.Entity.GetType()} with Id={idValue} as {e.Entry.State}");
}
```

## Lazy Loading

Lazy loading needs to be explicitly set, it will not start by default. 

### Proxies

* NuGet package: ``Microsof.EntityFramework.Proxies``
* **Mark all navigation properties with virtual**.
* Enable 'Lazy Loading'
    - ``optionBuilder.UseLazyLoadingProxies()``
    - ``context.ChangeTracker.LazyLoadingEnabled=true``
* doesn't work in UWP, Xamarin, and Web

### No Proxies

* Dependency injection
* Package: ``Microsoft.EntityFrameworkCore.Abstractions``
* Use in Model:
    ```C#
    public class Location
    {
        private List<Employee> _employees;
        public Location()
        {
            Employees = new List<Employee>();
        }
        public Location(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        public int LocationId { get; set; }
        public string StreetAddress { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public string Hours =>
            $"{new DateTime().Add(OpenTime).ToString("h:mm tt")}-{new DateTime().Add(CloseTime).ToString("h:mm tt")}";
        public List<Unit> BrewingUnits { get; set; }
        public List<Employee> Employees 
        { 
            get => LazyLoader.Load(this, ref _employees); 
            set => _employees = value; 
        }
    }
    ```

## Value Converters

**The values converter do not replace the mappings**.

### Using built-in converters

``using Microsoft.EntityFrameworkCore.Storage.ValueConversion;``

* Simple way

```C#
modelBuilder.Entity<Recipe>().Property(r => r.BrewTime).HasConversion(new TimeSpanToTicksConverter());
```

* Generic way

```C#
modelBuilder.Entity<Recipe>().Property(r => r.BrewTime).HasConversion<System.Int64>();
```

* Storing Enum as Strings

```C#
modelBuilder.Entity<Location>().Property(r => r.LocationType).HasConversion(new EnumToStringConverter<LocationType>());
```

###Using custom converters

* Using Lambda
```C#
modelBuilder.Entity<BrewerType>().Property(b => b.Color).HasConversion(c => c.Name, s => Color.FromName(s));
```

* Using ValueConverter Implementation
```C#
public class ColorValueConverter : ValueConverter<Color, String>
{
    public ColorValueConverter() : base(ColorString, ColorStruct)
    {
    }

    private static Expression<Func<string, Color>> ColorStruct = x => Color.FromName(x);
    
    private static Expression<Func<Color, string>> ColorString = x => x.Name;
}
```
```C#
modelBuilder.Entity<BrewerType>().Property(b => b.Color).HasConversion(new ColorValueConverter());
```

## GroupBy

* Simple key GroupBy
```C#
context.Units
.GroupBy(o => o.BrewerTypeId)
.Select(g => new 
{
    BrewerTypeId = g.Key,
    Cost = g.Sum(u => u.Cost),
    Count = g.Count()
}).ToList();
```

* Composite key GroupBy
```C#
context.Units
.GroupBy(o => new 
{
    BrewerTypeId = o.BrewerTypeId, 
    Color = o.Color.Name 
})
.Select(g => new 
{
    BrewerTypeId = g.Key.BrewerTypeId,
    Color = g.Key.Color,
    Cost = g.Sum(u => u.Cost),
    Count = g.Count()
}).ToList();
```

* Composite key GroupBy with relate data
```C#
context.Units
.GroupBy(o => new 
{
    BrewerTypeId = o.BrewerTypeId, 
    Color = o.Color.Name 
})
.Select(g => new 
{
    BrewerTypeId = g.Key.BrewerTypeId,
    Color = g.Key.Color,
    Cost = g.Sum(u => u.Cost),
    Count = g.Count()
}).ToList();
```

## References

[Entity Framework Documentation](https://docs.microsoft.com/en-us/ef/#pivot=efcore)







