// See https://aka.ms/new-console-template for more information

var assembly =
            AppDomain
                .CurrentDomain
.GetAssemblies();

if (assembly == null)
    Console.WriteLine("No assembly found");
else
    foreach (var item in assembly)
    {
        Console.WriteLine(item.FullName);
    }

Type t = typeof(TNTExpressConnectRequest.Tests.ExpressConnectShippingTestsOrdering);
Console.WriteLine(t.Assembly.FullName);