This application uses Entity Framework together with ms sql server.
After downloading this repo to your local repository, to properly run this app you need to:
1) Set CashpointWeb as startup project
2) Change connenction string field in DAL.CashpointDBContext class to match your local ms sql server name
3) Open package manager console and run these 2 commands: 
add-migration createDb -Project DAL -StartupProject CashpointWeb
update-database -Project DAL -StartupProject CashpointWeb

After these 3 steps app should run on your device.
