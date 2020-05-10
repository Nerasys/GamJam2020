using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject buttons;
    [SerializeField] GameObject credits;


    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("NewGame");
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        buttons.SetActive(false);
        credits.SetActive(true);
    }


    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        Application.Quit();
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        buttons.SetActive(true);
        credits.SetActive(false);
    }
}
