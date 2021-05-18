using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _play;
    [SerializeField] GameObject _level;

    private void Start()
    {
        _play.onClick.AddListener(Play);

    }

    private void Play()
    {
        _level.SetActive(true);
        gameObject.SetActive(false);
    }
}
