using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text score;
    public int scoreValue;
    public void AddScore()
    {
        scoreValue++;
        score.text = scoreValue.ToString();
    }
}
