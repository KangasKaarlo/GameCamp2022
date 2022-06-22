using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UITextManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public PlayerStatus playerStatus;

    // Start is called before the first frame update
   
   
    void Start()
    {
        moneyText.text = "Money=" + playerStatus.money.ToString();
        healthText.text = "Health=" + playerStatus.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money=" + playerStatus.money.ToString();
        healthText.text = "Health=" + playerStatus.health.ToString();
    }
}
