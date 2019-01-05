﻿namespace FlashLFQ
{
    public class IsotopicEnvelope
    {
        public readonly IndexedMassSpectralPeak IndexedPeak;
        public readonly int ChargeState;

        public IsotopicEnvelope(IndexedMassSpectralPeak monoisotopicPeak, int chargeState, double intensity)
        {
            IndexedPeak = monoisotopicPeak;
            ChargeState = chargeState;
            Intensity = intensity / chargeState;
        }

        public double Intensity { get; private set; }

        public void Normalize(double normalizationFactor)
        {
            Intensity *= normalizationFactor;
        }

        public override string ToString()
        {
            return "+" + ChargeState + "|" + Intensity.ToString("F0") + "|" + IndexedPeak.RetentionTime.ToString("F3") + "|" + IndexedPeak.ZeroBasedMs1ScanIndex;
        }
    }
}