using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentlySystem : MonoBehaviour
{
    public TMP_Text currencyText;
    public int defaultCurrency;
    public int currency;

    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    public void Gain(int val)
    {
        currency+= val;
        UpdateUI();
    }

    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    bool EnoughCurrency(int val)
    {
        if (val <= currency)
            return true;
        else
            return false;
    }

    public void UpdateUI()
    {
        currencyText.text = currency.ToString();
    }

    public void USE_TEST()
    {
        Debug.Log(Use(3));
    }
}
