using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimOnFootStep : MonoBehaviour
{

    public AudioSource AudioFootStep;

    public void PlayFootStepSound()
    {
        AudioFootStep.Play();
    }
}
