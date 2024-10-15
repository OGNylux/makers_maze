using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int Count;

    public TextMeshProUGUI ScoreText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Goal"))
        {
            Count++;
            ScoreText.text = Count.ToString();
        }
    }
}
