using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip hurt;
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip coin;
    public AudioClip melee;

    private void Start()
    {
     

    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
