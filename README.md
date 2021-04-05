BUILD AND RUN

In VS Package Manager Console:

1. sqllocaldb start "MSSQLLocalDB" 
2. Update-Database. This command creates DB structure from EF Migration.
3. Run SQL script 'fill_database.sql' for MSSQLLocalDB. The script will fill the test data into the database.

Run Web application.

==========================================================================

Not implemented yet:
1. Import/Export guests from/to CSV.
2. Some validation.
3. Stability and performance.
