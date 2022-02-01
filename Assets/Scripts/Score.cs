using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI counter;
    public int count;

    // Update is called once per frame
    void Update()
    {
        counter.text = count.ToString();
    }
}
