using System;
using GUI.Utils;

namespace GUI.Types.ParticleRenderer.Initializers
{
    class RandomAlpha : IParticleInitializer
    {
        private readonly int alphaMin = 255;
        private readonly int alphaMax = 255;

        public RandomAlpha(ParticleDefinitionParser parse)
        {
            alphaMin = parse.Int32("m_nAlphaMin", alphaMin);
            alphaMax = parse.Int32("m_nAlphaMax", alphaMax);

            MathUtils.MinMaxFixUp(ref alphaMin, ref alphaMax);
        }

        public Particle Initialize(ref Particle particle, ParticleSystemRenderState particleSystemState)
        {
            // TODO: Consistent rng
            var alpha = Random.Shared.Next(alphaMin, alphaMax) / 255f;

            particle.Alpha = alpha;

            return particle;
        }
    }
}
