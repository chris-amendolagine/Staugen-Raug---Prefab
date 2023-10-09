using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    [SerializeField] GameObject Prefab1;
    [SerializeField] Transform Prefab1Spawn;
    [SerializeField] GameObject Prefab2;
    [SerializeField] Transform Prefab2Spawn;
    [SerializeField] GameObject Prefab3;
    // Start is called before the first frame update

    public void PrefabSpawn1()
    {
        Instantiate(Prefab1, Prefab1Spawn.position, Quaternion.identity);
    }    
    
    public void PrefabSpawn2()
    {
        Instantiate(Prefab2, Prefab2Spawn.position, Quaternion.identity);
    }
}
