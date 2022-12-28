using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private LineManager[] lines = new LineManager[4];

    public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string lineName = "Note" + (i + 1).ToString() + "Line";
            lines[i] = GameObject.Find(lineName).GetComponent<LineManager>();
        }

        //json parsing


        // note put in line

        int noteCount = 100;
        int[] noteLine = new int[noteCount];

        for(int i = 0; i < noteCount; i++)
        {
            noteLine[i] = Random.Range(0, 4);
        }

        for(int i = 0; i < noteCount; i++)
        {
            GameObject note = Instantiate(notePrefab) as GameObject;

            NoteModule noteInfo = note.GetComponent<NoteModule>();
            
            noteInfo.NoteTime = i + 3;
            
            noteInfo.Line = lines[noteLine[i]];
            noteInfo.Line.putNote(noteInfo);

            noteInfo.isEndInit = true;

            note.SetActive(false);
        }
    }
}