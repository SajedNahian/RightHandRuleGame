using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public string[] fieldDirections = new string[2] { "out", "in" };
    public string direction;
    public int particleSign;
    public string fieldDirection;
    public GameObject field, particle;
    public Sprite outfield, infield, electron, proton;
    public string answer;
    Particle particleController;
	// Use this for initialization
	void Start () {
        direction = "down";
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


	// Update is called once per frame
	void Update () {
		
	}

    public void LeftButton ()
    {
        if (answer == "left")
        {
            particleController.curveLeft();
        }
    }

    public void RightButton()
    {
        if (answer == "right")
        {
            particleController.curveRight();
        }
    }

    public void UpButton()
    {
        if (answer == "up")
        {
            particleController.curveUp();
        }
    }

    public void DownButton()
    {
        if (answer == "down")
        {
            particleController.curveDown();
        }
    }

    public void NewField (string direction)
    {
        fieldDirection = fieldDirections[Random.Range(0, 2)];
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
}
