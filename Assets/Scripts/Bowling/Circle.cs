using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.EventSystems;

public class Circle : MonoBehaviour
{

    int objIndex;

    public GameObject[] virtual_objects;
    public GameObject[] buttons;

    public GameObject placementIndicator;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = true;

    private bool placementIndicatorEnabled = true;

    bool isUIHidden = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {

        if (placementIndicatorEnabled == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }

    }
    

    public void PlaceObject() {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < buttons.Length; i++) {

            if (buttons[i].name == buttonName) {

                objIndex = i;
            }
        }

            virtual_objects[0].SetActive(true);
            virtual_objects[0].transform.position = placementPose.position;
            virtual_objects[0].transform.rotation = placementPose.rotation;

        
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);

            foreach (var button in buttons) {
                button.gameObject.SetActive(true);
            }


            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);

            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }


        }
    }

    public void HideUI()
    {

        if (isUIHidden == false)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }

            placementIndicatorEnabled = false;
            placementIndicator.SetActive(false);

            isUIHidden = true;
        }

        else if (isUIHidden == true)
        {

            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }

            placementIndicatorEnabled = true;
            placementIndicator.SetActive(true);

            isUIHidden = false;

        }
    }
}
