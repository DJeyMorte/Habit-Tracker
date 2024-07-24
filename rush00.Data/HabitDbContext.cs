using Microsoft.EntityFrameworkCore;
using System.Data;
using rush00.Models;

namespace rush00.Data;
public class HabitDbContext : DbContext
{
    public DbSet<Habit>? Habits {get; set;}
    public DbSet<HabitCheck>? HabitChecks {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
	optionsBuilder.UseSqlite("Filename=../rush00.Data/habits.db");
    }
}


//  <!-- Код для подключения Sqlite -->
// <?xml version="1.0" encoding="utf-8"?>
// <configuration>
//   <configSections>
//     <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
//   </configSections>
//   <connectionStrings>
//     <add name="DefaultConnection" connectionString="Data Source=.\habits.db" providerName="System.Data.SQLite" />  <!--  Здесь меняем название бд -->
//   </connectionStrings>
//   <startup>
//     <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
//   </startup>
//   <entityFramework>
//     <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
//       <parameters>
//         <parameter value="v11.0" />
//       </parameters>
//     </defaultConnectionFactory>
//     <providers>
//       <provider invariantName="System.Data.SQLite"  type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6"/>
//       <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
//       <provider invariantName="System.Data.SQLite.EF6" type="System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6" />
//     </providers>
//   </entityFramework>
//   <system.data>
//     <DbProviderFactories>
//       <add name="SQLite Data Provider (Entity Framework 6)" invariant="System.Data.SQLite.EF6" description=".NET Framework Data Provider for SQLite (Entity Framework 6)" type="System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6" />
//       <add name="SQLite Data Provider" invariant="System.Data.SQLite" description=".NET Framework Data Provider for SQLite" type="System.Data.SQLite.SQLiteFactory, System.Data.SQLite" />
//   </DbProviderFactories>
//   </system.data>
// </configuration> 