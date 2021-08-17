using UnityEngine;
using UnityEngine.UI;

public class StartTextAnimation : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Outline ol;
    private float alpha;
    void FixedUpdate()
    {
        alpha = Mathf.PingPong(Time.time / 1.5f, 1f);
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, alpha);
        ol.effectColor = new Color(ol.effectColor.r, ol.effectColor.g, ol.effectColor.b, alpha);
    }
}
