using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers
{
    class CollisionTracker
    {
        readonly Transform _root;

        public CollisionTracker(Transform root)
        {
            _root = root;
        }

        readonly List<Collider> _collidingWith = new();

        public IEnumerable<TScript> GetCollidingWith<TScript>() where TScript : MonoBehaviour
        {
            foreach (var collider in _collidingWith)
            {
                if (collider.TryGetComponent<TScript>(out var script))
                    yield return script;
            }
        }

        public void Add(Collider collider)
        {
            if (!_collidingWith.Contains(collider) && collider.transform.root != _root)
                _collidingWith.Add(collider);
        }

        public void Remove(Collider collider)
        {
            if (_collidingWith.Contains(collider))
                _collidingWith.Remove(collider);
        }

        public void Clear() => _collidingWith.Clear();
    }
}