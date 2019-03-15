using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsManager : MonoBehaviour {


    public static GameSettingsManager instance;

    [SerializeField]
    private Slider difficultySlider;

    public int difficultyLevel;
    // Use this for initialization
    void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        try
        {
            difficultyLevel = (int)difficultySlider.value;
        }
        catch (Exception e)
        {

        }
	}
}
