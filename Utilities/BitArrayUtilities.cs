using System;
using System.Collections;
using System.Diagnostics.Contracts;

namespace Utilities {

    /// <summary>
    /// A class that holds utility methods for <see cref="BitArray"/>.
    /// </summary>
    public static class BitArrayUtilities {

        /// <summary>
        /// Change the endian encoding for the BitArray.
        /// Every set of 8 bits will be reversed.
        /// </summary>
        /// <param name="bitArray"><see cref="BitArray"/> were endian will be changed.</param>
        /// <returns>Returns BitArray with changed endian encoding.</returns>
        public static void ChangeEndianOnBitArraySafe(BitArray bitArray) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            Contract.Requires<ArgumentException>(bitArray.Count % 8 == 0);

            ChangeEndianOnBitArray(bitArray);
        }

        /// <summary>
        /// Change the endian encoding for the BitArray.
        /// Every set of 8 bits will be reversed.
        /// </summary>
        /// <param name="bitArray"><see cref="BitArray"/> were endian will be changed.</param>
        /// <returns>Returns BitArray with changed endian encoding.</returns>
        public static void ChangeEndianOnBitArray(BitArray bitArray) {
            for (int byteIndex = 0; byteIndex < bitArray.Count / 8; byteIndex++) {
                int startOfByteIndex = byteIndex * 8, endOfByteIndex = (1 + byteIndex) * 8 - 1;
                for (; startOfByteIndex < endOfByteIndex; ++startOfByteIndex, --endOfByteIndex) {
                    bool temp = bitArray[startOfByteIndex];
                    bitArray[startOfByteIndex] = bitArray[endOfByteIndex];
                    bitArray[endOfByteIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Reverse the entire BitArray
        /// </summary>
        /// <param name="bitArray">The <see cref="BitArray"/> to reverse.</param>
        /// <returns>Returns BitArray with the bits in the reverse order.</returns>
        public static void ReverseBitArraySafe(BitArray bitArray) {
            Contract.Requires<ArgumentNullException>(bitArray != null);

            ReverseBitArray(bitArray);
        }

        /// <summary>
        /// Reverse the entire BitArray
        /// </summary>
        /// <param name="bitArray">The <see cref="BitArray"/> to reverse.</param>
        /// <returns>Returns BitArray with the bits in the reverse order.</returns>
        public static void ReverseBitArray(BitArray bitArray) {
            int count = bitArray.Count;
            int countDiv = count / 2;

            for (int i = 0, j = count - 1; i < countDiv; i++, j--) {
                bool temp = bitArray[i];
                bitArray[i] = bitArray[j];
                bitArray[j] = temp;
            }
        }

        /// <summary>
        /// Compare two BitArrays.
        /// </summary>
        /// <param name="ba1">First <see cref="BitArray"/>.</param>
        /// <param name="ba2">Second <see cref="BitArray"/>.</param>
        /// <returns>Returns true if equals.</returns>
        public static bool CompareBitArraySafe(BitArray ba1, BitArray ba2) {
            Contract.Requires<ArgumentNullException>(ba1 != null && ba2 != null);

            return CompareBitArray(ba1, ba2);
        }

        /// <summary>
        /// Compare two BitArrays.
        /// </summary>
        /// <param name="ba1">First <see cref="BitArray"/>.</param>
        /// <param name="ba2">Second <see cref="BitArray"/>.</param>
        /// <returns>Returns true if equals.</returns>
        public static bool CompareBitArray(BitArray ba1, BitArray ba2) {
            int length = ba1.Length;

            if (length != ba2.Length) {
                return false;
            }
            
            for (int i = 0; i < length; i++) {
                if (ba1[i] != ba2[i]) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Combines two <see cref="BitArray"/>s
        /// </summary>
        /// <param name="ba1">First <see cref="BitArray"/>.</param>
        /// <param name="ba2">Second <see cref="BitArray"/>.</param>
        /// <returns>The combined <see cref="BitArray"/>.</returns>
        public static BitArray CombineTwoBitArraysSafe(BitArray ba1, BitArray ba2) {
            Contract.Requires<ArgumentNullException>(ba1 != null && ba2 != null);

            return CombineTwoBitArrays(ba1, ba2);
        }

        /// <summary>
        /// Combines two <see cref="BitArray"/>s
        /// </summary>
        /// <param name="ba1">First <see cref="BitArray"/>.</param>
        /// <param name="ba2">Second <see cref="BitArray"/>.</param>
        /// <returns>The combined <see cref="BitArray"/>.</returns>
        public static BitArray CombineTwoBitArrays(BitArray ba1, BitArray ba2) {
            if (ba1.Count == 0 ) {
                return ba2;
            }
            if (ba2.Count == 0) {
                return ba1;
            }

            ba1.Length += ba2.Count;

            for (int i = 0; i < ba2.Count; i++) {
                ba1[ba1.Count - ba2.Count + i] = ba2[i];
            }

            return ba1;
        }

        /// <summary>
        /// Overwrites a <see cref="BitArray"/> at the specified <paramref name="startIndex"/>
        /// with <paramref name="replacementArray"/>.
        /// </summary>
        /// <param name="arrayToOverwrite">Overwritten <see cref="BitArray"/>.</param>
        /// <param name="replacementArray">The array that will be place on <paramref name="arrayToOverwrite"/>.</param>
        /// <param name="startIndex">Start index to replace at.</param>
        public static void OverwriteBitArrayAtIndexSafe(BitArray arrayToOverwrite, BitArray replacementArray, int startIndex) {
            Contract.Requires<ArgumentNullException>(arrayToOverwrite != null && replacementArray != null);
            Contract.Requires<IndexOutOfRangeException>(startIndex >= 0 
                && (replacementArray.Count + startIndex <= arrayToOverwrite.Count));

            OverwriteBitArrayAtIndex(arrayToOverwrite, replacementArray, startIndex);
        }

        /// <summary>
        /// Overwrites a <see cref="BitArray"/> at the specified <paramref name="startIndex"/>
        /// with <paramref name="replacementArray"/>.
        /// </summary>
        /// <param name="arrayToOverwrite">Overwritten <see cref="BitArray"/>.</param>
        /// <param name="replacementArray">The array that will be place on <paramref name="arrayToOverwrite"/>.</param>
        /// <param name="startIndex">Start index to replace at.</param>
        public static void OverwriteBitArrayAtIndex(BitArray arrayToOverwrite, BitArray replacementArray, int startIndex) {
            for (int i = 0; i < replacementArray.Count; i++) {
                arrayToOverwrite[startIndex + i] = replacementArray[i];
            }
        }

        /// <summary>
        /// Takes a sub <see cref="BitArray"/> with specified <paramref name="length"/> from the end.
        /// The start index value of the sub <see cref="BitArray"/>
        /// will be the same as end index value of <paramref name="bitArray"/>.
        /// </summary>
        /// <param name="bitArray">Input <see cref="BitArray"/>.</param>
        /// <param name="length">Length of the new sub <see cref="BitArray"/>.</param>
        /// <returns>A new <see cref="BitArray"/> with the <paramref name="length"/> specified.</returns>
        public static BitArray TakeSubBitArrayFromEndSafe(BitArray bitArray, int length) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            Contract.Requires<ArgumentOutOfRangeException>(bitArray.Count >= length);

            return TakeSubBitArrayFromEnd(bitArray, length);
        }

        /// <summary>
        /// Takes a sub <see cref="BitArray"/> with specified <paramref name="length"/> from the end.
        /// The start index value of the sub <see cref="BitArray"/>
        /// will be the same as end index value of <paramref name="bitArray"/>.
        /// </summary>
        /// <param name="bitArray">Input <see cref="BitArray"/>.</param>
        /// <param name="length">Length of the new sub <see cref="BitArray"/>.</param>
        /// <returns>A new <see cref="BitArray"/> with the <paramref name="length"/> specified.</returns>
        public static BitArray TakeSubBitArrayFromEnd(BitArray bitArray, int length) {
            BitArray subBitArray = new BitArray(length);

            for (int j = bitArray.Count - 1, k = 0; k < length; j--, k++) {
                subBitArray[k] = bitArray[j];
            }

            bitArray.Length -= length;

            return subBitArray;
        }

        /// <summary>
        /// Returns a sub array from <paramref name="bitArray"/>.
        /// </summary>
        /// <param name="bitArray">Input <see cref="BitArray"/>.</param>
        /// <param name="displacement">How much the start index should be displaced from the end</param>
        /// <param name="length">Length of the new sub <see cref="BitArray"/>.</param>
        /// <returns></returns>
        public static BitArray SubBitArrayFromEndSafe(BitArray bitArray, int displacement, int length) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            Contract.Requires<ArgumentOutOfRangeException>(bitArray.Count >= length);

            return SubBitArrayFromEnd(bitArray, displacement, length);
        }

        /// <summary>
        /// Returns a sub array from <paramref name="bitArray"/>.
        /// </summary>
        /// <param name="bitArray">Input <see cref="BitArray"/>.</param>
        /// <param name="displacement">How much the start index should be displaced from the end</param>
        /// <param name="length">Length of the new sub <see cref="BitArray"/>.</param>
        /// <returns></returns>
        public static BitArray SubBitArrayFromEnd(BitArray bitArray, int displacement, int length) {
            BitArray subBitArray = new BitArray(length);

            for (int j = bitArray.Count - 1 - displacement, k = 0; k < length; j--, k++) {
                subBitArray[k] = bitArray[j];
            }

            return subBitArray;
        }

        /// <summary>
        /// Makes a <see cref="BitArray"/> divisible by <paramref name="divisor"/>
        ///  by either rounding down (deleting bits) or rounding up (adding 0 bits).
        /// </summary>
        /// <param name="bitArray">The <see cref="BitArray"/> to make divisible.</param>
        /// <param name="divisor">The divisor for the modulo calculation.</param>
        /// <param name="roundUp">Boolean value to determine the rounding.</param>
        public static void MakeBitArrayDivisibleSafe(BitArray bitArray, int divisor, bool roundUp) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            Contract.Requires<ArgumentOutOfRangeException>(divisor > 0);

            MakeBitArrayDivisible(bitArray, divisor, roundUp);
        }

        /// <summary>
        /// Makes a <see cref="BitArray"/> divisible by <paramref name="divisor"/>
        ///  by either rounding down (deleting bits) or rounding up (adding 0 bits).
        /// </summary>
        /// <param name="bitArray">The <see cref="BitArray"/> to make divisible.</param>
        /// <param name="divisor">The divisor for the modulo calculation.</param>
        /// <param name="roundUp">Boolean value to determine the rounding.</param>
        public static void MakeBitArrayDivisible(BitArray bitArray, int divisor, bool roundUp) {
            int mod = bitArray.Count % divisor;

            if (mod == 0) {
                return;
            }

            if (roundUp) {
                mod -= divisor;
            }
            bitArray.Length -= mod;
        }
    }
}
