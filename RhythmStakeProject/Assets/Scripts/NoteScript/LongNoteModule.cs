using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteModule : MonoBehaviour
{
    public GameObject longNotePrefab;
    
    public float BeginNoteTime { get; set; }
    public float EndNoteTime { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        transform.position = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
