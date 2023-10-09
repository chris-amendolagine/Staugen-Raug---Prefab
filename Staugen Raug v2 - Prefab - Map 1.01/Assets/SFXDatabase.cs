using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXDatabase : MonoBehaviour
{
    public static SFXDatabase instance;
    [SerializeField]
    AudioClip getPoint, stealBall, music, movement;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    
}
