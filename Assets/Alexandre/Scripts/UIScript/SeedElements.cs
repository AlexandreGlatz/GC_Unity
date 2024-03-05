using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class SeedElements : MonoBehaviour
{
    public TMP_Text value;
    public Image Graph;
    public Image locker;
    public Image thumbnail;
    public Sprite arrowSprite;
    public Sprite staySprite;

    public int intValue;
    public bool isLocked = true;
    public int seedAmount = 0;
    public int amountSold = 0;
    public bool canChange = true;

    private bool firstDown = true;
    private bool firstStay = true;
    private int changeNumber;
    private Sprite selectedSprite;
    private int wait;
    private float initScaleX = 0.09f;
    private int lowChance = 33;
    private int raiseChance = 66;
    private int stayChance = 100;

    // Start is called before the first frame update
    void Start()
    {
        intValue = int.Parse(value.text);
        StartCoroutine(ChangeTendency());
    }

    // Update is called once per frame
    void Update()
    {
        if (intValue <= 0)
        {
            intValue = 0;
        }
        
        value.text = intValue.ToString();
    }

    IEnumerator ChangeTendency()
    {
        changeNumber = Random.Range(0, 101);
        int amount = Random.Range(1, 11);
        Graph.transform.localScale = new Vector3(initScaleX, Graph.transform.localScale.y, Graph.transform.localScale.z);
        if (changeNumber < lowChance) //lowers value
        {
            changeNumber = -1;
            selectedSprite = arrowSprite;
            Graph.transform.eulerAngles = new Vector3(0,0,90); 
            Graph.color = Color.red;
            lowChance--;
            if (firstDown)
            {
                raiseChance -= 1;
            }
            firstDown = !firstDown;
        }
        else if (changeNumber > lowChance && changeNumber < raiseChance)//raises value
        {
            changeNumber = 1;
            selectedSprite = arrowSprite;
            Graph.transform.eulerAngles = new Vector3(0, 0, -90);
            Graph.color = Color.green;
            lowChance ++;
            raiseChance --;
        }
        else //keeps same value
        { 
            changeNumber = 0;
            selectedSprite = staySprite;
            Graph.transform.localScale = new Vector3(0.04f, Graph.transform.localScale.y, Graph.transform.localScale.z);
            Graph.color = Color.gray;
            if (firstStay)
            {
                raiseChance++;
            }
            else
            {
                lowChance++;
            }
            firstStay = !firstStay;
        }

        if (intValue < 10)
        {
            selectedSprite = arrowSprite;
            Graph.transform.eulerAngles = new Vector3(0, 0, -90);
            Graph.color = Color.green;
            changeNumber = 2;
        }
        else if (intValue > 1000)
        {
            selectedSprite = arrowSprite;
            Graph.transform.eulerAngles = new Vector3(0, 0, 90);
            Graph.color = Color.red;
            changeNumber = -2;
        }

        for (int i = 0; i < amount; i++) {
            intValue += changeNumber;
            Graph.sprite = selectedSprite;
            yield return new WaitForSeconds(3);
        }
        StartCoroutine(ChangeTendency());
    }

}
