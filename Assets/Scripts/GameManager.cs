using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject target;
    public GameObject winimage;

    int score = 0;
    public Text scoreText;

    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true)
        {
            CancelInvoke("Spawn");
        }

        if(Input.GetMouseButtonDown(0)){
            GetComponent<AudioSource>().Play();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(-3.7f, 3.7f);

        Vector3 randomPostion = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPostion, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= 10)
        {
            win = true;
            winimage.SetActive(true);
        }
    }
}
