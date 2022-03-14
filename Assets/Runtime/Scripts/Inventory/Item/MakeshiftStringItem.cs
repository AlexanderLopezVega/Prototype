using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype.inventory
{
    [Ingredient]
    [StackSize(99)]
    public class MakeshiftStringItem : Item
    {
        public MakeshiftStringItem() : base(AssetItemIDCts.MakeshiftHatchet) { }
    }
}
