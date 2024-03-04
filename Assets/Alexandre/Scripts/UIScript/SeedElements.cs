using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SeedElements : MonoBehaviour
{
    public TMP_Text value;
    public Image Graph;
    public Image locker;
    public Sprite arrowSprite;
    public Sprite staySprite;

    public int prevValue;
    public int intValue;
    public bool isLocked = true;
    public int seedAmount = 0;
    public int amountSold = 0;
    public bool canChange = true;

    private int changeNumber;
    private Sprite selectedSprite;

    // Start is called before the first frame update
    void Start()
    {
        intValue = int.Parse(value.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (intValue <= 0)
        {
            intValue = 0;
        }
        StartCoroutine(ChangeTendency());
        value.text = intValue.ToString();
    }

    IEnumerator ChangeTendency()
    {
        if(intValue > 10 && intValue<10000) 
        {
            changeNumber = Random.Range(-1, 1);
            if (changeNumber < 0)
            {
                selectedSprite = arrowSprite;
                Graph.transform.Rotate(0, 0, 90);
                Graph.color = Color.red;
            }
            else if (changeNumber > 0)
            {
                selectedSprite = arrowSprite;
                Graph.transform.Rotate(0, 0, -90);
                Graph.color = Color.green;
            }
            else
            {
                selectedSprite = staySprite;
                Graph.transform.Rotate(0, 0, 0);
                Graph.color = Color.gray;
            }
        }
        else if (intValue <10)
        {
            selectedSprite = arrowSprite;
            Graph.transform.Rotate(0, 0, -90);
            Graph.color = Color.green;
            StartCoroutine(BigStonks());
        }
        else if (intValue > 10000)
        {
            selectedSprite = arrowSprite;
            Graph.transform.Rotate(0, 0, 90);
            Graph.color = Color.red;
            StartCoroutine(BigBankruptcy());
        }
        
        int wait = 0;
        while (wait <= 10)
        {
            wait++;
            intValue += changeNumber;
            Graph.sprite = selectedSprite;
            yield return new WaitForSeconds(10);
        }
    }

    IEnumerator BigStonks()
    {
        int wait = 0;
        while (wait <= 10)
        {
            wait++;
            intValue += changeNumber;
            Graph.sprite = selectedSprite;
            yield return new WaitForSeconds(10);
        }
    }

    IEnumerator BigBankruptcy()
    {
        int wait = 0;
        while (wait <= 10)
        {
            wait++;
            intValue += changeNumber;
            Graph.sprite = selectedSprite;
            yield return new WaitForSeconds(10);
        }
    }

}
