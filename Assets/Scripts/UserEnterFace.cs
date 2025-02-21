using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserEnterFace : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private RoadGenerator _generator;
    [SerializeField] private PlayerController _player;

    public static Action action;

    void Start()
    {
        _startPanel.SetActive(true);
        _generator.Speed = 0;
        _player.enabled = false;
        _player.GetComponent<Rigidbody>().isKinematic = true;
        _gameoverPanel.SetActive(false);
        action += GameOver;
    }

    public void StartGame()
    {
        _startPanel.SetActive(false);
        _generator.Speed = 6;
        _player.enabled = true;
        _player.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void GameOver()
    {
        if (_gameoverPanel != null)
        {
       _gameoverPanel.SetActive(true);
        _player.enabled = false;
        _generator.Speed = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
