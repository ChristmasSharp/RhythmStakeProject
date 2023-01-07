using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public GameOptions gameOptions;

    public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameOptions = GameObject.FindWithTag("GameManager").GetComponent<GameOptions>();

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

            note.transform.rotation = gameOptions.MainPanel.transform.rotation;
            Vector3.Scale(note.transform.localScale, gameOptions.MainPanel.transform.localScale);
            
            NoteModule noteInfo = note.GetComponent<NoteModule>();
            
            noteInfo.NoteTime = i + 3;
            
            noteInfo.Line = gameOptions.GetLines()[noteLine[i]];
            noteInfo.Line.putNote(noteInfo);

            noteInfo.isEndInit = true;

            note.SetActive(false);
        }
    }
}