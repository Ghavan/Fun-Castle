using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public GameObject[] Cubes;
    public string[] specificCube = new string[4];
    public GameObject arCamera;
    public GameObject gameOverScreen;
    public bool stop;
    //   public GameObject smoke;
    int score;
    public Text scoreCount;
    public Text FinalScoreText;

    int randSpecificCube;
    public Text specificCubeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpecificSpawner());
    }

    IEnumerator waitSpecificSpawner()
    {
        yield return new WaitForSeconds(1);

        while (!stop)
        {

            randSpecificCube = Random.Range(0, 4);
            specificCubeText.text = specificCube[randSpecificCube];

            yield return new WaitForSeconds(6);
        }
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Blue(Clone)" || hit.transform.name == "Green(Clone)" || hit.transform.name == "Red(Clone)" || hit.transform.name == "Yellow(Clone)")
            {
                Destroy(hit.transform.gameObject);
                if (hit.transform.name == specificCubeText.text + "(Clone)")
                {
                    score = score + 1;
                    scoreCount.text = score + "";
                }
                else if (hit.transform.name != specificCubeText.text + "(Clone)") {
                    GameOver();
                }
            }
        }
    }
    void GameOver() {
        gameOverScreen.SetActive(true);
        FinalScoreText.text = "Your Final Score:" + score;
    }

    public void RestartGame() {
        gameOverScreen.SetActive(false);
        score = 0;
        scoreCount.text = 0 + "";
    }


    // Update is called once per frame
    //  void Update()
    //  {

    //  }
}




