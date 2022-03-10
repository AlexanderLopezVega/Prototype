using Defective.JSON;

namespace com.alexlopezvega.prototype
{
    public abstract class Builder<T>
    {
        public readonly string ID = default;

        public Builder(string ID)
        {
            this.ID = ID;
        }

        public abstract bool TryBuild(JSONObject data, out T t);
    }
}
