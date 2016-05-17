using System;
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

            BitArrayUtilities.ChangeEndianOnBitArray(bitArray);

            BitArray expectedBitArray = new BitArray(new[] {false, true, false, true, false, false, true, true,
                                                            false, false, false, false, true, true, true, true });

            Assert.AreEqual(bitArray, expectedBitArray);
        }

        [Test]
        public void ReverseBitArray_SimpleEvenValues_BitArrayReversed() {
            BitArray bitArray = new BitArray(new[] {true, true, false, false, true, false, true, false,
                                                    true, true, true, true, false, false, false, false });

            BitArrayUtilities.ReverseBitArray(bitArray);

            BitArray expectedBitArray = new BitArray(new[] {false, false, false, false, true, true, true, true,
                                                            false, true, false, true, false, false, true, true});

            Assert.AreEqual(bitArray, expectedBitArray);
        }

        public void ReverseBitArray_SimpleOddValues_BitArrayReversed() {
            BitArray bitArray = new BitArray(new [] {true, false, true, false, false, true, true});
            BitArrayUtilities.ReverseBitArray(bitArray);

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

        [Test]
        public void CombineTwoBitArrays_SimpleValues_Calculated() {
            BitArray bitArray = new BitArray(new[] {true, true, false, false, true, false, true, false});
            BitArray bitArray2 = new BitArray(new [] {true, true, true, true, false, false, false, false});

            BitArray resultArray = BitArrayUtilities.CombineTwoBitArrays(bitArray, bitArray2);
            
            BitArray expectedBitArray = new BitArray(new[] {true, true, false, false, true, false, true, false,
                                                            true, true, true, true, false, false, false, false});

            Assert.AreEqual(expectedBitArray, resultArray);
        }

        [Test]
        public void CombineTwoBitArrays_FirstArrayEmpty_Calculated() {
            BitArray bitArray = new BitArray(0);
            BitArray bitArray2 = new BitArray(new[] { true, true, true, true, false, false, false, false });

            BitArray resultArray = BitArrayUtilities.CombineTwoBitArrays(bitArray, bitArray2);

            BitArray expectedBitArray = new BitArray(new[] {true, true, true, true, false, false, false, false});

            Assert.AreEqual(expectedBitArray, resultArray);
        }

        [Test]
        public void CombineTwoBitArrays_SecondArrayEmpty_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, false, true, false });
            BitArray bitArray2 = new BitArray(0);

            BitArray resultArray = BitArrayUtilities.CombineTwoBitArrays(bitArray, bitArray2);

            BitArray expectedBitArray = new BitArray(new[] {true, true, false, false, true, false, true, false});

            Assert.AreEqual(expectedBitArray, resultArray);
        }

        [Test]
        public void OverwriteBitArrayAtIndex_SimpleValue_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, false, true, false });
            BitArray bitArray2 = new BitArray(new[] { true, false, false, false });

            BitArrayUtilities.OverwriteBitArrayAtIndex(bitArray, bitArray2, 2);

            BitArray expectedBitArray = new BitArray(new[] { true, true, true, false, false, false, true, false });

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void OverwriteBitArrayAtIndex_ReplaceAll_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, false, true, false });
            BitArray bitArray2 = new BitArray(new[] { true, true, true, true, false, false, false, false });

            BitArrayUtilities.OverwriteBitArrayAtIndex(bitArray, bitArray2, 0);

            BitArray expectedBitArray = new BitArray(new[] { true, true, true, true, false, false, false, false });

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void OverwriteBitArrayAtIndex_ReplaceNothing_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, false, true, false });
            BitArray bitArray2 = new BitArray(0);

            BitArrayUtilities.OverwriteBitArrayAtIndex(bitArray, bitArray2, 2);

            BitArray expectedBitArray = new BitArray(new[] { true, true, false, false, true, false, true, false });

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void TakeSubBitArrayFromEnd_SimpleValue_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, true, true, false });

            BitArray resultArray = BitArrayUtilities.TakeSubBitArrayFromEnd(bitArray, 3);

            BitArray expectedTakenBitArray = new BitArray(new[] { false, true, true });
            BitArray expectedBitArray = new BitArray(new [] { true, true, false, false, true });

            Assert.AreEqual(expectedBitArray, bitArray);
            Assert.AreEqual(expectedTakenBitArray, resultArray);
        }

        [Test]
        public void MakeBitArrayDivisible_SimpleValueRoundDown_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, true, true, false });

            BitArrayUtilities.MakeBitArrayDivisible(bitArray, 3, false);
           
            BitArray expectedBitArray = new BitArray(new[] { true, true, false, false, true, true});

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void MakeBitArrayDivisible_SimpleValueRoundUp_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, true, true, false });

            BitArrayUtilities.MakeBitArrayDivisible(bitArray, 3, true);

            BitArray expectedBitArray = new BitArray(new[] { true, true, false, false, true, true, true, false, false});

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void MakeBitArrayDivisible_SimpleValueHighDivisorRoundDown_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, true, true, false });

            BitArrayUtilities.MakeBitArrayDivisible(bitArray, 10, false);

            BitArray expectedBitArray = new BitArray(0);

            Assert.AreEqual(expectedBitArray, bitArray);
        }

        [Test]
        public void MakeBitArrayDivisible_SimpleValueHighDivisorRoundUp_Calculated() {
            BitArray bitArray = new BitArray(new[] { true, true, false, false, true, true, true, false });

            BitArrayUtilities.MakeBitArrayDivisible(bitArray, 10, true);

            BitArray expectedBitArray = new BitArray(new[] { true, true, false, false, true, true, true, false, false, false });

            Assert.AreEqual(expectedBitArray, bitArray);
        }
    }
}
