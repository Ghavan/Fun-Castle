using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int score;
    public Text scoreCount;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Sphere(Clone)")
        {
            score = score + 1;
            scoreCount.text = score + "";
        }
    }
    }
