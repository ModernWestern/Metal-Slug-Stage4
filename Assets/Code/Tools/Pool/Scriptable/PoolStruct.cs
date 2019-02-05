using UnityEngine;

namespace B25.PoolSystem
{
    [System.Serializable]
    public struct PoolData
    {
        public string name;
        public PoolType poolType;
        public GameObject prefab;
        public int capacity;
    }
}