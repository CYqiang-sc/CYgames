using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public GameObject canvas;
    public GameObject[] sex;
    public GameObject[] head;
    public Button man;
    public Button woman;
    public Button close;
    public Button head1;
    public Button head2;
    public Button head3;
    public Button head4;

    // Start is called before the first frame update
    void Start()
    {
        woman.onClick.AddListener(delegate { ClickSex(0); });
        man.onClick.AddListener(delegate { ClickSex(1); });
        close.onClick.AddListener(delegate { ClickClose(); });
        head1.onClick.AddListener(delegate { ClickHead(0); });
        head2.onClick.AddListener(delegate { ClickHead(1); });
        head3.onClick.AddListener(delegate { ClickHead(2); });
        head4.onClick.AddListener(delegate { ClickHead(3); });
    }

    // Update is called once per frame
    public void ClickSex(int i)
    {
        sex[i].SetActive(true);
        for(int j = 0; j < sex.Length; j++)
        {
            if(j != i)
            {
                sex[j].SetActive(false);
            }
        }
    }

    public void ClickClose()
    {
        this.gameObject.SetActive(false);
        canvas.SetActive(true);
    }

    public void ClickHead(int i)
    {
        head[i].SetActive(true);
        for (int j = 0; j < head.Length; j++)
        {
            if (j != i)
            {
                head[j].SetActive(false);
            }
        }
    }
}
