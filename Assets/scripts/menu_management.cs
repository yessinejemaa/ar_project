﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_management : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void measurmentScene()
    {
        SceneManager.LoadScene("Measurement");
    }

    public void PlaceObjectScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void CaptureObjectScene()
    {
        SceneManager.LoadScene("Screenshot2");
    }
   
    
}
