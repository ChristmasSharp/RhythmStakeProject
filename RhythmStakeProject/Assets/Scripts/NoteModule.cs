using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteModule : MonoBehaviour
{
    public float NoteTime { get; set; }

    public LineManager Line;

    public float velocity;

    public bool isEndInit = false;

    void Start()
    {

    }

    void OnDisable()
    {
        transform.localPosition = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.forward * velocity * Time.deltaTime;

        if (NoteTime <= Line.gameManager.getTime())
        {
            gameObject.SetActive(false);
        }
    }
}
