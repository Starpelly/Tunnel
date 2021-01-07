using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public SpriteRenderer girl;

    public void OnMiss()
    {
        girl.material.color = Color.blue;
    }
}
