
using System;
using EventMakerAssigment.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventMakerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private DateTimeConverter DateTimeConverter;

        //Arrange
        [TestInitialize]
        public void BeforeTest()
        {
            DateTimeConverter = new DateTimeConverter();
        }

        //Act & Assert
        [TestMethod]
        public void DateTimeConverterTest()
        {
            //Act
            
            DateTime _expectedDate = new DateTime(2017,12,12,6,7,10);
            DateTime _actualDate = DateTimeConverter.DateTimeOffsetAndDateTimeSetToDateTime(new DateTimeOffset(2017, 12, 12, 0, 0, 0, 0, new TimeSpan()),
                new TimeSpan(6, 7, 10));

            //Assert
            Assert.AreEqual(_expectedDate,_actualDate);

        }
    }
}
