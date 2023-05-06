using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance ==  null) {
            Instance = this; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "�ְ� ����: " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Score
    {
        get { 
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "���� ���� : " + currentScore;

            if(currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "�ְ� ���� : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
}
