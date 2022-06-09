using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerNormal;
    public GameObject towerFast;
    public GameObject towerBrute;
    string activeButton = "NormalTowerButton";
    public Button normalTowerButton;
    public Button fastTowerButton;
    public Button bruteTowerButton;
    bool towerIsPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        //Finds UI buttons and adds onclick functions to them
        normalTowerButton = GameObject.Find("NormalTowerButton").GetComponent<Button>();
        normalTowerButton.onClick.AddListener(selectNormalTower);

        fastTowerButton = GameObject.Find("FastTowerButton").GetComponent<Button>();
        fastTowerButton.onClick.AddListener(selectFastTower);

        bruteTowerButton = GameObject.Find("BruteTowerButton").GetComponent<Button>();
        bruteTowerButton.onClick.AddListener(selectBruteTower);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(!towerIsPlaced)
        {
            if(activeButton == "NormalTowerButton")
            {
                Instantiate(towerNormal, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                towerIsPlaced = true;
            } else if (activeButton == "FastTowerButton")
            {
                Instantiate(towerFast, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                towerIsPlaced = true;
            }
            else if (activeButton == "BruteTowerButton")
            {
                Instantiate(towerBrute, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                towerIsPlaced = true;
            }
        }
    }
    public void selectNormalTower()
    {
        activeButton = "NormalTowerButton";
    }
    public void selectFastTower()
    {
        activeButton = "FastTowerButton";
    }
    public void selectBruteTower()
    {
        activeButton = "BruteTowerButton";
    }
}
