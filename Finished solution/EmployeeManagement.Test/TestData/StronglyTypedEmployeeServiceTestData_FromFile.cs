using Xunit;

namespace EmployeeManagement.Test.TestData
{
    public class StronglyTypedEmployeeServiceTestData_FromFile : TheoryData<int,bool>
    {
        public StronglyTypedEmployeeServiceTestData_FromFile()
        {
            var testDataLines = File.ReadAllLines("TestData/EmployeeServiceTestData.csv");
         
            foreach (var line in testDataLines)
            {
                // split the string
                var splitString = line.Split(',');
                // try parsing 
                if (int.TryParse(splitString[0], out int raise)
                    && bool.TryParse(splitString[1], out bool minimumRaiseGiven))
                {
                    // add test data
                    Add(raise, minimumRaiseGiven);
                }
            }
        }
    }
}
