using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public GameOptions gameManager;
    public JudgeModule judge;

    private GameObject MainPanel;
    private GameObject judgeLine;

    private float judgeLineOffset;

    private Queue<NoteModule> notes = new Queue<NoteModule>();

    private Queue<NoteModule> noteOnLine = new Queue<NoteModule>();

    private float lineLength;
    private float noteVelocity;
    private float slideTime;

    [SerializeField]
    private float noteRecognitionTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        MainPanel = transform.parent.gameObject;

        judge = GetComponent<JudgeModule>();

        judgeLine = GameObject.FindWithTag("JudgeLine");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameOptions>();
        noteVelocity = (gameManager.NoteSpeed * 1.5f);

        judgeLineOffset = judgeLine.transform.localPosition.z;
        lineLength = 5.0f + judgeLineOffset;

        slideTime = lineLength / noteVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        while (notes.Count > 0)
        {
            NoteModule nextNote = notes.Peek();

            if (nextNote.NoteTime - gameManager.GetTime() <= slideTime)
            {
                nextNote.transform.rotation = MainPanel.transform.rotation;

                nextNote.transform.localPosition = Vector3.back *
                ((nextNote.NoteTime - gameManager.GetTime()) * noteVelocity) 
                + (Vector3.forward * judgeLineOffset);

                nextNote.velocity = noteVelocity;

                nextNote.gameObject.SetActive(true);

                notes.Dequeue();

                noteOnLine.Enqueue(nextNote);
            }
            else break;
        }

        if(noteOnLine.Count > 0)
        {
            NoteModule nearNote = noteOnLine.Peek();

            if(nearNote.NoteTime + 1.0f <= gameManager.GetTime())
            {
                judge.touch();
            }
        }
    }

    public void putNote(NoteModule note)
    {
        note.transform.parent = transform;
        notes.Enqueue(note);
    }

    public NoteModule getJudgeNote()
    {
        if (noteOnLine.Count == 0) return null;
        NoteModule judgeNote = noteOnLine.Peek();

        if ((judgeNote.NoteTime - noteRecognitionTime) 
            > gameManager.GetTime())
            return null;

        return noteOnLine.Dequeue();
    }
}
