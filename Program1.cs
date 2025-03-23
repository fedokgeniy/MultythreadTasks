using System.Runtime.InteropServices;
using System.Reflection;
using LibTask2;

try
{
    Assembly assembly = Assembly.LoadFrom("LibTask2.dll");

    Console.WriteLine("Insert name of a class (with namespace, example: LibTask2.Phone):");
    string className = Console.ReadLine();

    Console.WriteLine("Insert name of a method (example: PrintObject):");
    string methodName = Console.ReadLine();

    Type type = assembly.GetType(className);
    if (type == null)
    {
        Console.WriteLine("Class not found");
        return;
    }

    object instance = Activator.CreateInstance(type, true);

    MethodInfo method = type.GetMethod(methodName);
    if (method == null)
    {
        Console.WriteLine("Method not found");
        return;
    }

    ParameterInfo[] parameters = method.GetParameters();
    object[] arg = new object[parameters.Length];

    for (int i = 0; i < parameters.Length; i++)
    {
        Console.WriteLine($"Insert {parameters[i].ParameterType.Name} argument:");
        string input = Console.ReadLine();
        arg[i] = Convert.ChangeType(Console.ReadLine(), parameters[i].ParameterType);
    }

    object result = method.Invoke(instance, arg);
    if (result != null)
    {
        Console.WriteLine($"Result: {result}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}