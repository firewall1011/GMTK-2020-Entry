using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulseOnBeat : MonoBehaviour
{

    private int colorIndex = 0;
    private Color[] colorArray =
        {
            new Color(255,0,0),
            new Color(0,255,0),
            new Color(0,0,255),
            new Color(127,127,0),
            new Color(0,127,127),
            new Color(127,0,127)
        };

// Start is called before the first frame update
void Start()
    {

    }

    void changeCubeColor()
    {

        if (colorIndex < colorArray.Length - 1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }
       
        gameObject.GetComponent<Renderer>().material.color = colorArray[colorIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(BPMFinder.beatFull);
        if (BPMFinder.beatFull)
        {
            Debug.Log("Beat");
            changeCubeColor();
        }
    }
}
