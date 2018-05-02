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

	// Use this for initialization
	void Start () {
		
	}

	public float GetThrust(){
		return thrustOutput;
	}
	
	// Update is called once per frame
	void Update () {
        if (simMode)
        {
            frame++;
            GameObject[] inputBlocks = GameObject.FindGameObjectsWithTag("Input");
            foreach (GameObject inputBlock in inputBlocks)
            {
                inputBlock.GetComponent<BaseBlock>().BaseVal = altitude;
            }
            float output = outputCell.evaluate();
            Debug.Log(output);
			thrustOutput = output;
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
    }

    public void exitSimMode()
    {
        simMode = false;
        outputCell = null;
        frame = 0;
    }

    public void rotateGenericBlocks()
    {
        foreach(SpriteRenderer genericBlock in this.genericBlocks.GetComponentsInChildren<SpriteRenderer>())
        {
            GameObject objectGenericBlock = genericBlock.gameObject;
            objectGenericBlock.transform.Rotate(new Vector3(0, 0, 90));
            objectGenericBlock.GetComponent<IBlock>().RotateClockwise();
        }
    }

    public void setGenericConstant()
    {
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
