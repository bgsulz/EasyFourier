using System;
using System.Numerics;

namespace EasyFourier
{
    public struct FrequencyBin : IComparable
    {
        public double Frequency;
        public double Amplitude;

        public override string ToString() => $"{Frequency} Hz: {Amplitude}";
        
        public int CompareTo(object obj)
        {
            if (obj is FrequencyBin otherBin)
                return this.Amplitude.CompareTo(otherBin.Amplitude);
            throw new ArgumentException("Object is not a FrequencyBin."); 
        }

        public FrequencyBin(double frequency, double amplitude)
        {
            Frequency = frequency;
            Amplitude = amplitude;
        }

        public FrequencyBin(Complex input, int index, double signalFreq, double sampleSize)
        {
            Frequency = (index * signalFreq / 2) / (sampleSize / 2);
            Amplitude = Math.Sqrt(input.Real * input.Real + input.Imaginary * input.Imaginary);
        }
    }
}