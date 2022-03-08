using UnityEngine;

namespace com.alexlopezvega.prototype.terrain.pipeline
{
    public class TextureSamplerNode : Node
    {
        [Input]
        [SerializeField] private Texture2D texture2D = default;
    }
}
