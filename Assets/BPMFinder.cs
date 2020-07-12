using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMFinder : MonoBehaviour
{
    public float bpm;
    private float beatInterval, beatTimer, beatIntervalEighth, beatTimerEighth;
    public static bool beatFull, beatEighth;
    public static int beatCount, beatCountEighth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void detectBeat()
    {
        //counts full beats
        beatFull = false;
        beatInterval = 60 / bpm;
        beatTimer += Time.deltaTime;

        if(beatTimer >= beatInterval)
        {
            beatTimer -= beatInterval;
            beatCount++;
            beatFull = true;
            Debug.Log("Full");
        }

        // 1/8 beat count
        beatEighth = false;
        beatIntervalEighth = beatInterval / 8;
        beatTimerEighth += Time.deltaTime;

        if(beatTimerEighth >= beatIntervalEighth)
        {
            beatTimerEighth -= beatIntervalEighth;
            beatEighth = true;
            beatCountEighth++;
            Debug.Log("D8");
        }
    }

    // Update is called once per frame
    void Update()
    {
        detectBeat();
    }
}
