using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject GameOverScreen;

    private void Awake()
    {
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            GameOverScreen.SetActive(true);
        }
    }

    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
