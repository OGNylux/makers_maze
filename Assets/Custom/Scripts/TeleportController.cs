using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportController : MonoBehaviour
{

    public UnityEvent onTrigger;

    public GameObject[] destroyAll;

    public GameObject[] setActive;

    private void Update()
    {
        if (Input.GetButtonDown("XRI_Left_PrimaryButton"))
        {
            onTrigger.Invoke();

            foreach (var item in destroyAll)
            {
                Destroy(item);
            }

            foreach (var item in setActive)
            {
                item.SetActive(true);
            }
        }

        if (Input.GetButtonDown("XRI_Left_SecondaryButton"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}