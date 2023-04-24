using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "Game Over\nFinal Score: " + GameScript.GetScore().ToString() + "/" + GameScript.GetMaxScore().ToString();
    }
}
