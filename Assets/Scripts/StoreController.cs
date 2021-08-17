using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    [SerializeField] private GameObject gameName, highscore, tapToStart, storeButton, menuButton, floor, platform, touchScreen, backgroundTxt, platformsTxt, playerTxt, moneyTxt;
    [SerializeField] private Sprite[] backgroundSkins, platformsSkins, playerSkins;
    [SerializeField] private Image background, backgroundSkin, platformsSkin, playerSkin, backgroundLeft, backgroundRight, platformsLeft, platformsRight, playerLeft, playerRight;
    void Start()
    {
        background.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
        floor.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        platform.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        moneyTxt.GetComponent<Text>().text = "Money: " + PlayerPrefs.GetInt("Money", 0).ToString();
    }
    public void GoToStore()
    {
        gameName.SetActive(false);
        highscore.SetActive(false);
        tapToStart.SetActive(false);
        storeButton.SetActive(false);
        floor.SetActive(false);
        platform.SetActive(false);
        touchScreen.SetActive(false);
        backgroundSkin.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
        platformsSkin.sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        playerSkin.sprite = playerSkins[PlayerPrefs.GetInt("PlayerSprite", 0)];
        moneyTxt.SetActive(true);
        menuButton.SetActive(true);
        backgroundTxt.SetActive(true);
        platformsTxt.SetActive(true);
        playerTxt.SetActive(true);
        backgroundSkin.enabled = true;
        platformsSkin.enabled = true;
        playerSkin.enabled = true;
        backgroundLeft.enabled = true;
        backgroundRight.enabled = true;
        platformsLeft.enabled = true;
        platformsRight.enabled = true;
        playerLeft.enabled = true;
        playerRight.enabled = true;
    }
    public void GoToMenu()
    {
        moneyTxt.SetActive(false);
        menuButton.SetActive(false);
        backgroundTxt.SetActive(false);
        platformsTxt.SetActive(false);
        playerTxt.SetActive(false);
        backgroundSkin.enabled = false;
        platformsSkin.enabled = false;
        playerSkin.enabled = false;
        backgroundLeft.enabled = false;
        backgroundRight.enabled = false;
        platformsLeft.enabled = false;
        platformsRight.enabled = false;
        playerLeft.enabled = false;
        playerRight.enabled = false;

        gameName.SetActive(true);
        highscore.SetActive(true);
        tapToStart.SetActive(true);
        storeButton.SetActive(true);
        floor.SetActive(true);
        platform.SetActive(true);
        touchScreen.SetActive(true);
    }
    public void BackgroundLeft()
    {
        if (PlayerPrefs.GetInt("BackgroundSprite", 0) > 0)
        {
            PlayerPrefs.SetInt("BackgroundSprite", PlayerPrefs.GetInt("BackgroundSprite", 0) - 1);
            backgroundSkin.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
            background.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
        }
    }
    public void BackgroundRight()
    {
        if (PlayerPrefs.GetInt("BackgroundSprite", 0) < backgroundSkins.Length - 1)
        {
            PlayerPrefs.SetInt("BackgroundSprite", PlayerPrefs.GetInt("BackgroundSprite", 0) + 1);
            backgroundSkin.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
            background.sprite = backgroundSkins[PlayerPrefs.GetInt("BackgroundSprite", 0)];
        }
    }
    public void PlatformsLeft()
    {
        if (PlayerPrefs.GetInt("PlatformsSprite", 0) > 0)
        {
            PlayerPrefs.SetInt("PlatformsSprite", PlayerPrefs.GetInt("PlatformsSprite", 0) - 1);
            platformsSkin.sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
            floor.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
            platform.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        }
    }
    public void PlatformsRight()
    {
        if (PlayerPrefs.GetInt("PlatformsSprite", 0) < platformsSkins.Length - 1)
        {
            PlayerPrefs.SetInt("PlatformsSprite", PlayerPrefs.GetInt("PlatformsSprite", 0) + 1);
            platformsSkin.sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
            floor.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
            platform.GetComponent<SpriteRenderer>().sprite = platformsSkins[PlayerPrefs.GetInt("PlatformsSprite", 0)];
        }
    }
    public void PlayerLeft()
    {
        if (PlayerPrefs.GetInt("PlayerSprite", 0) > 0)
        {
            PlayerPrefs.SetInt("PlayerSprite", PlayerPrefs.GetInt("PlayerSprite", 0) - 1);
            playerSkin.sprite = playerSkins[PlayerPrefs.GetInt("PlayerSprite", 0)];
        }
    }
    public void PlayerRight()
    {
        if (PlayerPrefs.GetInt("PlayerSprite", 0) < playerSkins.Length - 1)
        {
            PlayerPrefs.SetInt("PlayerSprite", PlayerPrefs.GetInt("PlayerSprite", 0) + 1);
            playerSkin.sprite = playerSkins[PlayerPrefs.GetInt("PlayerSprite", 0)];
        }
    }
}
