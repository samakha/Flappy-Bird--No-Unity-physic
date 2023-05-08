using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SoundManager Instance;
    public AudioSource audioSource; 
    [SerializeField] AudioClip wingClip, hitClip; 
    private void Awake()
    {
        if ( Instance==null)
                  Instance = this; 
         else
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject); 
    }
    

    public void PlaySoundWingClip()
    {
        audioSource.PlayOneShot(wingClip); 
    }
    public void PlaySoundHitClip()
    {
        audioSource.PlayOneShot(hitClip);
    }
}
