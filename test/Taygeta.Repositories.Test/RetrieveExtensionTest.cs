// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Taygeta.Repositories.Test
{
    public class RetrieveExtensionTest
    {
        private const string TestString = "The quick brown fox jumps over the lazy dog";

        [Fact]
        public void ContainsOneForArrayReturnsCorrectValues()
        {
            Assert.True(TestString.ContainsOne(new[] {"brown", "gray"}));
            Assert.True(TestString.ContainsOne(new[] {"fox", "dog"}));
            Assert.False(TestString.ContainsOne(new[] {"white", "gray"}));
        }

        [Fact]
        public void ContainsOneForStringReturnsCorrectValues()
        {
            Assert.True(TestString.ContainsOne("brown, gray"));
            Assert.True(TestString.ContainsOne("fox, dog"));
            Assert.False(TestString.ContainsOne("white, gray"));
        }

        /// <summary>
        /// A class used for tests
        /// </summary>
        public class Sample
        {
            [Required]
            public int IntProperty { get; set;  }
            [StringLength(10)]
            public string StringProperty { get; set; }
            public string BigStringProperty { get; set; }
        }

        [Fact]
        public void CheckThatGetAttributeFromReturnsCorrectValues()
        {
            Sample s = new Sample();
            Assert.NotNull(s.GetAttributeFrom<RequiredAttribute>(nameof(s.IntProperty)));
            Assert.Null(s.GetAttributeFrom<StringLengthAttribute>(nameof(s.IntProperty)));
            Assert.NotNull(s.GetAttributeFrom<StringLengthAttribute>(nameof(s.StringProperty)));
        }

        [Fact]
        public void CheckThatGetAnnotatedLengthReturnsCorrectValues()
        {
            Sample s = new Sample();            
            Assert.Equal(10, s.GetAnnotatedLength(nameof(s.StringProperty)));
            Assert.Equal(int.MaxValue, s.GetAnnotatedLength(nameof(s.BigStringProperty)));
        }
    }
}
