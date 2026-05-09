using UnityEngine;

namespace SpaceSurvival.Procedural
{
    public static class NoiseGenerator
    {
        public static float Evaluate(Vector3 point, NoiseSettings settings)
        {
            float noiseValue = 0;
            float frequency = settings.baseRoughness;
            float amplitude = 1;

            for (int i = 0; i < settings.numLayers; i++)
            {
                float v = Mathf.PerlinNoise(point.x * frequency + settings.centre.x, point.y * frequency + settings.centre.y);
                noiseValue += (v * 2 - 1) * amplitude;
                frequency *= settings.roughness;
                amplitude *= settings.persistence;
            }

            noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
            return noiseValue * settings.strength;
        }
    }

    [System.Serializable]
    public class NoiseSettings
    {
        public float strength = 1;
        public int numLayers = 1;
        public float baseRoughness = 1;
        public float roughness = 2;
        public float persistence = 0.5f;
        public Vector3 centre;
        public float minValue;
    }
}
