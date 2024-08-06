using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestBR.Core
{
    public class ChangeScene : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("MainScene");
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
