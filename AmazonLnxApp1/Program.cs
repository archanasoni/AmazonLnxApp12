// See https://aka.ms/new-console-template for more information
using IBM.Data.Db2;

Console.WriteLine("Hello, World!");
DB2Connection con = new DB2Connection();
con.ConnectionString = Environment.GetEnvironmentVariable("connectionstring"); ;
con.Open();
Console.WriteLine("Connection opened");