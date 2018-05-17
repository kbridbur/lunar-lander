using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour {

    public GameManager gameManager;

    public Toggle AltitudeToggle;
    public Toggle ValueToggle;
    public Toggle GainToggle;
    public Toggle AddToggle;
    public Toggle DelayToggle;
    public Toggle ThrustToggle;

    public List<Toggle> LevelToggles;

    public GameObject lander;
    public GameObject goalLine;
    public Text goalLineText;

    public GameObject grid;
    public Text goalText;

    public InputField gainText;
    public InputField baseText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnOffLevelSelect()
    {
        foreach(Toggle toggle in LevelToggles)
        {
            toggle.interactable = false;
        }
    }

    public void turnOnLevelSelect()
    {
        foreach (Toggle toggle in LevelToggles)
        {
            toggle.interactable = true;
        }
    }

    public void setLevelStart()
    {
        clearGrid();
        ToggleGroup toggleGroup = this.gameObject.GetComponent<ToggleGroup>();
        Toggle activeToggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if (activeToggle != null)
        {
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("1"))
            {
                goalText.text = "Goal: Get your rocket above a height of 80";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 6, goalLine.transform.localPosition.z);
                goalLineText.text = "80";
                AltitudeToggle.interactable = false;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = false;
                AddToggle.interactable = false;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("2"))
            {
                goalText.text = "Goal: Get your rocket above a height of 80 as slowly as possible";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 6, goalLine.transform.localPosition.z);
                goalLineText.text = "80";
                AltitudeToggle.interactable = false;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = false;
                AddToggle.interactable = false;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("3"))
            {
                goalText.text = "Goal: Get your rocket above a height of 80 as slowly as possible";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 6, goalLine.transform.localPosition.z);
                goalLineText.text = "80";
                AltitudeToggle.interactable = false;
                ValueToggle.interactable = true;
                baseText.text = "100";
                baseText.interactable = false;
                GainToggle.interactable = true;
                AddToggle.interactable = false;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("4"))
            {
                goalText.text = "Goal: Maintain an altitude of 70 for as long as possible";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, 5.4f, lander.transform.localPosition.z);
                gameManager.startingHeight = 5.4f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 5, goalLine.transform.localPosition.z);
                goalLineText.text = "70";
                AltitudeToggle.interactable = false;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = false;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("5"))
            {
                goalText.text = "Goal: Maintain an altitude of 70 for as long as possible";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, 5.4f, lander.transform.localPosition.z);
                gameManager.startingHeight = 5.4f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 5, goalLine.transform.localPosition.z);
                goalLineText.text = "70";
                AltitudeToggle.interactable = false;
                ValueToggle.interactable = true;
                baseText.text = "4.9";
                baseText.interactable = false;
                GainToggle.interactable = false;
                AddToggle.interactable = true;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("6"))
            {
                goalText.text = "Goal: Land the rocket on the ground as softly as possible";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, 6.4f, lander.transform.localPosition.z);
                gameManager.startingHeight = 6.4f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 6, goalLine.transform.localPosition.z);
                goalLineText.text = "80";
                AltitudeToggle.interactable = true;
                ValueToggle.interactable = false;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = false;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("7"))
            {
                goalText.text = "Goal: Take off and oscillate as closely as possible to a height of 70";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 5, goalLine.transform.localPosition.z);
                goalLineText.text = "70";
                AltitudeToggle.interactable = true;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = true;
                DelayToggle.interactable = false;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("8"))
            {
                goalText.text = "Goal: Take off and hover at any height";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 10, goalLine.transform.localPosition.z);
                goalLineText.text = "120";
                AltitudeToggle.interactable = true;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = true;
                DelayToggle.interactable = true;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("9"))
            {
                goalText.text = "Goal: Take off and hover at a height of 70";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, -1.6f, lander.transform.localPosition.z);
                gameManager.startingHeight = -1.6f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 5, goalLine.transform.localPosition.z);
                goalLineText.text = "70";
                AltitudeToggle.interactable = true;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = true;
                DelayToggle.interactable = true;
                ThrustToggle.interactable = true;
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("10"))
            {
                goalText.text = "Goal: Land the rocket VERY softly on the ground";
                lander.transform.localPosition = new Vector3(lander.transform.localPosition.x, 6.4f, lander.transform.localPosition.z);
                gameManager.startingHeight = 6.4f;
                goalLine.transform.localPosition = new Vector3(goalLine.transform.localPosition.x, 6, goalLine.transform.localPosition.z);
                goalLineText.text = "80";
                AltitudeToggle.interactable = true;
                ValueToggle.interactable = true;
                baseText.text = "0";
                baseText.interactable = true;
                GainToggle.interactable = true;
                AddToggle.interactable = true;
                DelayToggle.interactable = true;
                ThrustToggle.interactable = true;
            }
        }
    }

    public void clearGrid()
    {
        foreach(Transform sixbysix in grid.transform){
            foreach(Transform threebythree in sixbysix){
                foreach(Transform gridCell in threebythree){
                    Cell cellScript = gridCell.GetComponent<Cell>();
                    if (cellScript.occupantObject != null)
                    {
                        Destroy(cellScript.occupantObject);
                        cellScript.occupantObject = null;
                        if (gridCell.gameObject == gameManager.probeCell)
                        {
                            gameManager.probeCell = null;
                        }
                    }
                    
                }
            }
        }
    }
}
