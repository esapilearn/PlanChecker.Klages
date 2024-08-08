using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESAPIX_WPF_Example.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Constraints;

namespace ESAPIX_WPF_Example.ViewModels.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void CTDateConstraintFailsCorrectly()
        {
            //Arrange
            var ctDate = DateTime.Now.AddDays(-61);

            //Act
            var actual = new CTDateConstraint().ConstrainDateOnly(ctDate).ResultType;

            //Assert
            var expected = ResultType.ACTION_LEVEL_3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CTDateConstraintPassesCorrectly()
        {
            //Arrange
            var ctDate = DateTime.Now.AddDays(-59);

            //Act
            var actual = new CTDateConstraint().ConstrainDateOnly(ctDate).ResultType;

            //Assert
            var expected = ResultType.PASSED;
            Assert.AreEqual(expected, actual);
        }
    }
}