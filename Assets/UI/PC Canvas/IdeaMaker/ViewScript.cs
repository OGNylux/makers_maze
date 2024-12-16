using UnityEngine;
using UnityEngine.UI;

public class ViewScript : MonoBehaviour
{
    int i = 0;
    public GameObject Background;

    Vector3 rotationAngles;

    private void Start()
    {
        rotationAngles = transform.rotation.eulerAngles;
        Background.GetComponent<Image>().color = Color.grey;
    }

    public void PressRedArrow()
    {
        i = 0;
        Background.GetComponent<Image>().color = Color.red;
    }

    public void PressBlueArrow()
    {
        i = 1;
        Background.GetComponent<Image>().color = Color.blue;
    }

    //public void PressGreenArrow()
    //{
      //  i = 2;
      //  Background.GetComponent<Image>().color = Color.green;
    //}

    public void OnRotateSliderValueChanged(float sliderVal)
    {
        switch (i)
        {
            default:
                break;
            case 0:
                rotationAngles.x = sliderVal;
                transform.rotation = Quaternion.Euler(rotationAngles);
                break;
            case 1:
                rotationAngles.y = sliderVal;
                transform.rotation = Quaternion.Euler(rotationAngles);
                break;
            //case 2:
              //  rotationAngles.z = sliderVal;
              //  transform.rotation = Quaternion.Euler(rotationAngles);
              //  break;
        }
    }
}
