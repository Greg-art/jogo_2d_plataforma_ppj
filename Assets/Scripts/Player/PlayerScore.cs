﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreDisplay = default;
    [SerializeField]
    private TextMeshProUGUI _gameOverScoreDisplay = default;

    private int _currentScore = 0;

    void Start()
    {
        _currentScore = DataTrackerPlayer.Instance.TotalScore;
        _scoreDisplay.SetText($"x{_currentScore}");
        _gameOverScoreDisplay.SetText($"Sua pontuação: {_currentScore}");
    }

    public void IncreaseScore(int givenScore)
    {
        _currentScore += givenScore;
        _scoreDisplay.SetText($"x{_currentScore}");
        _gameOverScoreDisplay.SetText($"Sua pontuação: {_currentScore}");
        SoundManager.PlaySound("coin");
    }

    public void DumpScore()
    {
        DataTrackerPlayer.Instance.TotalScore = _currentScore;
    }
}
