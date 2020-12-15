using System.Reflection;
using System.Runtime.Loader;

namespace DomainHomeWork
{
    public class DllLoadContext : AssemblyLoadContext
    {
        public DllLoadContext() : base(true)
        {

        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }
}