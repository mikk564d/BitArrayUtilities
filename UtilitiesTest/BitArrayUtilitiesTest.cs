using System.Collections;
using NUnit.Framework;
using Utilities;

namespace UtilitiesTest {
    [TestFixture]
    public class BitArrayUtilitiesTest {

        [Test]
        public void ReverseEndianOnBitArray_SimpleValues_ChangedEndian() {
            BitArray bitArray = new BitArray(new[] {true, true, false, false, true, false, true, false,
                                                    true, true, true, true, false, false, false, false });

            bitArray = BitArrayUtilities.ChangeEndianOnBitArray(bitArray);

            BitArray expectedBitArray = new BitArray(new[] {false, true, false, true, false, false, true, true,
                                                            false, false, false, false, true, true, true, true });

            Assert.AreEqual(bitArray, expectedBitArray);
        }

        [Test]
        public void ReverseBitArray_SimpleEvenValues_BitArrayReversed() {
            BitArray bitArray = new BitArray(new[] {true, true, false, false, true, false, true, false,
                                                    true, true, true, true, false, false, false, false });

            bitArray = BitArrayUtilities.ReverseBitArray(bitArray);

            BitArray expectedBitArray = new BitArray(new[] {false, false, false, false, true, true, true, true,
                                                            false, true, false, true, false, false, true, true});

            Assert.AreEqual(bitArray, expectedBitArray);
        }

        public void ReverseBitArray_SimpleOddValues_BitArrayReversed() {
            BitArray bitArray = new BitArray(new [] {true, false, true, false, false, true, true});
            bitArray = BitArrayUtilities.ReverseBitArray(bitArray);

            BitArray expectedBitArray = new BitArray(new[] {true, true, false, false, true, false, true});

            Assert.AreEqual(bitArray, expectedBitArray);
        }

        [Test]
        public void CompareBitArrays_SimpleValues_Equals() {
            BitArray bitArray1 = new BitArray(new[] { false, false, false, false, true, true, true, true});
            BitArray bitArray2 = new BitArray(new[] { false, false, false, false, true, true, true, true });

            bool equals = BitArrayUtilities.CompareBitArray(bitArray1, bitArray2);

            Assert.IsTrue(equals);
        }

        [Test]
        public void CompareBitArrays_SimpleValues_NotEquals() {
            BitArray bitArray1 = new BitArray(new[] { false, false, false, false, true, true, true, true });
            BitArray bitArray2 = new BitArray(new[] { true, false, false, false, true, true, true, true });

            bool equals = BitArrayUtilities.CompareBitArray(bitArray1, bitArray2);

            Assert.IsFalse(equals);
        }
    }
}
