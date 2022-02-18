using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public static class AssetFinder
    {
        // Constant Fields

        // Fields

        // Constructors

        // Finalizers (Destructors)

        // Delegates

        // Events

        // Enums

        // Interfaces (interface implementations)

        // Properties

        // Indexers

        // Methods
        public static GameObject FindGameObject(string tag) => GameObject.FindGameObjectWithTag(tag);
        public static bool TryFindGameObject(string tag, out GameObject gameObject) => (gameObject = FindGameObject(tag)) != null;

        public static T FindComponent<T>(string tag) where T : Component => FindGameObject(tag).GetComponent<T>();
        public static bool TryFindComponent<T>(string tag, out T component) where T : Component => (component = TryFindGameObject(tag, out GameObject gameObject) ? gameObject.GetComponent<T>() : null) != null;

        // Structs

        // Classes

    }
}
