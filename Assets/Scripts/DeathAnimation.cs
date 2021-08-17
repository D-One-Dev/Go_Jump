using UnityEngine;
using UnityEngine.UI;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private Text txt;
    public bool dead;
    void FixedUpdate()
    {
        if(dead)
        {
            if (blackScreen.color.a < 1f) blackScreen.color += new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Time.fixedDeltaTime);
            if (txt.color.a < 1f) txt.color += new Color(txt.color.r, txt.color.g, txt.color.b, Time.fixedDeltaTime);
        }
    }
}
