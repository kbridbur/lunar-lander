﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public GameManager gameManager;
    public Cell up;
    public Cell down;
    public Cell left;
    public Cell right;
    public GameObject occupantObject;
    public IBlock occupant;
    public int frameLastEvaluated = -1;
    public float responseThisFrame;
    public float spriteScaleFactor;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        checkNeighborCells();
		frameLastEvaluated = -1;
    }
	
	// Update is called once per frame
	void Update () {
		if (this == gameManager.GetProbeCell ()) {
			transform.GetChild (0).GetComponent<SpriteRenderer> ().color = new Color (117, 249, 154, .4f);
		} else if (transform.childCount > 0){
			transform.GetChild (0).GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}

    void OnMouseDown ()
    {
        if (gameManager.getActiveBlock() != null)
        {
			if (gameManager.getActiveBlock ().name == "Probe") {
                if(occupantObject != null)
                {
                    gameManager.SetProbeCell(this);
                }
                return;
            }
            if(occupantObject != null)
            {
                Destroy(occupantObject);
                occupantObject = null;
                if (this == gameManager.probeCell)
                {
                    gameManager.probeCell = null;
                }
            }
            occupantObject = Instantiate(gameManager.getActiveBlock(), this.transform);
			occupant = occupantObject.GetComponent<IBlock> ();
            occupantObject.transform.localPosition = Vector3.zero;
            occupantObject.transform.localScale = new Vector3(spriteScaleFactor, spriteScaleFactor, 1);
        }
        else
        {
            if (occupantObject != null)
            {
                Destroy(occupantObject);
                occupantObject = null;
                if (this == gameManager.probeCell)
                {
                    gameManager.probeCell = null;
                }
            }
        }
    }

    public float evaluate()
    {
		if (gameManager.frame < frameLastEvaluated) {
			frameLastEvaluated = gameManager.frame - 1;
		}
		frameLastEvaluated = gameManager.frame;
        if (occupantObject != null)
        {
            occupant = occupantObject.GetComponent<IBlock>();
        }
        List<string> inputDirections = this.occupant.GetInputDirections();
        List<float> inputValues = new List<float>();
        foreach (string inputDirection in inputDirections)
        {
            float inputVal = 0;
            if (getCellAt(inputDirection) != null && getCellAt(inputDirection).occupantObject != null && getCellAt(inputDirection).occupant.GetOutputDirections().Contains(oppositeDirection(inputDirection)))
            {
                if (occupantObject.GetComponent<DelayBlock>() != null)
                {
                    inputVal = getCellAt(inputDirection).occupant.GetFrameOutput(gameManager.frame - 1);
                    if (getCellAt(inputDirection).frameLastEvaluated < gameManager.frame)
                    {
                        getCellAt(inputDirection).evaluate();
                    }
                }
                else {
                    inputVal = getCellAt(inputDirection).evaluate();
                }
            }
            inputValues.Add(inputVal);
        }
        responseThisFrame = occupant.Evaluate(gameManager.frame, inputValues);
        return responseThisFrame;
    }

    string oppositeDirection(string direction)
    {
        if (direction.Equals("up"))
        {
            return "down";
        }
        else if (direction.Equals("down"))
        {
            return "up";
        }
        else if (direction.Equals("left"))
        {
            return "right";
        }
        else {
            return "left";
        }
    }

    private Cell getCellAt(string direction)
    {
        if (direction.Equals("up"))
        {
            return this.up;
        }
        else if (direction.Equals("down"))
        {
            return this.down;
        }
        else if (direction.Equals("left"))
        {
            return this.left;
        }
        else{
            return this.right;
        }
    }

    private void checkNeighborCells()
    {
        RaycastHit hitLeft;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitLeft, 1f))
        {
            this.left = hitLeft.transform.gameObject.GetComponent<Cell>();
        }

        RaycastHit hitRight;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitRight, 1f))
        {
            this.right = hitRight.transform.gameObject.GetComponent<Cell>();
        }

        RaycastHit hitUp;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hitUp, 1f))
        {
            this.up = hitUp.transform.gameObject.GetComponent<Cell>();
        }

        RaycastHit hitDown;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hitDown, 1f))
        {
            this.down = hitDown.transform.gameObject.GetComponent<Cell>();
        }

    }
}
