using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellShop : MonoBehaviour
{
    public int money;
    public List<SeedElements> aniseeds;
    public GameObject unlockText;
    public GameObject enoughText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellSeed(SeedElements seed)
    {
        if (seed.seedAmount >= 1 && !seed.isLocked)
        {
            money += seed.intValue;
            seed.seedAmount -= 1;
            seed.amountSold += 1;

            if (seed.amountSold >=2) 
            {
                seed.intValue -= 1;
                seed.amountSold =0;
            }
        }

        else if (seed.isLocked)
        {
            StartCoroutine(ShowLockText());
        }

        else if(seed.seedAmount <= 0)
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
}
