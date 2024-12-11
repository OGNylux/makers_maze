using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PrinterCanvasScript : MonoBehaviour
{

    public GameObject TaskFinished;
    public GameObject PrintPreview;
    public GameObject Unload1;
    public GameObject Unload2;
    public GameObject VideoUnloadScreen;
    public GameObject Load1;
    public GameObject Load2;
    public GameObject VideoLoadScreen;
    public GameObject PrintingProcess;
    public GameObject HomeScreen;
    public GameObject Utilities;
    public GameObject Print;
    public GameObject USBStorage;
    public Button UnloadButton;
    public Button LoadButton;
    public VideoPlayer VideoUnload;
    public VideoPlayer VideoLoad;
    public GameObject BigCanvas;
    public GameObject ArmfileButton;
    public GameObject BottomMenu;
    public GameObject PrinterCanvas;
    public GameObject parent5;





    // Start is called before the first frame update
    void Start()
    {
        PrinterCanvas.SetActive(false);
        BigCanvas.SetActive(false);
        TaskFinished.SetActive(false);
        PrintPreview.SetActive(false);
        Unload1.SetActive(false);
        Unload2.SetActive(false);
        Load1.SetActive(false);
        Load2.SetActive(false);
        PrintingProcess.SetActive(false);
        HomeScreen.SetActive(false);
        Utilities.SetActive(false);
        Print.SetActive(false);
        USBStorage.SetActive(false);
        UnloadButton.onClick.AddListener(PlayVideoUnload);
        LoadButton.onClick.AddListener(PlayVideoLoad);
        VideoUnload.loopPointReached += OnVideoUnloadEnd;
        VideoLoad.loopPointReached += OnVideoLoadEnd;
        ArmfileButton.SetActive(false);
        BottomMenu.SetActive(false);
        VideoUnloadScreen.SetActive(false);
        VideoLoadScreen.SetActive(false);


    }

    // Update is called once per frame
    void PlayVideoUnload()
    {
        VideoUnloadScreen.SetActive(true);
        Unload1.SetActive(false);
        Unload2.SetActive(false);
        VideoUnload.Play();

    }

    void PlayVideoLoad()
    {
        Debug.Log("PlayVideoLoad");
        
        Load1.SetActive(false);
        Load2.SetActive(false);
        parent5.SetActive(true);
        VideoLoadScreen.SetActive(true);

        VideoLoad.enabled =true;
        VideoLoad.Play();
        Debug.Log(VideoLoad.isPlaying);

    }

    void OnVideoUnloadEnd(VideoPlayer player)
    {
        Utilities.SetActive(true);
        VideoUnloadScreen.SetActive(false);

    }

    void OnVideoLoadEnd(VideoPlayer player)
    {
        Utilities.SetActive(true);
        VideoLoadScreen.SetActive(false);

    }
}
