using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameOptions gameOptions;

    private Dictionary<LineManager, KeyCode> linesCommand;

    // Start is called before the first frame update
    void Start()
    {
        gameOptions = GameObject.FindWithTag("GameManager").GetComponent<GameOptions>();

        linesCommand = new Dictionary<LineManager, KeyCode>()
        {
            {gameOptions.GetLines()[0], KeyCode.S},
            {gameOptions.GetLines()[1], KeyCode.D},
            {gameOptions.GetLines()[2], KeyCode.J},
            {gameOptions.GetLines()[3], KeyCode.K},
        };
    }

    // Update is called once per frame
    void Update()
    {
        for(int lineNum=0; lineNum < gameOptions.GetLines().Length; lineNum++)
        {
            LineManager line = gameOptions.GetLines()[lineNum];
            if (Input.GetKeyDown(linesCommand[line]))
            {
                line.judge.touch();
            }
        }
        
    }
}
