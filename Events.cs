using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Conductor ConductorScript;
    public Voice voice;

    private void Update()
    {
        if (ConductorScript.onBeat == true)
        {
            switch (ConductorScript.songPosBeat)
            {
                case 2:
                    voice.One();
                    break;
                case 3:
                    voice.Two();
                    break;
                case 4:
                    voice.One();
                    break;
                case 5:
                    voice.Two();
                    break;
                case 6:
                    voice.One();
                    break;
                case 7:
                    voice.Two();
                    break;
                case 8:
                    voice.One();
                    break;
                case 9:
                    voice.Two();
                    //ConductorScript.metronome = true;
                    break;
            }
        }
    }
}
