using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [Ingredient]
    [StackSize(99)]
    public class StoneItem : Item
    {
        public StoneItem() : base(AssetItemIDCts.Stone) { }
    }
}
