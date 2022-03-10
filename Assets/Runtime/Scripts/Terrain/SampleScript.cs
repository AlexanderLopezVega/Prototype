using com.alexlopezvega.prototype.terrain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public class SampleScript : MonoBehaviour
    {
        private void Start()
        {
            TerrainProcedureData tpd = new TerrainProcedureData();
            Vector3 worldPosition = transform.position; 

            new TerrainChunk(tpd, worldPosition);
        }
    }
}
