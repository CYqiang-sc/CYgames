using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    public GameObject addScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetText(score);
        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(int score)
    {
        this.gameObject.GetComponent<Text>().text = "当前得分：" + score;
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        addScoreText.SetActive(true);
        addScoreText.GetComponent<Text>().text = "+" + addScore + "得分";
        Invoke("hideText", 0.5f);
        if (score > PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        SetText(score);
    }

    public void hideText()
    {
        addScoreText.SetActive(false);
    }

    public int getScore()
    {
        return score;
    }
}
