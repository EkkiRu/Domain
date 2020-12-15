using System;
using System.Net.Http.Headers;

namespace DomainHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteAndUnload("Your code: 0159");

            GC.Collect();
            GC.WaitForPendingFinalizers();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Console.Read();
        }

        static void ExecuteAndUnload(string text)
        {
            var context = new DllLoadContext();

            var smsAssembly = context.LoadFromAssemblyPath(@"C:\Users\Mephistos\source\repos\SmsLibrary\bin\Debug\netcoreapp3.1\SmsLibrary.dll");

            var classType = smsAssembly.GetType("SmsLibrary.SmsMessageSender");
            var smsMethodInfo = classType.GetMethod("SendMessage");

            var classObject = Activator.CreateInstance(classType);
            var result = smsMethodInfo.Invoke(classObject, new object[]  { text } );

            Console.WriteLine(result);

            context.Unload();
        }
    }
}