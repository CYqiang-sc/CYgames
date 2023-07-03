using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishTri : MonoBehaviour
{
    public Button finishBtn;
    public GameObject finishCanvas;
    public Text finishText;
    // Start is called before the first frame update
    void Start()
    {
        finishBtn.onClick.AddListener(delegate { ClickFinish(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Character_Skier_01")
        {
            int score = GameObject.Find("ScoreText").GetComponent<PlayerScore>().getScore();
            finishText.text = "本次得分：" + score;
            finishCanvas.SetActive(true);
        }
    }

    public void ClickFinish()
    {
        SceneManager.LoadScene(0);
    }
}
