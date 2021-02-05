using System;
using System.Collections.Generic;
using System.Numerics;

namespace EasyFourier
{
    public static class Fourier {
        public static void FFTInPlace(IList<Complex> buffer)
        {
            int bits = (int)Math.Log(buffer.Count, 2);
            
            for (int j = 1; j < buffer.Count; j++)
            {
                int swapPos = BitReverse(j, bits);
                
                if (swapPos <= j) continue;
                
                Complex temp = buffer[j];
                buffer[j] = buffer[swapPos];
                buffer[swapPos] = temp;
            }

            for (int n = 2; n <= buffer.Count; n <<= 1) {
                for (int i = 0; i < buffer.Count; i += n) {
                    for (int k = 0; k < n / 2; k++) {
 
                        int evenIndex = i + k;
                        int oddIndex = i + k + (n / 2);
                        Complex even = buffer[evenIndex];
                        Complex odd = buffer[oddIndex];
 
                        double term = -2 * Math.PI * k / n;
                        Complex exp = new Complex(Math.Cos(term), Math.Sin(term)) * odd;
 
                        buffer[evenIndex] = even + exp;
                        buffer[oddIndex] = even - exp;
                    }
                }
            }
        }
        
        public static IList<Complex> FFT(IList<Complex> buffer, bool ensurePowerOfTwo = true)
        {
            IList<Complex> outputBuffer;

            outputBuffer = ensurePowerOfTwo
                ? buffer.GetRange(0, (int) Math.Pow(2, (int) Math.Log(buffer.Count, 2)))
                : buffer;

            FFTInPlace(outputBuffer);
            
            return outputBuffer;
        }

        private static int BitReverse(int n, int bits) 
        {
            int reversedN = n;
            int count = bits - 1;
 
            n >>= 1;
            while (n > 0) 
            {
                reversedN = (reversedN << 1) | (n & 1);
                count--;
                n >>= 1;
            }
 
            return ((reversedN << count) & ((1 << bits) - 1));
        }
    }
}