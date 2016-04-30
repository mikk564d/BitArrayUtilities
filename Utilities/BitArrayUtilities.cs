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
        /// </summary>
        /// <param name="bitArray"></param>
        /// <returns>Returns BitArray with changed endian encoding.</returns>
        public static BitArray ChangeEndianOnBitArray(BitArray bitArray) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            Contract.Requires<ArgumentException>(bitArray.Count % 8 == 0);

            for (int i = 0; i < bitArray.Count / 8; i++) {
                for (int k = i * 8, j = (1 + i) * 8 - 1, count = 0; count < 4; ++k, --j, count++) {
                    bool temp = bitArray[k];
                    bitArray[k] = bitArray[j];
                    bitArray[j] = temp;
                }
            }

            return bitArray;
        }

        /// <summary>
        /// Reverse the entire BitArray
        /// </summary>
        /// <param name="bitArray"></param>
        /// <returns>Returns BitArray with the bits in the reverse order.</returns>
        public static BitArray ReverseBitArray(BitArray bitArray) {
            Contract.Requires<ArgumentNullException>(bitArray != null);
            for (int i = 0, j = bitArray.Count - 1; i < bitArray.Count / 2; i++, j--) {
                bool temp = bitArray[i];
                bitArray[i] = bitArray[j];
                bitArray[j] = temp;
            }

            return bitArray;
        }
        
        /// <summary>
        /// Compare two BitArrays.
        /// </summary>
        /// <param name="ba1"></param>
        /// <param name="ba2"></param>
        /// <returns>Returns true if equals.</returns>
        public static bool CompareBitArray(BitArray ba1, BitArray ba2) {
            Contract.Requires<ArgumentNullException>(ba1 != null && ba2 != null);
            if (ba1.Length != ba2.Length) {
                return false;
            }

            for (int i = 0; i < ba1.Length; i++) {
                if (ba1[i] != ba2[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
