using System;

namespace cs43_EF4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // phát sinh code dựa vào db sẵn có
            // dotnet ef dbcontext scaffold -o Models -d "sqlConnectionsstring" "Microsoft.EntityFramework.Core"

            //  "Data Source = localhost,1433; Initial Catalog = xtlab;User ID = sa;Password = CASter789"

            // dotnet ef dbcontext scaffold -o Models -d "Data Source = localhost,1433; Initial Catalog = xtlab;User ID = sa;Password = CASter789" "Microsoft.EntityFrameworkCore.SqlServer"
        }
    }
}
