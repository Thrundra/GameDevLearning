using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    /// <summary>
    /// The Actual image that we are changing the fill of
    /// </summary>
    private Image content;

    /// <summary>
    /// HOld the current fill value, we will use this so that we know if we need to lerp a value.
    /// </summary>
    private float currentFill;

    /// <summary>
    /// The CurrentValue for example, health or mana.
    /// </summary>
    private float currentValue;

    /// <summary>
    /// The Lerp Speed.
    /// </summary>
    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private Text statValue;

    public float MyMaxValue { get; set; }
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if(value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if(value < 0)
            {
                value = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
            statValue.text = currentValue + "/" + MyMaxValue;
        }
    }
       
    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialise(float current, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = current;
    }
}
