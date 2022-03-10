using Defective.JSON;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public static class MeshFactory
    {
        private static readonly Builder<Mesh>[] MeshBuilders =
        {
            new PlaneMeshBuilder()
        };

        public static bool TryBuild(JSONObject info, out Mesh mesh)
        {
            mesh = default;
            string id = info.GetField("id").stringValue;
            JSONObject data = info.GetField("data");

            foreach (var builder in MeshBuilders)
                if (builder.ID == id && builder.TryBuild(data, out mesh))
                    return true;

            return false;
        }
    }
}
