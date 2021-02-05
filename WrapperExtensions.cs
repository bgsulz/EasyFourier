using System.Collections.Generic;
using System.Numerics;

namespace EasyFourier
{
    public static class WrapperExtensions
    {
        public static IEnumerable<FrequencyBin> ToFrequencyDomain(this IList<double> self, double signalFreq)
            => self.ToComplexList().ToFrequencyDomainEnumerable(signalFreq);

        public static IEnumerable<FrequencyBin> ToFrequencyDomain(this IList<float> self, double signalFreq)
            => self.ToComplexList().ToFrequencyDomainEnumerable(signalFreq);

        public static IEnumerable<FrequencyBin> ToFrequencyDomain(this IList<Complex> self, double signalFreq)
            => self.ToFrequencyDomainEnumerable(signalFreq);

        internal static IEnumerable<FrequencyBin> ToFrequencyDomainEnumerable(this IList<Complex> self, double signalFreq)
        {
            IList<Complex> result = Fourier.FFT(self);
            
            for (int i = 0; i < result.Count / 2; i++) 
                yield return new FrequencyBin(result[i], i, signalFreq, self.Count);
        }

        public static IEnumerable<Complex> ToFrequencyDomainEnumerableRaw(this IList<Complex> self) => Fourier.FFT(self);
        public static IEnumerable<Complex> ToFrequencyDomainEnumerableRaw(this IList<float> self) => Fourier.FFT(self.ToComplexList());
        public static IEnumerable<Complex> ToFrequencyDomainEnumerableRaw(this IList<double> self) => Fourier.FFT(self.ToComplexList());
    }
}