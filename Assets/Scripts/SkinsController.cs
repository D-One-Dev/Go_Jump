using UnityEngine;
using UnityEngine.UI;

public class SkinsController : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundSkins, platformsSkins, playerSkins;
    [SerializeField] private Image background;
    [SerializeField] private GameObject player, floor;
    void Start()
    {
        background.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
        floor.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        player.GetComponent<SpriteRenderer>().sprite = playerSkins[PlayerPrefs.GetInt("PlayerSprite", 0)];
    }
}
