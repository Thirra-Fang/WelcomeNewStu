using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel1 : MonoBehaviour
{
    int curStep;
    [SerializeField] GameObject[] textBox;
    [SerializeField] MainCanvas mainCanva;
    // Start is called before the first frame update
    void Start()
    {
        curStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (curStep < textBox.Length)
            {
                textBox[curStep].SetActive(true);
                curStep++;
            }
            else
            {
                mainCanva.changePanelTo(4);
            }
        }
    }
}
