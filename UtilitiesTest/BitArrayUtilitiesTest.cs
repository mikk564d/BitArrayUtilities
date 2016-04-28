using System.Collections;
using NUnit.Framework;
using Utilities;

namespace UtilitiesTest {
    [TestFixture]
    public class BitArrayUtilitiesTest {
        private BitArray ExpectedBitArray { get; set; }

        [SetUp]
        public void Init() {
            ExpectedBitArray = new BitArray(new[] {true, true, true, true, false, false, false, false, true, true, true, true, false, false, false, false });
        }
        [Test]
        public void ReverseEndianOnBitArray_SimpleValues_ChangedEndian() {
            ExpectedBitArray = BitArrayUtilities.ReverseEndianOnBitArray(ExpectedBitArray);

            BitArray bitArray = new BitArray(new[] {false, false, false, false, true, true, true, true, false, false, false, false, true, true, true, true });

            Assert.AreEqual(ExpectedBitArray, bitArray);
        }

        [Test]
        public void ReverseBitArray_SimpleValues_BitArrayReversed() {
            ExpectedBitArray = BitArrayUtilities.ReverseBitArray(ExpectedBitArray);

            BitArray bitArray = new BitArray(new[] {false, false, false, false, true, true, true, true, false, false, false, false, true, true, true, true});

            Assert.AreEqual(ExpectedBitArray, bitArray);
        }

        [Test]
        public void CompareBitArrays_SimpleValues_Equals() {
            BitArray bitArray1 = new BitArray(new[] { false, false, false, false, true, true, true, true});
            BitArray bitArray2 = new BitArray(new[] { false, false, false, false, true, true, true, true });

            bool equals = BitArrayUtilities.CompareBitArray(bitArray1, bitArray2);

            Assert.IsTrue(equals);
        }
    }
}
