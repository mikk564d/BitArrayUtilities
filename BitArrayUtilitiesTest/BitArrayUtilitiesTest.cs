using System.Collections;
using NUnit.Framework;

namespace BitArrayUtilitiesTest {
    [TestFixture]
    public class BitArrayUtilitiesTest {

        private BitArray _bitArray;

        [SetUp]
        public void Init() {
        _bitArray = new BitArray(new bool[] {true, true, true, true, false, false, false, false, true, true, true, true, false, false, false, false });

        }
        [Test]
        public void ReverseEndianOnBitArray_SimpleValues_ChangedEndian() {
            _bitArray = BitArrayUtilities.BitArrayUtilities.ReverseEndianOnBitArray(_bitArray);

            BitArray bitArray = new BitArray(new bool[] {false, false, false, false, true, true, true, true, false, false, false, false, true, true, true, true });

            Assert.AreEqual(_bitArray, bitArray);
        }

        [Test]
        public void ReverseBitArray_SimpleValues_BitArrayReversed() {
            _bitArray = BitArrayUtilities.BitArrayUtilities.ReverseBitArray(_bitArray);

            BitArray bitArray = new BitArray(new bool[] {false, false, false, false, true, true, true, true, false, false, false, false, true, true, true, true});

            Assert.AreEqual(_bitArray, bitArray);
        }

        [Test]
        public void CompareBitArrays_SimpleValues_Equals() {
            BitArray bitArray1 = new BitArray(new bool[] { false, false, false, false, true, true, true, true});
            BitArray bitArray2 = new BitArray(new bool[] { false, false, false, false, true, true, true, true });

            bool equals = BitArrayUtilities.BitArrayUtilities.CompareBitArray(bitArray1, bitArray2);

            Assert.IsTrue(equals);
        }
    }
}
