using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{
    [SerializeField] private Text highScore;
    void Start()
    {
        if (PlayerPrefs.GetInt("Highscore", -1) == -1) highScore.enabled = false;
        else
        {
            highScore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
            highScore.enabled = true;
        }
    }
}
