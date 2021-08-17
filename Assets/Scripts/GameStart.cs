using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject touchScreen;
    private float timer;
    private bool active;
    private void FixedUpdate()
    {
        if (timer < 0.5f && !active) timer += Time.fixedDeltaTime;
        else if(!active)
        {
            active = true;
            touchScreen.SetActive(true);
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
}
