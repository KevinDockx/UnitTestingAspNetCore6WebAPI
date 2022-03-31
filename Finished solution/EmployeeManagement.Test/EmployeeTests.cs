using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            // Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";

            // Assert
            Assert.Equal("Lucia Shelton", employee.FullName, ignoreCase:true);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
        {
            // Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithFirstName()
        {
            // Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            // Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.Contains("ia Sh", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            // Arrange
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }
    }
}
