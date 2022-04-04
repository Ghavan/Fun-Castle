using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToHome : MonoBehaviour
{
    //public string SceneName;
    public int HomeScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    //void OnTriggerEnter(Collider other)
    // {
    //   Camera cam = gameObject.GetComponent<Camera>();
    //    if (cam.tag == "MainCamera")
    //        SceneManager.LoadScene(LevelIndex);
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PortalDoor"))
        {
            Debug.Log("Switching to Home");
            SceneManager.LoadScene(HomeScene);
        }
    }
}
