using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlingScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Slider slider;

    public void luanchBall()
    {
        GameObject ballInit = Instantiate(gameObject, arCamera.transform.position, arCamera.transform.rotation);
        Vector3 impulse = new Vector3(1, 0, slider.value + 300f);
        ballInit.GetComponent<Rigidbody>().AddRelativeForce(impulse);
    }

}
