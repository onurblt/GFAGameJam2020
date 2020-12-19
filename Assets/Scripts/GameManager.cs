using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public void StartGame()
    {
        canvas.SetActive(false);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
    }
}
