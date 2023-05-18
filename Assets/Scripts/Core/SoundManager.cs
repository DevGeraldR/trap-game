
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // To use this class on any class easily
    public static SoundManager instance { get; private set; }

    // Use to play sound
    private AudioSource soundSource;

    // Use to play background music
    private AudioSource musicSource;

    private void Awake()
    {
        // To get the component audio source
        // Use to play sound
        soundSource = GetComponent<AudioSource>();

        // To get the first child component audio source
        // Use to play background music
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    
    // Function to play sound
    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }

    // Function stop the all music and sound
    public void MuteMusic(bool mute)
    {
        musicSource.mute = mute;
    }
}
