using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationChanger : MonoBehaviour
{

    public float test;

    private TouchScreenKeyboard keyboard;



    public void NotStart()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GetComponent<Animator>().SetTrigger("AnimationChange");

        
    }

    private void Start()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene("Main");
    }

    public void setValue(float val)
    {
        test = val;
    }

    
}
