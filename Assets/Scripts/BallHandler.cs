using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public Color Cyan, Yellow, Purple, Pink;
    string playerColor;
    public SpriteRenderer sr;
    int score = 0;
    public GameDriver gd;
    public Text scoreText;
    int lc = 0;
    public Text LifeCount;
    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
        if(SceneManager.GetActiveScene().name == "Scene3")
        {
            int rcolor = Random.Range(0, 2);
            if(rcolor==0)
            {
                sr.color = Yellow;
                playerColor = "Yellow";
            }
            else
            {
                sr.color = Pink;
                playerColor = "Pink";
            }
            
        }
        else
        {
            ChooseRandomColor();
        }
        
    }

    void ChooseRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                sr.color = Cyan;
                playerColor = "Cyan";
                break;
            case 1:
                sr.color = Yellow;
                playerColor = "Yellow";
                break;
            case 2:
                sr.color = Pink;
                playerColor = "Pink";
                break;
            case 3:
                sr.color = Purple;
                playerColor = "Purple";
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            if(SceneManager.GetActiveScene().name == "Scene3")
            {
                int rcolor = Random.Range(0, 2);
                if (rcolor == 0)
                {
                    sr.color = Yellow;
                    playerColor = "Yellow";
                }
                else
                {
                    sr.color = Pink;
                    playerColor = "Pink";
                }
            }
            else
            {
                ChooseRandomColor();
            }
           
            gd.Spawnner();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag == "Star")
        {
            score += 1;
            scoreText.text = ("Score: " + score.ToString());
            if (score >= 5 && SceneManager.GetActiveScene().name == "Scene1")
            {
                SceneManager.LoadScene("Scene2");
            }
            if (score>=5 && SceneManager.GetActiveScene().name=="Scene2")
            {
                SceneManager.LoadScene("Scene3");

            }
            else if(score >= 5 && SceneManager.GetActiveScene().name == "Scene3")
            {
                SceneManager.LoadScene("Scene4");
            }
            else if (score >= 5 && SceneManager.GetActiveScene().name == "Scene4")
            {
                SceneManager.LoadScene("Scene5");
            }

            Destroy(collision.gameObject);
            
            return;
        }
        if(collision.tag=="Life")
        {
            lc += 1;
            LifeCount.text = (" " + lc.ToString());
            //gd.Spawnner();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag=="Slider")
        {
            Push();
            return;
        }

        if (playerColor!=collision.tag)
        {
            if(lc>0)
            {
                lc--;
                LifeCount.text = (" " + lc.ToString());
                Destroy(collision.gameObject);
            }
            else
            {
                SceneManager.LoadScene("Scene1");
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = 2;
            Push();
        }
    }

    void Push()
    {
        rb.velocity = new Vector2(0, 1 * force);
    }
}
