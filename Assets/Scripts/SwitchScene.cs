using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    //public string SceneName;
    public int CubeShooterScene;
    public int BowlingScene;

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
        if (other.gameObject.CompareTag("CubeShooterDoor"))
        {
            Debug.Log("Switching Room");
            SceneManager.LoadScene(CubeShooterScene);
        }
        if (other.gameObject.CompareTag("BowlingDoor"))
        {
            Debug.Log("Switching Room");
            SceneManager.LoadScene(BowlingScene);
        }
    }
}
