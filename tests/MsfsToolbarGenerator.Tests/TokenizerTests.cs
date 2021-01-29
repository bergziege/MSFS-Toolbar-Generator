using De.Berndnet2000.MsfsToolbarGenerator.Services.Impl;
using FluentAssertions;
using NUnit.Framework;

namespace MsfsToolbarGenerator.Tests {
    public class TokenizerTests {
        [Test]
        public void ReplacingUpperCaseTokenShoudlResultInUpperCaseText() {
            /* Given */
            var tokenizer = new Tokenizer();

            /* When */
            var result = tokenizer.Replace("sample#TEMPLATE#sample", "TeSt");

            /* Then */
            result.Should().Be("sampleTESTsample");
        }

        [Test]
        public void ReplacingLowerCaseTokenShouldResultInLowerCaseText() {
            /* Given */
            var tokenizer = new Tokenizer();

            /* When */
            var result = tokenizer.Replace("sample#template#sample", "TeSt");

            /* Then */
            result.Should().Be("sampletestsample");
        }

        [Test]
        public void ReplacingNormalTokenShouldResultInNormalText() {
            /* Given */
            var tokenizer = new Tokenizer();

            /* When */
            var result = tokenizer.Replace("sample#Template#sample", "TeSt");

            /* Then */
            result.Should().Be("sampleTeStsample");
        }
    }
}