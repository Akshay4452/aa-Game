using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance; // use singleton for this class
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
        // Finds sound by name and plays it
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        // => operator is used when we have single line of code in a method
        // sound is the iterator; it has "name" as member variable (see Sounds class) and it is comparing it
        // with the input "name" in Play() method. If those "name" strings match then only it plays the sound
        // else it gives us the warning 
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        // Finds sound by name and plays it
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Stop();
    }
    public void Pause(string name)
    {
        // Finds sound by name and plays it
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }
        s.source.Pause();
    }
}
