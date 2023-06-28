using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioSource speedBoostSource;
    public AudioSource slowDownSource;
    public AudioSource turnBackSource;
    public AudioSource completedSource;

    public AudioClip buttonClip;
    public AudioClip speedBoostClip;
    public AudioClip slowDownClip;
    public AudioClip turnBackClip;
    public AudioClip completedClip;
    
    public void ButtonSound()
    {
        buttonSource.PlayOneShot(buttonClip);
    }
    public void speedBoostSound()
    {
        buttonSource.PlayOneShot(speedBoostClip);
    }
    public void slowDownSound()
    {
        buttonSource.PlayOneShot(slowDownClip,0.3f);
    }
    public void turnBackSound()
    {
        buttonSource.PlayOneShot(turnBackClip);
    }
    public void completedSound()
    {
        buttonSource.PlayOneShot(completedClip);
    }

}
