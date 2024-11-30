using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GUI
{
    public class StartMenuManager : MonoBehaviour
    {
        public GameObject mainView;
        public GameObject controlsView;
        public GameObject creditsView;

        private void Start() {
            mainView.SetActive(true);
            controlsView.SetActive(false);
            creditsView.SetActive(false);
        }
        
        public void StartClicked(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }

        public void ControlsClicked(string sceneName)
        {
            mainView.SetActive(false);
            controlsView.SetActive(true);
            creditsView.SetActive(false);
        }

        public void CreditsClicked()
        {
            mainView.SetActive(false);
            controlsView.SetActive(false);
            creditsView.SetActive(true);
        }
        
        public void BackClicked() {
            mainView.SetActive(true);
            controlsView.SetActive(false);
            creditsView.SetActive(false);
        }

        public void ExitClicked() {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else 
                Application.Quit();
            #endif
        }
    }
}
