using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public Button close;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        close.onClick.AddListener(delegate { ClickClose(); });
    }

    // Update is called once per frame
    public void ClickClose()
    {
        this.gameObject.SetActive(false);
        canvas.SetActive(true);
    }
}
