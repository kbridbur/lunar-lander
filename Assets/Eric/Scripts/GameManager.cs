using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int frame = 0;
    private bool simMode = false;
    public Cell outputCell;
    public GameObject activeBlock;
    public float altitude;
    public GameObject genericBlocks;
    public InputField gainConstant;
    public InputField baseConstant;
    public GainBlock genericGain;
    public BaseBlock genericBase;
	public Cell probeCell;
	float thrustOutput = 0;
	public GameObject Lander;
	public GameObject Ground;
	public float goalHeight = 7;
    public float startingHeight;
    public Button startSimButton;
    public Button stopSimButton; 

	// Use this for initialization
	void Start () {
		Physics2D.gravity = Vector2.zero;
	}

	public float GetThrust(){
		return Mathf.Clamp(thrustOutput, 0, 50000f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (simMode)
        {
			altitude = Lander.GetComponent<Thruster> ().GetHeight ();
            GameObject[] inputBlocks = GameObject.FindGameObjectsWithTag("Input");
            foreach (GameObject inputBlock in inputBlocks)
            {
                inputBlock.GetComponent<BaseBlock>().BaseVal = altitude;
            }
            if(outputCell != null)
            {
                float output = outputCell.evaluate();
                thrustOutput = output;
            }
            else
            {
                thrustOutput = 0;
            }
			frame++;
        }
    }

    public GameObject getActiveBlock()
    {
        ToggleGroup toggleGroup = this.gameObject.GetComponent<ToggleGroup>();
        Toggle activeToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (activeToggle != null)
        {
            GameObject activeToggleBlock = activeToggle.GetComponent<EmptyScript>().generic;
            return activeToggleBlock;
        }
        return null;
    }

    //public void seeActiveToggle()
    //{
    //    ToggleGroup toggleGroup = this.gameObject.GetComponent<ToggleGroup>();
    //    Toggle activeToggle = toggleGroup.ActiveToggles().FirstOrDefault();
    //    GameObject activeToggleBlock = activeToggle.GetComponentInChildren<EmptyScript>().gameObject;
    //    Debug.Log(activeToggleBlock);
    //}

    public void enterSimMode()
    {
        GameObject[] outputBlocks = GameObject.FindGameObjectsWithTag("Output");
        foreach(GameObject outputBlock in outputBlocks)
        {
            Cell cell = outputBlock.GetComponentInParent<Cell>();
            if ( cell != null)
            {
                outputCell = cell;
                break;
            }
        }
        simMode = true;
        startSimButton.interactable = false;
        stopSimButton.interactable = true;
		Physics2D.gravity = new Vector2 (0, -9.8f);
    }

    public void exitSimMode()
    {
		Lander.transform.position = new Vector3 (Lander.transform.position.x, startingHeight, 0);;
		Physics2D.gravity = Vector2.zero;
		thrustOutput = 0;
		Lander.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        simMode = false;
        startSimButton.interactable = true;
        stopSimButton.interactable = false;
        outputCell = null;
        frame = 0;
    }

    public void rotateGenericBlocks()
    {
        foreach(SpriteRenderer genericBlock in this.genericBlocks.GetComponentsInChildren<SpriteRenderer>())
        {
            GameObject objectGenericBlock = genericBlock.gameObject;
            objectGenericBlock.transform.Rotate(new Vector3(0, 0, -90));
            objectGenericBlock.GetComponent<IBlock>().RotateClockwise();
        }
    }

    public void setGainConstant()
    {
        float constant;
        if (float.TryParse(gainConstant.text, out constant))
        {
            genericGain.Gain = constant;
            genericGain.GainText.text = constant + "";
        }
        else
        {
            genericGain.Gain = 0;
        }
        
    }

    public void setBaseConstant()
    {
        float constant;
        if (float.TryParse(baseConstant.text, out constant))
        {
            genericBase.BaseVal = constant;
            genericBase.BaseText.text = constant + "";
        }
        else
        {
            genericBase.BaseVal = 0;
        }

    }

    public void SetProbeCell(Cell c){
		probeCell = c;
	}

	public Cell GetProbeCell(){
		return probeCell;
	}

}
