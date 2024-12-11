using System.Collections;
using UnityEngine;
using UnityEngine.Subsystems;

public class Gamemusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event soundEvent;

    void Start()
    {

        AkSoundEngine.StopAll();
        soundEvent.Post(gameObject);
    }
}
