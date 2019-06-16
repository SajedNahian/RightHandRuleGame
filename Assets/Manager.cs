using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
    public string[] fieldDirections = new string[2] { "out", "in" };
    public string direction;
    public int particleSign;
    public string fieldDirection;
    public GameObject field, particle;
    public Sprite outfield, infield, electron, proton;
    private AudioSource sound;
    public AudioClip[] music;
    public AudioClip[] correct;
    public AudioClip[] incorrect;
    public GameObject gameOverPanel;
    public AudioClip gameOver;
    public Text gameOverText;
    private int score = 0;
    public string answer;
    private int currentAudio = 0;
    Particle particleController;
    private int lives = 3;
    private float timePerQ = 8f;
    public Text timeText;
    private float whenToSubractLife;
    private Text scoreText;
	// Use this for initialization
	void Start () {
        direction = "down";
        gameOverPanel.SetActive(false);
        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(music[Random.Range(0, music.Length)]);
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        fieldDirection = fieldDirections[Random.Range(0, 2)];
        if (Random.Range(0, 2) == 0)
        {
            particleSign = 1;
        }  else
        {
            particleSign = -1;
        }
        setupGame();
        particleController = particle.GetComponent<Particle>();
        particleController.goDown();
        answer = calculateCorrectAnswer(direction, fieldDirection, particleSign);
        print("Answer: " + answer);
    }

    void setupGame() {
        if (fieldDirection == "out")
        {
            field.GetComponent<SpriteRenderer>().sprite = outfield;
        } else
        {
            field.GetComponent<SpriteRenderer>().sprite = infield;
        }

        if (particleSign > 0)
        {
            particle.GetComponent<SpriteRenderer>().sprite = proton;
        }
        else
        {
            particle.GetComponent<SpriteRenderer>().sprite = electron;
        }
    }

    string calculateCorrectAnswer(string direction, string field, int charge)
    {
        string answer = "";
        if (charge > 0)
        {
            if (field == "in")
            {
                switch (direction)
                {
                    case "down":
                        answer = "right";
                        break;
                    case "up":
                        answer = "left";
                        break;
                    case "left":
                        answer = "down";
                        break;
                    default:
                        answer = "up";
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case "down":
                        answer = "left";
                        break;
                    case "up":
                        answer = "right";
                        break;
                    case "left":
                        answer = "up";
                        break;
                    default:
                        answer = "down";
                        break;
                }
            }
        }
        else
        {
            if (field == "in")
            {
                switch (direction)
                {
                    case "down":
                        answer = "left";
                        break;
                    case "up":
                        answer = "right";
                        break;
                    case "left":
                        answer = "up";
                        break;
                    default:
                        answer = "down";
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case "down":
                        answer = "right";
                        break;
                    case "up":
                        answer = "left";
                        break;
                    case "left":
                        answer = "down";
                        break;
                    default:
                        answer = "up";
                        break;
                }
            }
        }
        return answer;
    }

    private void Awake()
    {
        whenToSubractLife = Time.time + 10f;   
    }

    // Update is called once per frame
    void Update () {
        if (lives > 0)
        {
            if (whenToSubractLife > Time.time)
            {
                timeText.text = (whenToSubractLife - Time.time).ToString();
            } else
            {
                PlayWrongSoundEffect();
                LoseLife();
                whenToSubractLife = Time.time + timePerQ;
            }
        }
    }

    void PlayCorrectSoundEffect ()
    {
        score++;
        sound.PlayOneShot(correct[currentAudio % correct.Length]);;
        scoreText.text = "Score: " + score;
        currentAudio++;
    }

    void PlayWrongSoundEffect ()
    {
        sound.PlayOneShot(incorrect[currentAudio % incorrect.Length]);
        currentAudio++;
    }

    public void LeftButton ()
    {
        if (answer == "left")
        {
            particleController.curveLeft();
            PlayCorrectSoundEffect();
            whenToSubractLife = whenToSubractLife + timePerQ;
            if (timePerQ > 1.5f)
            {
                timePerQ -= .5f;
            }
        } else
        {
            PlayWrongSoundEffect();
            LoseLife();
        }
    }

    public void RightButton()
    {
        if (answer == "right")
        {
            particleController.curveRight();
            PlayCorrectSoundEffect();
            whenToSubractLife = whenToSubractLife + timePerQ;
            if (timePerQ > 1.5f)
            {
                timePerQ -= .5f;
            }
        } else
        {
            PlayWrongSoundEffect();
            LoseLife();
        }
    }

    public void UpButton()
    {
        if (answer == "up")
        {
            particleController.curveUp();
            PlayCorrectSoundEffect();
            whenToSubractLife = whenToSubractLife + timePerQ;
            if (timePerQ > 1.5f)
            {
                timePerQ -= .5f;
            }
        } else
        {
            PlayWrongSoundEffect();
            LoseLife();
        }
    }

    public void DownButton()
    {
        if (answer == "down")
        {
            particleController.curveDown();
            PlayCorrectSoundEffect();
            whenToSubractLife = whenToSubractLife + timePerQ;
            if (timePerQ > 1.5f)
            {
                timePerQ -= .5f;
            }
        } else
        {
            PlayWrongSoundEffect();
            LoseLife();
        }
    }

    private void LoseLife ()
    {
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
        int index = 0;
        for (int i = index + 1; i < hearts.Length; i++)
        {
            if (hearts[i].transform.position.x > hearts[index].transform.position.x)
            {
                index = i;
            }
        }
        hearts[index].SetActive(false);
        lives--;
        if (lives == 0)
        {
            sound.Stop();
            sound.PlayOneShot(gameOver);
            gameOverPanel.SetActive(true);
            gameOverText.text = "Score: " + score;
        }
    }

    public void NewField (string direction)
    {
        fieldDirection = fieldDirections[Random.Range(0, 2)];
        if (Random.Range(0, 2) == 0)
        {
            particleSign = 1;
        }
        else
        {
            particleSign = -1;
        }
        if (particleSign > 0)
        {
            particle.GetComponent<SpriteRenderer>().sprite = proton;
        }
        else
        {
            particle.GetComponent<SpriteRenderer>().sprite = electron;
        }
        if (fieldDirection == "out")
        {
            field.GetComponent<SpriteRenderer>().sprite = outfield;
        }
        else
        {
            field.GetComponent<SpriteRenderer>().sprite = infield;
        }
        answer = calculateCorrectAnswer(direction, fieldDirection, particleSign);
        print("Answer: " + answer);

        if (direction == "left")
        {
            particleController.goLeft();
        }
        if (direction == "right")
        {
            particleController.goRight();
        }
        if (direction == "up")
        {
            particleController.goUp();
        }
        if (direction == "down")
        {
            particleController.goDown();
        }
    }

    public void RestartLevel ()
    {
        SceneManager.LoadScene("Game");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
