using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bowling : MonoBehaviour
{
    [SerializeField] private GameObject ballObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Slider slider;


    public void luanchBall()
    {
        GameObject ballInstantiated = Instantiate(ballObject, arCamera.transform.position, arCamera.transform.rotation);
        Vector3 impulse = new Vector3(1, 0, slider.value + 300f);
        ballInstantiated.GetComponent<Rigidbody>().AddRelativeForce(impulse);
    }

}
