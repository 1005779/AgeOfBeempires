using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
