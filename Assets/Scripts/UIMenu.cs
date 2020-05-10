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
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }
}
