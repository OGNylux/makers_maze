using UnityEngine;


[RequireComponent(typeof(AkAmbient))]

public class AudioSourceWise : MonoBehaviour
{
    public AK.Wwise.Event soundEvent;

    public void Play(AK.Wwise.Event soundEvent)
    {
        // Check if the sound event is valid
        if (soundEvent == null)
        {
            AkSoundEngine.PostEvent(soundEvent.Id, gameObject);
        }
    }

    public void Play()
    {

        if (soundEvent != null)
        {

            AkSoundEngine.PostEvent(soundEvent.Id, gameObject);
        }
    }
}
