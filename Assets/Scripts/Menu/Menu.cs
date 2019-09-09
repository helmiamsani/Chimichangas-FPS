using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Color")]
    public Color menuColour;
    public Color chimichangasColour;
    public Color startColour;

    [Header("References")]
    public Player playerScrpt;
    public Health playerHealth;
    [Header("Menu")]
    public GameObject menu;
    public Text chimichangasText;
    public Text startText;
    [Header("Death Menu")]
    public GameObject deathMenu;
    public Text gameOverText;
    public Text newGameText;
    [Header("UI")]
    public GameObject UI;

    private Image menuImage;
    private Image deathMenuImage;
    private bool menuOff = false;
    private PlatformManager platform;

    private void Start()
    {
        menu.SetActive(true);
        deathMenu.SetActive(false);
        platform = GetComponent<PlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(menuOff)
        {
            menuColour.a -= Time.deltaTime;
            menuImage.color = menuColour;
            chimichangasColour.a -= Time.deltaTime;
            chimichangasText.color = chimichangasColour;
            startColour.a -= Time.deltaTime;
            startText.color = startColour;

            if(menuColour.a <= 0 && chimichangasColour.a <= 0 && startColour.a <= 0)
            {
                menu.SetActive(false);
                playerScrpt.canMove = true;
                menuOff = false;
            }
        }

        if(playerHealth.dead)
        {
            deathMenu.SetActive(true);

            menuColour.a += Time.deltaTime;
            deathMenuImage = deathMenu.GetComponent<Image>();
            deathMenuImage.color = menuColour;
            chimichangasColour.a += Time.deltaTime;
            gameOverText.color = chimichangasColour;
            startColour.a += Time.deltaTime;
            newGameText.color = startColour;

            if (menuColour.a >= 1 && chimichangasColour.a >= 1 && startColour.a >= 1)
            {
                menuColour.a = 1;
                chimichangasColour.a = 1;
                startColour.a = 1;
            }
        }

        if (platform.PC)
        {
            UI.SetActive(false);
        }
        if (platform.Mobile)
        {
            UI.SetActive(true);
        }
    }

    public void MenuOff()
    {
        menuImage = menu.GetComponent<Image>();
        menuOff = true;
    }
}
