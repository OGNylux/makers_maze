using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventstart : MonoBehaviour
{
    public AK.Wwise.Event MyEvent;
    public GameObject Object;
    // Start is called before the first frame update
    
    void Start()
    {
        
            
            AkSoundEngine.StopAll();
            
            MyEvent.Post(Object);
            
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
