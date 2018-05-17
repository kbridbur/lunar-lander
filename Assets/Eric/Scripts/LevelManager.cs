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

    public GameObject goalLine;
    public Text goalLineText;

    public GameObject grid;

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
                
            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("2"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("3"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("4"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("5"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("6"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("7"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("8"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("9"))
            {

            }
            if (activeToggle.gameObject.GetComponentInChildren<Text>().text.Equals("10"))
            {

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
