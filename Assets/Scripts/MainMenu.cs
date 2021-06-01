using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _play;
    private int idScene = 1;

    private void Start()
    {
        _play.onClick.AddListener(Play);

    }

    private void Play()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(idScene);
    }
}
