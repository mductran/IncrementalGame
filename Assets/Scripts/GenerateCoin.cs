using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GenerateCoin : MonoBehaviour
{
    public Text coinCountText;
    public Text coinPerSecondText;
    public Text clickLevelText;
    public Text incrementLevelText;

    public Text upgradeClickText;
    public Text upgradeIncrementText;

    int coinCount;
    int coinPerSecond;

    int clickLevel;
    int upgradeClickCost;

    int incrementLevel;
    int upgradeIncrementCost;

    int clickIncrease;

    float nextUpdateTime = 0.0f;
    float updatePeriod = 1.0f;


    // Start is called before the first frame update
    public void Start()
    {
        coinCount = 0;
        coinPerSecond = 1;
        clickLevel = 1;
        incrementLevel = 1;
        clickIncrease = 1;

        upgradeClickCost = 50;
        upgradeClickText.text = string.Format("Upgrade click\nCost: {0}", upgradeClickCost);
        upgradeIncrementCost = 100;
        upgradeIncrementText.text = string.Format("Upgrade increment\nCost: {0}", upgradeIncrementCost);
    }

    // Update is called once per frame
    public void Update()
    {
        if (Time.time > nextUpdateTime)
        {
            nextUpdateTime += updatePeriod;
            coinCount += coinPerSecond;
        }
        
        coinCountText.text = string.Format("Coin count: {0}", coinCount);
        coinPerSecondText.text = string.Format("Coin Gained Per Second: {0}", coinPerSecond);
        clickLevelText.text = string.Format("Click Level: {0}", clickLevel);
        incrementLevelText.text = string.Format("Increment Level: {0}", incrementLevel);
    }

    public void Click() {
        coinCount += clickIncrease;
        Debug.Log("current coin count: " + coinCount);
    }

    public void UpgradeClick() {
        if (coinCount >= upgradeClickCost)
        {
            clickLevel++;
            clickIncrease *= 2;
            clickLevelText.text = "Click level: " + clickLevel;
            coinCount -= upgradeClickCost;
            upgradeClickCost = upgradeClickCost * 2;
            upgradeClickText.text = string.Format("Upgrade click\nCost: {0}", upgradeClickCost);
        }
    }

    public void UpgradeIncrement()
    {
        if (coinCount >= upgradeIncrementCost)
        {
            incrementLevel++;
            coinPerSecond += 10;
            incrementLevelText.text = "Increment level: " + incrementLevel;
            coinCount -= upgradeIncrementCost;
            upgradeIncrementCost = upgradeIncrementCost * 3;
            upgradeIncrementText.text = string.Format("Upgrade increment\nCost: {0}", upgradeIncrementCost);
        }
    }
}
