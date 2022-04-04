using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class AreaPlacement : MonoBehaviour
{
    [SerializeField] private ARSessionOrigin aRSessionOrigin;
    [SerializeField] private GameObject Game;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
    private GameObject instantiatedGame;
    int score;
    public Text scoreCount;

    public void placeObject()
    {
        bool collision = aRSessionOrigin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition,
                raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

        if (collision)
        {
            if (instantiatedGame == null)
            {
                instantiatedGame = Instantiate(Game);

                foreach (var plane in aRSessionOrigin.GetComponent<ARPlaneManager>().trackables)
                    plane.gameObject.SetActive(false);

                aRSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
                
            }

            instantiatedGame.transform.position = raycastHits[0].pose.position;
            score = score + 1;
            scoreCount.text = score + "";
        }
    }
}
