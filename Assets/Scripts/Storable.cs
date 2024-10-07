using UnityEngine;
using Assets.Scripts.Pawns;

namespace Assets.Scripts
{
    public abstract class Storable : MonoBehaviour
    {
        public string Id;
        public object Value;
        public void Store(string id, object value)
        {
            Repository.Add(id, value);
        }
    }
}
