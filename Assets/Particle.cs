using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
    public Transform topLeft, topRight, botRight, botLeft;
    public Transform resetLeft, resetRight, resetTop, resetBot, middle;
    public string direction = "";
    private float speed = 6f;
    public float curveSpeed = 4f;
    Manager manager;
	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == "down")
        {
            if (transform.position.y >= topLeft.position.y)
            {
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            } else
            {
                direction = "";
            }
        }
        if (direction == "left")
        {
            if (transform.position.x >= topRight.position.x)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
            }
        }
        if (direction == "right")
        {
            if (transform.position.x <= topLeft.position.x)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
            }
        }
        if (direction == "up")
        {
            if (transform.position.y <= botLeft.position.y)
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
            }
        }
        if (direction == "curveLeft")
        {
            if (transform.position.x <= topLeft.transform.position.x)
            {
                direction = "resetLeft";
            } else
            {
                if (transform.position.y > middle.position.y)
                {
                    transform.RotateAround(topLeft.position, new Vector3(0, 0, -1), curveSpeed);
                } else
                {
                    transform.RotateAround(botLeft.position, new Vector3(0, 0, 1), curveSpeed);
                }
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0
                );
            }
        }
        if (direction == "curveRight")
        {
            if (transform.position.x >= topRight.transform.position.x)
            {
                direction = "resetRight";
            }
            else
            {
                if (transform.position.y > middle.position.y)
                {
                    transform.RotateAround(topRight.position, new Vector3(0, 0, 1), curveSpeed);
                } else
                {
                    transform.RotateAround(botRight.position, new Vector3(0, 0, -1), curveSpeed);
                }
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0
                );
            }
        }
        if (direction == "curveDown")
        {
            if (transform.position.y <= botLeft.transform.position.y)
            {
                direction = "resetDown";
            }
            else
            {
                if (transform.position.x > middle.position.x)
                {
                    transform.RotateAround(botRight.position, new Vector3(0, 0, 1), curveSpeed);
                } else
                {
                    transform.RotateAround(botLeft.position, new Vector3(0, 0, -1), curveSpeed);
                }
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0
                );
            }
        }

        if (direction == "curveUp")
        {
            if (transform.position.y >= topLeft.transform.position.y)
            {
                direction = "resetUp";
            }
            else
            {
                if (transform.position.x > middle.position.x)
                {
                    transform.RotateAround(topRight.position, new Vector3(0, 0, -1), curveSpeed);
                }
                else
                {
                    transform.RotateAround(topLeft.position, new Vector3(0, 0, 1), curveSpeed);
                }
                transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    transform.eulerAngles.y,
                    0
                );
            }
        }


        if (direction == "resetLeft")
        {
            if (transform.position.x >= resetLeft.position.x)
            {
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
                transform.position = resetRight.position;
                manager.NewField("left");
            }
        }
        if (direction == "resetUp")
        {
            if (transform.position.y <= resetTop.position.y)
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
                transform.position = resetBot.position;
                manager.NewField("up");
            }
        }
        if (direction == "resetRight")
        {
            if (transform.position.x <= resetRight.position.x)
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
                transform.position = resetLeft.position;
                manager.NewField("right");
            }
        }
        if (direction == "resetDown")
        {
            if (transform.position.y >= resetBot.position.x)
            {
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
            }
            else
            {
                direction = "";
                transform.position = resetTop.position;
                manager.NewField("down");
            }
        }
    }

    public void goDown ()
    {
        direction = "down";
    }

    public void goUp()
    {
        direction = "up";
    }

    public void goLeft()
    {
        direction = "left";
    }

    public void goRight()
    {
        direction = "right";
    }

    public void curveLeft ()
    {
        direction = "curveLeft";
    }

    public void curveRight ()
    {
        direction = "curveRight";
    }

    public void curveUp ()
    {
        direction = "curveUp";
    }

    public void curveDown()
    {
        direction = "curveDown";
    }
}
