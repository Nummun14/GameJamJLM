using UnityEngine;

public class SoundManger : MonoBehaviour
{

    public AudioSource SFX;
    public AudioSource Music;
    public AudioSource DrilMusic;
    [Header("Music:")]
    public AudioClip background;
    public AudioClip drilLoop;
    [Header("SFX:")]
    public AudioClip deathSound;
    public AudioClip crushSound;

    void Start()
    {
        Music.clip = background;
        Music.Play();
        DrilMusic.clip = drilLoop;
        DrilMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void playSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
