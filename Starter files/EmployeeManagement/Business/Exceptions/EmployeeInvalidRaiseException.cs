namespace EmployeeManagement.Business.Exceptions
{
    public class EmployeeInvalidRaiseException : Exception
    {
        public int InvalidRaise { get; private set; }
        public EmployeeInvalidRaiseException(string message, int raise): 
            base(message)
        {
            InvalidRaise = raise;
        }
    }
}
