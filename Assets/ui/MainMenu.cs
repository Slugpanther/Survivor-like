using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SimpleBtn btn;
    [SerializeField] SimpleBtn btn2;
    [SerializeField] SimpleBtn btn3;

    [SerializeField] Image img;
    [SerializeField] Image img2;
    [SerializeField] Image img3;


    // Start is called before the first frame update
    void Start()
    {
        btn.OnClick += ChangeRed;
        btn2.OnClick += ChangeGreen;
        btn3.OnClick += ChangeBlue;
    }

    void ChangeRed()
    {
        img.color = Color.red;
    }

    void ChangeGreen()
    {
        img2.color = Color.green;
    }

    void ChangeBlue()
    {
        img3.color = Color.blue;
    }
}
