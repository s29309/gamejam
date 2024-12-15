using UnityEngine;
using UnityEngine.SceneManagement;


public class EscMenu : MonoBehaviour {
    [SerializeField] private GameObject menu;

    private void Awake() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGameButtonPressed() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButtonPressed() {
        SceneManager.LoadScene("Start Menu");
    }

    public void RestartGameButtonPressed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}