using System.Threading;

namespace CompanyFramework
{
    public class ClassForTesting
    {
        public bool MethodForTesting()
        {
            Thread.Sleep(4000);
            return true;
        }
    }
}