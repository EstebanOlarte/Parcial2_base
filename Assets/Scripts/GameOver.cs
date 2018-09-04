using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public Text texto;

    public void gameOver()
    {
        Time.timeScale = 0F;
        texto.text = "Game Over";
    }

}
