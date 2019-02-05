using System.Collections.Generic;
using UnityEngine;

namespace B25.PoolSystem
{
    public class PoolSystem
    {
        private readonly Vector3 VECTOR3_ZERO = Vector3.zero; // Avoid GC creating a new vector3(0,0,0) every call
        private readonly Quaternion QUATERNION_IDENTITY = Quaternion.identity; // Avoid CG creating a new Quaternion(0,0,0,0) every call

        private Pool poolData;

        private GameObject poolSystem;
        private Dictionary<PoolType, Queue<GameObject>> poolTable = new Dictionary<PoolType, Queue<GameObject>>();

        #region Constructor

        public PoolSystem(Pool poolData)
        {
            this.poolData = poolData;

            poolSystem = new GameObject("Pool");
            Populate();
            Object.DontDestroyOnLoad(poolSystem);
        }
        #endregion

        #region Core

        internal void Populate()
        {
            for (int i = 0; i < poolData.poolData.Count; i++)
            {
                var queue = new Queue<GameObject>();

                for (int j = 0; j < poolData.poolData[i].capacity; j++)
                {
                    var go = Object.Instantiate(poolData.poolData[i].prefab);
                    go.name = poolData.poolData[i].name + j;
                    go.transform.SetParent(poolSystem.transform, false);
                    go.SetActive(false);
                    queue.Enqueue(go);
                }

                poolTable.Add(poolData.poolData[i].poolType, queue);
            }
        }

        /// <summary>
        /// Select an object from enum list
        /// </summary>
        internal GameObject Grab(PoolType type)
        {
            var queue = poolTable[type];

            if (poolTable.TryGetValue(type, out queue))
            {
                if (queue.Count > 0)
                {
                    var go = poolTable[type].Dequeue();
                    go.SetActive(true);

                    return go;
                }
                else return null;
            }
            else return null;
        }

        /// <summary>
        /// Drop an object in their respective pool
        /// </summary>
        internal void Drop(PoolType type, GameObject go)
        {
            go.SetActive(false);
            go.transform.position = VECTOR3_ZERO;
            go.transform.rotation = QUATERNION_IDENTITY;
            go.transform.localRotation = QUATERNION_IDENTITY;
            poolTable[type].Enqueue(go);
        }
        #endregion
    }
}
