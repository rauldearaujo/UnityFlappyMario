using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip audioClipCollectedEffect;
    public virtual void PlayCollectedSound()
    {
        AudioSource.PlayClipAtPoint(audioClipCollectedEffect, transform.position, 1.5f);
    }
}
