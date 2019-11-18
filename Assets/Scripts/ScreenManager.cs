using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : SingletonPersistant<ScreenManager>
{
    //public SortedDictionary<int, ScreenManager> screenManagers = new SortedDictionary<int, ScreenManager>();

    public Screen ScreenToEnter { get; set; }
    public Screen CurrentScreen { get; set; }

    CameraController cameraController;

    void Start()
    {
        CurrentScreen = GameObject.Find("ScreenManager101").GetComponent<Screen>();

        cameraController = Camera.main.GetComponent<CameraController>();
    }

    public void LoadScreen()
    {

        int tileKey = ScreenToEnter.tileKey;

        Debug.Log("Entered tile: " + tileKey);

        cameraController.MoveToNextTile(ScreenToEnter);

        CurrentScreen = ScreenToEnter;
    }

}
