using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class OpenSliceScreen : MonoBehaviour
{

    public Button StartSlicingButton;
    public GameObject SliceScreen;


    // Start is called before the first frame update
    void Start()
    {
        SliceScreen.SetActive(false);
        StartSlicingButton.onClick.AddListener(StartSlicingWindow);
    }

    // Update is called once per frame
    void StartSlicingWindow()
    {
        SliceScreen.SetActive(true);


    }
}
