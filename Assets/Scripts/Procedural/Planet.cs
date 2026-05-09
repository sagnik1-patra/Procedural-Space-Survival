using UnityEngine;

namespace SpaceSurvival.Procedural
{
    public class Planet : MonoBehaviour
    {
        [Range(2, 256)]
        public int resolution = 10;
        public float radius = 10;
        public NoiseSettings noiseSettings;

        [SerializeField, HideInInspector]
        MeshFilter[] meshFilters;
        TerrainFace[] terrainFaces;

        private void OnValidate()
        {
            GeneratePlanet();
        }

        public void GeneratePlanet()
        {
            Initialize();
            GenerateMesh();
        }

        void Initialize()
        {
            if (meshFilters == null || meshFilters.Length == 0)
            {
                meshFilters = new MeshFilter[6];
            }
            terrainFaces = new TerrainFace[6];

            Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

            for (int i = 0; i < 6; i++)
            {
                if (meshFilters[i] == null)
                {
                    GameObject meshObj = new GameObject("mesh");
                    meshObj.transform.parent = transform;
                    meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                    meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = new Mesh();
                }

                terrainFaces[i] = new TerrainFace(meshFilters[i].sharedMesh, resolution, directions[i], radius, noiseSettings);
            }
        }

        void GenerateMesh()
        {
            foreach (TerrainFace face in terrainFaces)
            {
                face.ConstructMesh();
            }
        }
    }
}
