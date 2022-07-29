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

    public int normalTowerPrice;
    public int fastTowerPrice;
    public int bruteTowerPrice;
    bool towerIsPlaced = false;
    public GameObject mainCamera;
    Transform closest;
    
    public bool canPlaceTowers;
    public PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        canPlaceTowers = true;
        mainCamera = GameObject.Find("PixelCamera");

        //Finds UI buttons and adds onclick functions to them
        normalTowerButton = GameObject.Find("NormalTowerButton").GetComponent<Button>();
        normalTowerButton.onClick.AddListener(selectNormalTower);

        fastTowerButton = GameObject.Find("FastTowerButton").GetComponent<Button>();
        fastTowerButton.onClick.AddListener(selectFastTower);

        pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        

        

    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.isPaused)
        {
            canPlaceTowers = false;

        }else {
            canPlaceTowers = true;
            }

    }

    private void OnMouseDown()
    {
        if (canPlaceTowers)
        {
           if(!towerIsPlaced)
        {
            if (activeButton == "NormalTowerButton" && mainCamera.GetComponent<PlayerStatus>().money >= normalTowerPrice)
            {
                Instantiate(towerNormal, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.LookRotation(Vector3.left));
                towerIsPlaced = true;
                mainCamera.GetComponent<PlayerStatus>().money -= normalTowerPrice;
            } else if (activeButton == "FastTowerButton" && mainCamera.GetComponent<PlayerStatus>().money >= fastTowerPrice)
            {
                Instantiate(towerFast, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.LookRotation(Vector3.left));
                towerIsPlaced = true;
                mainCamera.GetComponent<PlayerStatus>().money -= fastTowerPrice;
            }
            else if (activeButton == "BruteTowerButton")
            {
                Instantiate(towerBrute, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.LookRotation(Vector3.left));
                towerIsPlaced = true;
            }
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
