using System;
using PictureRename.Services;
using Xunit;

namespace PictureRename.Tests
{
    public class NameBuilderTests
    {
        private readonly AppendNameBuilder appendNameBuilder;
        public NameBuilderTests()
        {
            this.appendNameBuilder = new AppendNameBuilder();
        }


        [Fact]
        public void GetFileName_ReturnsNameWithAppendedDate()
        {
            var originalName = "test.jpg";
            var date = DateTime.Parse("01/02/2020 10:22:11");

            var name = appendNameBuilder.GetFileName(originalName, date);
            var expected = $"20200201_102211_test.jpg";
            Assert.Equal(expected, name);
        }
    }
}
