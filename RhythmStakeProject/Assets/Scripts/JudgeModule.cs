using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeModule : MonoBehaviour
{
    public bool Touched { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Touched) return;

        Touched = false;

    }
}
