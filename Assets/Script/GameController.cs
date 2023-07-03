using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject camera_1;
    public Button gameStart;
    public Button profile;
    public Button record;
    public Button quit;
    public Transform targetPoint;
    public GameObject canvas;
    public GameObject scoreCanvas;
    public GameObject profileCanvas;
    public GameObject maxCanvas;
    private bool isCameraMove = false;
    public AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        gameStart.onClick.AddListener(delegate { ClickGameStart(); });
        record.onClick.AddListener(delegate { ClickRecord(); });
        profile.onClick.AddListener(delegate { ClickProfile(); });
        quit.onClick.AddListener(delegate { ClickQuit(); });
    }

    // Update is called once per frame
    void Update()
    {
        if(isCameraMove)
        {
            camera_1.transform.position = Vector3.MoveTowards(camera_1.transform.position, targetPoint.position, 10 * Time.deltaTime);
            if(camera_1.transform.position == targetPoint.position)
            {
                isCameraMove = false;
                camera_1.GetComponent<Cinemachine.CinemachineBrain>().enabled = true;
                GameObject.Find("PlayerMove").GetComponent<ChaMove>().enabled = true;
            }
        }
    }

    private void ClickGameStart()
    {
        isCameraMove = true;
        canvas.SetActive(false);
        scoreCanvas.SetActive(true);
        music.Play();
    }

    private void ClickRecord()
    {
        canvas.SetActive(false);
        maxCanvas.gameObject.SetActive(true);
        GameObject.Find("MaxText").GetComponent<Text>().text = "最高分数：" + PlayerPrefs.GetInt("score");
    }

    private void ClickProfile()
    {
        canvas.SetActive(false);
        profileCanvas.SetActive(true);
    }

    private void ClickQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//编辑状态下退出
        #else
        Application.Quit();//打包编译后退出
        #endif

    }
}
