using UnityEngine;

using UnityEngine.UI;

public class EditButtonScript : MonoBehaviour
{
    public Button EditButton;
    public GameObject MovePopUp;
    public GameObject RotatePopUp;

    private bool isPanelVisible = true;

    private void Start()
    {
        // Hide the panel initially
        //MovePanel.SetActive(false);

        // Attach button click event listener
        EditButton.onClick.AddListener(TogglePanelVisibility);
        
    }

    private void TogglePanelVisibility()
    {
        // Toggle the panel visibility
        isPanelVisible = !isPanelVisible;
        MovePopUp.SetActive(isPanelVisible);
        RotatePopUp.SetActive(isPanelVisible);


    }
}
