using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pannel : MonoBehaviour
{
    public GameObject FirstPanel;
    public GameObject CameraPanel;
    public GameObject LaserPanel;
    public GameObject LensePanel;
    public GameObject FilterPanel;
    public GameObject MirrorPanel;
    public GameObject ObjectivePanel;
    // Start is called before the first frame update
    void Start()
    {
        FirstPanel.gameObject.SetActive(false);
        CameraPanel.gameObject.SetActive(false);
        LaserPanel.gameObject.SetActive(false);
        LensePanel.gameObject.SetActive(false);
        FilterPanel.gameObject.SetActive(false);
        MirrorPanel.gameObject.SetActive(false);
        ObjectivePanel.gameObject.SetActive(false);
    }

    //open and close the first panel
    public void InteractFristPanel() {

        if (FirstPanel.activeSelf == false)
        {
            FirstPanel.gameObject.SetActive(true);

        }
        else {
            FirstPanel.gameObject.SetActive(false);
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            FilterPanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);

        }

    }
    //open and close the second panel (lense panel)
    public void InteractLensePanel()
    {

        if (LensePanel.activeSelf == false)
        {
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(false);
            FilterPanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(true);

        }
        else
        {
            LensePanel.gameObject.SetActive(false);

        }

    }
    //open and close the second panel (filter panel)
    public void InteractFilterPanel()
    {

        if (FilterPanel.activeSelf == false)
        {
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);
            FilterPanel.gameObject.SetActive(true);
        }
        else
        {
            FilterPanel.gameObject.SetActive(false);

        }

    }
    //open and close the second panel (Mirror panel)
    public void InteractMirrorPanel()
    {

        if (MirrorPanel.activeSelf == false)
        {
            FilterPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(true);
        }
        else
        {
            MirrorPanel.gameObject.SetActive(false);

        }

    }
    //open and close the second panel (objective panel)
    public void InteractObjectivePanel()
    {

        if (ObjectivePanel.activeSelf == false)
        {
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(false);
            FilterPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(true);
            
        }
        else
        {
            ObjectivePanel.gameObject.SetActive(false);

        }

    }

    public void InteractCameraPanel()
    {

        if (CameraPanel.activeSelf == false)
        {
            
            LaserPanel.gameObject.SetActive(false);
            FilterPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);
            CameraPanel.gameObject.SetActive(true);

        }
        else
        {
            CameraPanel.gameObject.SetActive(false);

        }

    }

    public void InteractLaserPanel()
    {

        if (CameraPanel.activeSelf == false)
        {

            
            FilterPanel.gameObject.SetActive(false);
            LensePanel.gameObject.SetActive(false);
            MirrorPanel.gameObject.SetActive(false);
            ObjectivePanel.gameObject.SetActive(false);
            CameraPanel.gameObject.SetActive(false);
            LaserPanel.gameObject.SetActive(true);
        }
        else
        {
            LaserPanel.gameObject.SetActive(false);

        }

    }
}
