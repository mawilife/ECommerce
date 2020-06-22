using System;

namespace ECommerce.Data.Configuration
{
    public interface IDatabaseConfig
    {
        string ConnectionString { get; }
        string DatabaseName { get; }
        string Table { get; }

    }
}
