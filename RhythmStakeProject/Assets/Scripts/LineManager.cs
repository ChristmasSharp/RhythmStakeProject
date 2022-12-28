using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public Option gameManager;

    private GameObject MainPanel;

    private Queue<NoteModule> notes;

    private GameObject judgeLine;

    private float judgeLineOffset;

    private float lineLength;
    private float noteVelocity;
    private float slideTime;

    // Start is called before the first frame update
    void Start()
    {
        MainPanel = transform.parent.gameObject;

        judgeLine = GameObject.FindWithTag("JudgeLine");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<Option>();
        noteVelocity = (gameManager.NoteSpeed * 1.5f);
        notes = new Queue<NoteModule>();

        judgeLineOffset = judgeLine.transform.localPosition.z;
        lineLength = 5.0f + judgeLineOffset;

        slideTime = lineLength / noteVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            NoteModule topNote = notes.Peek();

            if (topNote.NoteTime - gameManager.getTime() <= slideTime)
            {
                topNote.transform.rotation = MainPanel.transform.rotation;

                topNote.transform.localPosition = Vector3.back *
                ((topNote.NoteTime - gameManager.getTime()) * noteVelocity) 
                + (Vector3.forward * judgeLineOffset);

                topNote.velocity = noteVelocity;

                topNote.gameObject.SetActive(true);

                notes.Dequeue();
            }
            else break;
        }
    }

    public void putNote(NoteModule note)
    {
        note.transform.parent = transform;
        notes.Enqueue(note);
    }
}
