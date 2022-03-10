using Defective.JSON;
using UnityEngine;

namespace com.alexlopezvega.prototype.terrain
{
    public class TerrainChunk
    {
        private const int ChunkWidth = 32;
        private const int ChunkHeight = 32;
        private const int ChunkDepth = 32;

        private TerrainChunkData chunkData = default;

        public TerrainChunk(TerrainProcedureData tpd, Vector3 worldPosition)
        {
            chunkData = GenerateChunk(tpd, worldPosition);
        }

        private TerrainChunkData GenerateChunk(TerrainProcedureData tpd, Vector3 worldPosition)
        {
            Vector3Int chunkGridCoords = Vector3Int.FloorToInt(worldPosition);

            GameObject chunkGameObject = new GameObject($"Chunk {chunkGridCoords}");

            chunkGameObject.transform.position = chunkGridCoords;

            Mesh mesh = GenerateMesh(tpd);
            MeshFilter meshFilter = chunkGameObject.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = chunkGameObject.AddComponent<MeshRenderer>();

            meshFilter.sharedMesh = mesh;

            return new TerrainChunkData(chunkGameObject);
        }

        private Mesh GenerateMesh(TerrainProcedureData tpd)
        {
            JSONObject info = new JSONObject();
            JSONObject data = new JSONObject();

            data.AddField("width", 32);
            data.AddField("depth", 32);

            info.AddField("id", "plane_mesh");
            info.AddField("data", data);

            return MeshFactory.TryBuild(info, out Mesh mesh) ? mesh : null;
        }
    }
}
