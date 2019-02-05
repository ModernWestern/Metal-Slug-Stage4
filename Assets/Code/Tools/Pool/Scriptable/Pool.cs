using System.Collections.Generic;
using UnityEngine;
using B25.PoolSystem;

[CreateAssetMenu(fileName = "new Pool", menuName = "Pool System", order = 0)]
public class Pool : ScriptableObject
{
    public List<PoolData> poolData = new List<PoolData>();
}
