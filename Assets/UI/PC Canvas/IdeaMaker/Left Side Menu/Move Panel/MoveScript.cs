using UnityEngine;

public class MoveScript : MonoBehaviour
{
    int i = 0;
    public GameObject Background;
    //public Color32 blue;

    Vector3 temp;
    private void Start()
    {
        temp = transform.position;
        Background.GetComponent<UnityEngine.UI.Image>().color = Color.grey;

    }

    public void PressRedArrow() { i = 0; Background.GetComponent<UnityEngine.UI.Image>().color = Color.red; }
    public void PressBlueArrow() { i = 1; Background.GetComponent<UnityEngine.UI.Image>().color = Color.blue; }
    public void PressGreenArrow() { i = 2; Background.GetComponent<UnityEngine.UI.Image>().color = Color.green; }



    public void OnMoveSliderValueChanged(float sliderVal)
    {


        switch (i)
        {
            default:
                break;
            case 0:
                temp.x = -sliderVal;
                transform.localPosition = temp;

                break;
            case 1:
                temp.y = sliderVal - 150;
                transform.localPosition = temp;

                break;
            case 2:
                //temp.z = sliderVal;
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, sliderVal);

                break;
        }
    }

}
