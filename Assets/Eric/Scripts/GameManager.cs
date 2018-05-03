using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int frame;
    private bool simMode = false;
    public Cell outputCell;
    public GameObject activeBlock;
    public float altitude;
    public GameObject genericBlocks;
    public InputField genericConstant;
    public GainBlock genericGain;
    public BaseBlock genericBase;
	float thrustOutput = 0;
	public GameObject Lander;
	public float goalHeight = 7;

	// Use this for initialization
	void Start () {
		Physics2D.gravity = Vector2.zero;
	}

	public float GetThrust(){
		return Mathf.Clamp(thrustOutput, 0, 50000f);
	}
	
	// Update is called once per frame
	void Update () {
        if (simMode)
        {
			altitude = goalHeight - Lander.GetComponent<Thruster> ().GetHeight ();
            GameObject[] inputBlocks = GameObject.FindGameObjectsWithTag("Input");
            foreach (GameObject inputBlock in inputBlocks)
            {
                inputBlock.GetComponent<BaseBlock>().BaseVal = altitude;
            }
            float output = outputCell.evaluate();
			thrustOutput = output;
			frame++;
			Debug.Log (output);
        }
    }

    void FixedUpdate ()
    {
        
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
		Physics2D.gravity = new Vector2 (0, -9.8f);
    }

    public void exitSimMode()
    {
		Lander.transform.position = new Vector3 (8.8f, 7, 0);;
		Physics2D.gravity = Vector2.zero;
		Lander.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        simMode = false;
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

    public void setGenericConstant()
    {
		Debug.Log (genericConstant.text);
        float constant;
        if (float.TryParse(genericConstant.text, out constant))
        {
            genericGain.Gain = constant;
            genericBase.BaseVal = constant;
        }
        else
        {
            genericGain.Gain = 0;
            genericBase.BaseVal = 0;
        }
        
    }


}
