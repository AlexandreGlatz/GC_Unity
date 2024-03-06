using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public SeedElements SeedElements;
    public bool isSeed;
    public TMP_Text amountText;
    public Image thumbnail;
    public GameObject locker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSeed)
        {
            amountText.text = SeedElements.seedAmount.ToString();
        }

        else
        {
            amountText.text = SeedElements.fruitAmount.ToString();
        }

        if (!SeedElements.isLocked)
        {
            locker.SetActive(false) ;
        }
    }
}
