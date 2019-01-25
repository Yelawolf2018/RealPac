using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public Text ScoreText;
    public Text highScore;
    public GameObject ShieldPP;
    public TextMesh textMesh;
    public GameObject PP;
    public int score;
    public bool death;
    public bool giveShield;
    float delay;
    public static bool gameOver;
    void Start()
    {
        ScoreText.GetComponent<Text>();
        gameOver = false;
        delay = 5;
        ShieldPP.SetActive(false);
        score = Random.Range(5, 10);
        death = false;
        textMesh.GetComponent<TextMesh>();
        textMesh.text = score.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {

        if (giveShield)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                ShieldPP.SetActive(false);
                giveShield = false;
                delay = 5;
            }
        }
        if (death)
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
            }
            ScoreText.text = score.ToString();
            Instantiate(PP, transform.position, Quaternion.identity);
            gameOver = true;
            Destroy(gameObject);
            death = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Shield")
        {
            giveShield = true;
            ShieldPP.SetActive(true);
        }
        if (other.gameObject.tag == "Pac")
        {

            if (other.gameObject.GetComponent<Pacman>().score < score && !other.gameObject.GetComponent<Pacman>().giveShield)
            {
                other.gameObject.GetComponent<Pacman>().death = true;
                //other.gameObject.SetActive(false);
                score += 10;
                textMesh.text = score.ToString();
            }
            if (giveShield && !other.gameObject.GetComponent<Pacman>().giveShield)
            {
                other.gameObject.GetComponent<Pacman>().death = true;
                score += 10;
                textMesh.text = score.ToString();
            }
        }
        if (other.gameObject.tag == "Dots")
        {
            score++;
            textMesh.text = score.ToString();
        }
    }

}
