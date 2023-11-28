db-execute-migrations:
	dotnet ef database update
	
db-start-migrations:
	dotnet ef migrations add InitialCreate