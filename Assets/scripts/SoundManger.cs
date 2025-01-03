using UnityEngine;

public class SoundManger : MonoBehaviour
{

    public AudioSource SFX;
    public AudioSource Music;

    public AudioClip background;


    void Start()
    {
        Music.clip = background;
        Music.Play();
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
