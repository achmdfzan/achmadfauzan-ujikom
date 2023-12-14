using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    private AudioSource buttonClickSound;

    private void Start()
    {
        buttonClickSound = GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        buttonClickSound.Play();
        Application.Quit();
    }
}
