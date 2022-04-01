using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectPlacement : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin arSessionOrigin;
    [SerializeField] private GameObject game;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private GameObject instantiatedGame;

    public void placeObject()
    {
        bool collisionOccured = arSessionOrigin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

        if (collisionOccured)
        {
            if (instantiatedGame == null)
            {
                instantiatedGame = Instantiate(game);
                foreach (var plane in arSessionOrigin.GetComponent<ARPlaneManager>().trackables) plane.gameObject.SetActive(false);  // Delete Trackable Visualizers shown
                arSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
            }
            instantiatedGame.transform.position = raycastHits[0].pose.position;
        }
    }
}
