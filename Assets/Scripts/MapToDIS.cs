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

    // Start is called before the first frame update
    void Start()
    {
        mapRefDistance = Vector3.Distance(refPoints[0].position, refPoints[1].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSmallScale)
            {
                mainCanvas.SetDistanceToWuhan(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, refPoints[0].position) / mapRefDistance * refDistance);
                mainCanvas.ChangePanel();
                gameObject.SetActive(false);
            }
            else
            {
                mainCanvas.SetDistanceToHust(Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10, refPoints[0].position) / mapRefDistance * refDistance);
                mainCanvas.changePanelTo(3);
                gameObject.SetActive(false);
            }
        }
    }
}
