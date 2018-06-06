using System;
using DamienG.Security.Cryptography;
using Xunit;

namespace DamienG.Tests.Security.Cryptography
{
    public class Crc64Tests : BaseHashAlgorithmTests
    {
        [Fact]
        public void IsoStaticDefaultSeedAndPolynomialWithShortAsciiString()
        {
            var actual = Crc64Iso.Compute(SimpleBytesAscii);

            Assert.Equal(0x7e210eb1b03e5a1dUL, actual);
        }

        [Fact]
        public void IsoStaticDefaultSeedAndPolynomialWithShortAsciiString2()
        {
            var actual = Crc64Iso.Compute(SimpleBytes2Ascii);

            Assert.Equal(0x416b4150508661eeUL, actual);
        }

        [Fact]
        public void IsoInstanceDefaultSeedAndPolynomialWith12KBinaryFile()
        {
            var hash = GetTestFileHash(Binary12KFileName, new Crc64Iso());

            Assert.Equal(0x9614cf8ea0ef8E63UL, GetBigEndianUInt64(hash));
        }


        [Fact]
        public void IsoInstanceDefaultSeedAndPolynomialWith100KBinaryFile()
        {
            var hash = GetTestFileHash(Binary100KFileName, new Crc64Iso());

            Assert.Equal(0xe1059f24b8d5f523ul, GetBigEndianUInt64(hash));
        }
    }
}