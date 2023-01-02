using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    
    private LineManager[] lines = new LineManager[4];

    private float time;

    public float NoteSpeed { get; set; } = 7;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainPanel = GameObject.FindWithTag("MainPanel");
        for (int i = 0; i < lines.Length; i++)
        {
            string lineName = "Note" + i.ToString() + "Line";
            lines[i] = mainPanel.transform.Find(lineName).GetComponent<LineManager>();
        }

        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime() { return time; }

    public LineManager[] GetLines()
    {
        return lines;
    }
}
