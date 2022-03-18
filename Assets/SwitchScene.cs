using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //public string SceneName;
    public int LevelIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Camera cam = gameObject.GetComponent<Camera>();
        if (cam.tag == "MainCamera")
            SceneManager.LoadScene(LevelIndex);
    }
}
