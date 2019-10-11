using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public Player playerScrpt; // playerScrpt stores Player.
    public Health playerHealth; // playerHealth stores Health.
    [Header("Menu")]
    public GameObject menu; // menu stores menu panel.
    public Text chimichangasText; // chimichangasText stores chimichangas text.
    public Text startText; // startText stores start text.
    [Header("Death Menu")]
    public GameObject deathMenu; // deathMenu stores death panel.
    public Text gameOverText; // gameOverText stores game over text.
    public Text newGameText; // newGameText stores new game text.
    [Header("UI")]
    public GameObject UI; // UI stores UI game panel.

    private Image _menuImage; 
    private Image _deathMenuImage;
    private bool _menuOff = false;
    private PlatformManager _platform;
    private Color _menuColour; // menuColour stores background colour.
    private Color _chimichangasColour; // chimichangas stores Chimichangas text colour.
    private Color _startColour; // startColour stores start text colour.
    #endregion

    private void Start()
    {
        menu.SetActive(true); // Set menu as an active panel.
        deathMenu.SetActive(false); // Set deathMenu as a non-active panel.
        _platform = GetComponent<PlatformManager>(); // Get PlatformManager.
    }

    public void MenuOff() // This Will be called after player press start button
    {
        _menuImage = menu.GetComponent<Image>(); // Get image component from Menu panel.
        _menuOff = true; // _menuOff is set to active.
    }

    // Update is called once per frame
    void Update()
    {
        if(_menuOff) // When _menuOff is active
        {
            _menuColour = _menuImage.color; // _menuColour stores Menu colour (background colour of the menu).
            _menuColour.a -= Time.deltaTime; // _menuColour.a (opacity of _menuColour) is decreased overtime. 
            _menuImage.color = _menuColour; // _menuImage.color stores _menuColour (colour that is decreased overime).

            _chimichangasColour = chimichangasText.color; // _chimichangasColour stores the colour of Chimichangas Text.
            _chimichangasColour.a -= Time.deltaTime; // _chimichangasColour.a (opacity of _chimichangasColour) is decreased overtime. 
            chimichangasText.color = _chimichangasColour; // chimichangasText.color stores _chimichangasColour (colour that is decreased overime).

            _startColour = startText.color; // _startColour stores the colour of Start Text.
            _startColour.a -= Time.deltaTime; // _startColour.a (opacity of _startColour) is decreased overtime. 
            startText.color = _startColour; // startText.color stores _startColour (colour that is decreased overime).

            if (_menuColour.a <= 0 && _chimichangasColour.a <= 0 && _startColour.a <= 0) // If all colours opacity are equal to 0
            {
                menu.SetActive(false); // Menu panel is not active.
                playerScrpt.canMove = true; // Player can move.
                _menuOff = false; // _menuOff is not active.
            }
        }

        if(playerHealth.dead) // When player is dead.
        {
            deathMenu.SetActive(true); // deathMenu is Active.

            _deathMenuImage = deathMenu.GetComponent<Image>(); // Get the image of death panel.

            //>>> Same process as on the start menu <<< 
            // Difference is that the opacity of each colours will increase.
            _menuColour = _deathMenuImage.color;  
            _menuColour.a += Time.deltaTime;
            _deathMenuImage.color = _menuColour;

            _chimichangasColour = gameOverText.color;
            _chimichangasColour.a += Time.deltaTime;
            gameOverText.color = _chimichangasColour;

            _startColour = newGameText.color;
            _startColour.a += Time.deltaTime;
            newGameText.color = _startColour;

            if (_menuColour.a >= 1 && _chimichangasColour.a >= 1 && _startColour.a >= 1) // When the colours are equal to or more than 1 
            {
                // All colours are set to 1.
                _menuColour.a = 1;
                _chimichangasColour.a = 1;
                _startColour.a = 1;
            }
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        }

        if (_platform.PC) // If it is on PC
        {
            UI.SetActive(false); // UI is not active.
        }
        if (_platform.Mobile) // If it is on Mobile
        {
            UI.SetActive(true); // UI is active.
        }
    }

    //private void ColourChanging(Color savedColour, Color shownColour)
    //{
    //    savedColour = shownColour; // savedColour stores shownColour (Colour presents in the game).
    //    savedColour.a -= Time.deltaTime; // Decrease savedColour opacity overtime.
    //    shownColour = savedColour; // shownColour stores savedColour (Colour that its opacity decreases overtime).
        
    //    if(savedColour.a <= 0)
    //    {
    //        menu.SetActive(false);
    //        playerScrpt.canMove = true;
    //        _menuOff = false;
    //    }
    //    else if(savedColour.a >= 1)
    //    {
    //        savedColour.a = 1;
    //    }
    //}
}
