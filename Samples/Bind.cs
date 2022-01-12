// See https://aka.ms/new-console-template for more information

using Novell.Directory.Ldap;

var ldapHost = "localhost";
var port = 389;
var bindDN = "cn=admin,dc=example,dc=org";
var password = "admin";

try
{
    var conn = new LdapConnection();
    Console.WriteLine("Connecting to:" + ldapHost);
    await conn.ConnectAsync(ldapHost, port);
    await conn.BindAsync(bindDN, password);
    Console.WriteLine(" Bind Successfull");
    conn.Disconnect();   
}
catch (LdapException e)
{
    Console.WriteLine("Error:" + e.LdapErrorMessage);
    return;
}
catch (Exception e)
{
    Console.WriteLine("Error:" + e.Message);
    return;
}

