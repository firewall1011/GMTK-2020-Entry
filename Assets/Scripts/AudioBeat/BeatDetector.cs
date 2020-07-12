using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public AudioSource source;
    GameObject cube;

    //Energy level for 1024 samples
    public float instantEnergy;
    //Energy level to compare instant to. For 44100 samples
    public float localEnergy;
    //fft sample size
    public int instantSamples = 1024;
    //fft sample frequency
    public int localSamples = 44100;
    //Determines threshhold for what constitutes a 'beat'
    public float sensitivity = 1.3f;
    //Sample buffer. [0] for left, [1] for right
    float[][] buffer;
    //Number of bands
    private int bandNum  = 8;
    //
    public int sampleRate;
    //Time of last execution in ms, current time in ms, diff in energy levels at those times,
    private long prevTime, currTime, energyDiff, entries, sum;
    //The coefficent in front of the regional energy equasion
    private float analysisPeriod;

    //Current pos in song in beat#, BPM of song, 60/songBPM, and current position in song in seconds
    public float songPosInBeats, songBPM, secPerBeat, dspSongTime, songPosInSeconds;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        sampleRate = source.clip.frequency;

        secPerBeat = 60f / songBPM;
        dspSongTime = (float)AudioSettings.dspTime;
        analysisPeriod = (float)instantSamples / (float)localSamples;



        createPulsingCube();
        source.Play();
    }

    private long getCurrentTimeMS()
    {
        return System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
    }

    void createPulsingCube()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    void calculateSoundEnergy()
    {
        source.GetSpectrumData(buffer[0], 0, FFTWindow.Rectangular);
        source.GetSpectrumData(buffer[1], 1, FFTWindow.Rectangular);

        for(int i = 0; i < instantSamples; i++)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        //How many seconds since song started?
        songPosInSeconds = (float)(AudioSettings.dspTime - dspSongTime);
        //How many beats since song started?
        songPosInBeats = songPosInSeconds / secPerBeat;
    }
}
