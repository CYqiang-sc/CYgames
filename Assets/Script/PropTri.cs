using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character_Skier_01")
        {
            GameObject.Find("ScoreText").GetComponent<PlayerScore>().AddScore(20);
            Destroy(gameObject);
        }
    }
}
