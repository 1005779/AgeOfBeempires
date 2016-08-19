using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    // Nessesary links
    private GameManager gameManager;
    private QueenHive queenHive;
    
    // Pause / Play variables
    public GameObject pauseCanvas;
    public GameObject playCanvas;
    public GameObject selection;

    // Text Varibles
    public float timer;
    public float Honey;
    public float Wax;

    // Text For UI
    public Text time;
    public Text honey;
    public Text wax;

    // Use this for initialization
    void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        queenHive = GameManager.FindObjectOfType<QueenHive>();
    }

    // Update is called once per frame
    void Update () {
        Pause();
        Text();

        timer += Time.deltaTime;

        Honey = queenHive.honey;
        Wax = queenHive.wax;
	}

    private void Text()
    {
        time.text = "Time: " + timer;
        honey.text = "Honey: " + Honey;
        wax.text = "Wax: " + Wax;
    }

    public void Pause()
    {
        // When esc key is pressed game will pause or play
        if(Input.GetKeyDown(KeyCode.Escape))
            if (pauseCanvas.gameObject.activeInHierarchy == false)
            {
                playCanvas.gameObject.SetActive(false);  // De-Activates the play Canvas
                pauseCanvas.gameObject.SetActive(true);  // Activates Pause Canvas
                Time.timeScale = 0;  //  Stops Time
                selection.GetComponent<Bee>().enabled = false;  // Dissables Player interaction
            }
                else
            {
                pauseCanvas.gameObject.SetActive(false);  //Turns Off Pause Canvas
                playCanvas.gameObject.SetActive(true);  // activates the play Canvas
                Time.timeScale = 1;   // Returns Time to normal
                selection.GetComponent<SelectionManager>().enabled = true; // Dissables Player interaction
            }
    }

    /* 
    Buttons
    */

    public void Play()
    {
        pauseCanvas.gameObject.SetActive(false);  //Turns Off Pause Canvas
        playCanvas.gameObject.SetActive(true);  // activates the play Canvas
        Time.timeScale = 1;  // Returns Time to normal
        selection.GetComponent<SelectionManager>().enabled = true; // Dissables Player interaction
    }

    public void Main()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
}
