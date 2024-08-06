// ZadDbContextFactory.cs
using ZadProject.Data; // Import your database context

public class ZadDbContextFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ZadDbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ZadDbContext CreateDbContext()
    {
        return _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ZadDbContext>();
    }
}