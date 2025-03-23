using System;
using System.Reflection;

try
{
    Assembly assembly = Assembly.LoadFrom("LibTask2.dll");                 

    Type phoneType = assembly.GetType("LibTask2.Phone");        
    Type manufacturerType = assembly.GetType("LibTask2.Manufacturer");

    if (phoneType == null || manufacturerType == null)
    {
        throw new Exception("Classes are not found in assembly!");
    }

    MethodInfo createPhoneMethod = phoneType.GetMethod("Create")!;
    object[] parameters = { 1, "Nokia 3310", "123456789", "mobile" };
    object phoneInstance = createPhoneMethod.Invoke(null, parameters);

    MethodInfo createManufacturerMethod = manufacturerType.GetMethod("Create")!;
    object[] manufacturerParams = { "Nokia", "Helsinki, Finland", false };
    object manufacturerInstance = createManufacturerMethod.Invoke(null, manufacturerParams);

    if (phoneInstance == null || manufacturerInstance == null)
    {
        throw new Exception("Creation of instances was unsuccessfull!");
    }
    phoneType.GetMethod("PrintObject")?.Invoke(phoneInstance, null);        
    manufacturerType.GetMethod("PrintObject")?.Invoke(manufacturerInstance, null);   
}        
catch (Exception ex)
{       
    Console.WriteLine($"Error {ex.Message}");        
}       