using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Inheriting from Lewis' Timer if custom functionality needs to be added
public class Minigame_Timer : UITimer
{
    private void OnEnable()
    {
        walGen.OnMazeReady += timerReady; //Maze script
        Updated_Disc_Rotation.OnDiscAlignmentReady += timerReady; //Disc Alignment script
        genGrid.OnTileRotationReady += timerReady; //Tile Rotation script
    }

    private void OnDisable()
    {
        walGen.OnMazeReady -= timerReady;
        Updated_Disc_Rotation.OnDiscAlignmentReady -= timerReady;
        genGrid.OnTileRotationReady -= timerReady;
    }

    void timerReady(bool timerReady)
    {
        playing = timerReady;
        Debug.Log("Timer status: " + playing);
    }
    private void Start()
    {
        playing = false;
        //timer += 5;
    }
}
