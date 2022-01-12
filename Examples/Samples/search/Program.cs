// See https://aka.ms/new-console-template for more information

using Novell.Directory.Ldap;

var ldapHost = "localhost";
var port = 389;
var bindDN = "cn=admin,dc=example,dc=org";
var password = "admin";
var baseDN = "dc=example,dc=org";
var filter = "(objectclass=*)";
// var attrs = new string[] { "dn", "cn" };
var attrs = Array.Empty<string>();

var conn = new LdapConnection();
Console.WriteLine("Connecting to:" + ldapHost);
try
{
    await conn.ConnectAsync(ldapHost, port);
    Console.WriteLine($"Connectd to {ldapHost}");
    await conn.BindAsync(bindDN, password);
    Console.WriteLine(" Bind Successfull");
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

var res = await conn.SearchAsync(baseDN, LdapConnection.ScopeSub, filter, null, false);

await res.ForEachAsync((entity) =>
{
    Console.WriteLine($"Dn: \t{entity.Dn}");
    entity.GetAttributeSet().ToList().ForEach((item) => {
        Console.WriteLine($"key: \t{item.Key}, \tvalue: \t{item.Value}");
    });
});

conn.Disconnect();
