using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellShop : MonoBehaviour
{
    public int money;
    public GameObject unlockText;
    public GameObject enoughText;
    public TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (money<= 9999999)
        {
            moneyText.text = money.ToString();
        }
    }

    public void SellSeed(SeedElements seed)
    {
        if (seed.fruitAmount >= 1 && !seed.isLocked)
        {
            seed.locker.SetActive(false);
            money += seed.intValue;
            seed.fruitAmount -= 1;
            seed.amountSold += 1;

            if (seed.amountSold >=2) 
            {
                seed.lowChance--;
                if (seed.firstDown)
                {
                    seed.raiseChance -= 1;
                }
                seed.firstDown = !seed.firstDown;
                seed.intValue -= 1;
                seed.amountSold =0;
            }
        }

        else if (seed.isLocked)
        {
            StartCoroutine(ShowLockText());
        }

        else if(seed.fruitAmount <= 0)
        {
            StartCoroutine(ShowEnoughText());
        }

    }

    private IEnumerator ShowLockText()
    {
        unlockText.SetActive(true);
        yield return new WaitForSeconds(3);
        unlockText.SetActive(false);
    }

    private IEnumerator ShowEnoughText()
    {
        enoughText.SetActive(true);
        yield return new WaitForSeconds(3);
        enoughText.SetActive(false);
    }

    public void increaseMoney(int amount)
    {
        money += amount;
    }
}
