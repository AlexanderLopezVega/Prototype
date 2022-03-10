using Defective.JSON;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class PlaneMeshBuilder : Builder<Mesh>
    {
        public PlaneMeshBuilder() : base("plane_mesh") { }

        public override bool TryBuild(JSONObject data, out Mesh mesh)
        {
            int planeWidth = data.GetField("width").intValue;
            int planeDepth = data.GetField("depth").intValue;

            Vector3[] vertices = new Vector3[(planeWidth + 1) * (planeDepth + 1)];
            int[] indices = new int[planeWidth * planeDepth * 6];
            Vector2[] uvs = new Vector2[vertices.Length];

            GenerateVertices(planeWidth, planeDepth, vertices);
            GenerateIndices(planeWidth, planeDepth, indices);
            mesh = GenerateMesh(vertices, indices);

            return true;
        }

        private static void GenerateIndices(int planeWidth, int planeDepth, int[] indices)
        {
            int vertex = 0;
            int index = 0;

            for (int z = 0; z < planeDepth; ++z)
            {
                for (int x = 0; x < planeWidth; ++x)
                {
                    indices[index + 0] = vertex + 0;
                    indices[index + 1] = vertex + planeWidth + 1;
                    indices[index + 2] = vertex + 1;
                    indices[index + 3] = vertex + 1;
                    indices[index + 4] = vertex + planeWidth + 1;
                    indices[index + 5] = vertex + planeWidth + 2;

                    ++vertex;
                    index += 6;
                }

                ++vertex;
            }
        }

        private static Mesh GenerateMesh(Vector3[] vertices, int[] indices)
        {
            Mesh mesh = new Mesh() { name = "Terrain Mesh" };

            mesh.vertices = vertices;
            mesh.triangles = indices;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            return mesh;
        }

        private static void GenerateVertices(int planeWidth, int planeDepth, Vector3[] vertices)
        {
            for (int i = 0, z = 0; z <= planeDepth; ++z)
                for (int x = 0; x <= planeWidth; ++x)
                    vertices[i++] = new Vector3(x, 0, z);
        }
    }
}
