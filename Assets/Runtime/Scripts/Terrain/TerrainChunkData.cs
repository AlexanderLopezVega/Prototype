using UnityEngine;

namespace com.alexlopezvega.prototype.terrain
{
    public struct TerrainChunkData
    {
        private GameObject chunkGameObject;

        public TerrainChunkData(GameObject chunkGameObject)
        {
            this.chunkGameObject = chunkGameObject;
        }
    }
}
