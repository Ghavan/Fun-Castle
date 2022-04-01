using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class ARFocusCircle : MonoBehaviour
{
   int objIndex;

    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool isPlacementPosevalid = true;
    private bool isPlacementIndicatorOn = true;
    public GameObject[] virtual_objects;
    public GameObject[] buttons;
    public GameObject placementIndicator;
    bool hiddenUI = false;

    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {

        if (isPlacementIndicatorOn == true)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();
        }
    }

    public void PlaceObject()
    {

        string buttonName = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < buttons.Length; i++)
        {

            if (buttons[i].name == buttonName)
            {

                objIndex = i;
            }
        }
        virtual_objects[0].SetActive(true);
        virtual_objects[0].transform.position = placementPose.position;
        virtual_objects[0].transform.rotation = placementPose.rotation;
    }

    private void UpdatePlacementIndicator()
    {
        if (isPlacementPosevalid)
        {
            placementIndicator.SetActive(true);

            foreach (var button in buttons)
            {
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
 

    public void HideUI() {

        if (hiddenUI == false)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }
            isPlacementIndicatorOn = false;
            placementIndicator.SetActive(false);
            hiddenUI = true;
        }
        else if (hiddenUI == true) {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);
            }

            isPlacementIndicatorOn = true;
            placementIndicator.SetActive(true);

            hiddenUI = false;

        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated);
        isPlacementPosevalid = hits.Count > 0;
        if (isPlacementPosevalid)
        {
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
