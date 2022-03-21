namespace com.alexlopezvega.prototype
{
    public static class AssetMenuCts
    {
        private const string Delimiter = "/";

        private const string MenuName = "Project Assets";

        private const string Inventory = MenuName + Delimiter + nameof(Inventory);

        public const string Item = Inventory + Delimiter + nameof(Item);
        public const string Recipe = Inventory + Delimiter + nameof(Recipe);
    }
}
