using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _play;

    [SerializeField]
    private string _levelSceneName;

    void Start()
    {
        _play.onClick.AddListener(StartLevel);
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(_levelSceneName);
    }
}
