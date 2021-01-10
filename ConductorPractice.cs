using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ConductorPractice : MonoBehaviour
{

    public float bpm = 120;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeatsExact;
    private int songPositionInBeats;

    public float lastReportedBeat = 0f;

    public float dspSongTime;
    public float firstBeatOffset;
    public int bruh;
    public AudioSource musicSource;
    public AudioSource metronome_audioSrc;
    public float secPerRealBeat;

    public bool onBeat;

    public float songPosBeat;
    public float currentBeatTime;
    public bool missedBeat = false;
    public bool playerHit = false;

    private int timesQuarterBeat;

    public bool metronome = false;

    public float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    public float loopPositionInAnalog;
    public static Conductor instance;

    public AudioClip music;
    public AudioClip one, two;
    public AudioSource onetwo;

    public bool onPlayerBeat;

    public bool canMiss = false;

    public bool canCount = true;

    public Player player;

    //private bool onBeat;

    //DELETE THESE COMMENTS

    public delegate void Beat();
    public static event Beat BeatEvent;

    public int tunnelBeats;

    void Awake()
    {
        //instance = this;
    }

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource.GetComponent<AudioSource>().loop = true;
        //Metronome
        //metronome_audioSrc.GetComponent<AudioSource>();
        //Calculate the number of seconds in each beat
        secPerRealBeat = 60f / bpm;
        secPerBeat = 15f / bpm;
        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        //Start the music
        //musicSource.time = 10f;
        //musicSource.Play();
    }

    void Update()
    {
        //determine how many seconds since the song started
        //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        //determine how many beats since the song started
        songPositionInBeatsExact = songPosition / secPerBeat;
        songPositionInBeats = (int)songPositionInBeatsExact;
        ReportBeat();

       //if (songPosBeat >= (completedLoops + 1) * beatsPerLoop)
       //    completedLoops++;
       //loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;

        //GameTimeline();

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log(songPosBeat);
        }

        //songPosBeat = (float)songPositionInBeats / 4;

        if (onBeat)
        {
            if (songPosBeat == 1)
            {
                musicSource.Play();
                //musicSource.Play();
            }
        }

        if (onBeat)
        {
            if (songPosBeat == 10.0)
            {
                player.canBarely = true;
                canMiss = true;
            }
        }

        if (onBeat)
        {
            if (songPosBeat == 150)
            {
                songPosBeat = 25f;
            }
        }
    }

    void ReportBeat()
    {
        if (lastReportedBeat < songPositionInBeats)
        {
            onBeat = true;
            times += 1;
            currentBeatTime += 0.25f;
            missedBeat = false;
            if (currentBeatTime == 1.25f)
            {
                currentBeatTime = 0.25f;
                if (playerHit == false)
                {
                    if (canMiss == true)
                    {
                        missedBeat = true;
                    }
                }
                ResetCurrentBeat();
            }
            QuarterBeat();
            lastReportedBeat = songPositionInBeats;
        }
        else
        {
            onBeat = false;
        }
    }

    private int times;
    public void QuarterBeat()
    {
        if (times == 4)
        {
            times = 0;
            FullBeat();
        }
        //Debug.Log("beat");
        if (canCount == true)
        {
            songPosBeat += 0.25f; //DONT USE THIS IT COULD GO OUTTA SYNC
        }
    }

    public int oneorTwo;
    public void FullBeat()
    {
        oneorTwo += 1;
        if (oneorTwo == 1)
        {
            onetwo.PlayOneShot(one);
        }
        else
        {
            onetwo.PlayOneShot(two);
            oneorTwo = 0;
        }
        //BeatEvent();
        tunnelBeats += 1;
        if (tunnelBeats == 18)
        {
            tunnelBeats = 1;
            songPosBeat = 25.0f;
        }
        //Debug.Log("beat");
        onPlayerBeat = true;
        if (metronome == true)
        {
            metronome_audioSrc.Play();
        }
    }

    void ResetCurrentBeat()
    {
        playerHit = false;
    }
}