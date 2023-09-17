using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToDIS : MonoBehaviour
{
    [SerializeField] Transform[] refPoints;
    [SerializeField] float refDistance;
    [SerializeField] MainCanvas mainCanvas;
    [SerializeField] bool isSmallScale;

    float mapRefDistance;
    Vector3 tempPos;
    bool setedPos1;

    // Start is called before the first frame update
    void Awake()
    {
        mapRefDistance = Vector3.Distance(refPoints[0].position, refPoints[1].position);
        tempPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSmallScale)
            {
                //Debug.Log(refPoints[2].position);
                //Debug.Log(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, refPoints[2].position) / mapRefDistance * refDistance);
                mainCanvas.SetDistanceToWuhan(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, refPoints[2].position) / mapRefDistance * refDistance);
                mainCanvas.ChangePanel();
                gameObject.SetActive(false);
            }
            else if(!setedPos1)
            {
                setedPos1 = true;
                tempPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
                mainCanvas.ChangePanel();
            }
            else
            {
                mainCanvas.SetDistanceToHust(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, tempPos) / mapRefDistance * refDistance);
                mainCanvas.changePanelTo(5);
                gameObject.SetActive(false);
            }
        }
    }
}
