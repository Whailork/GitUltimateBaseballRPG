using System.Collections;
using System.Collections.Generic;
using Singletons;
using TMPro;
using UnityEngine;

public class CashDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCashText();
    }

    private void UpdateCashText()
    {
        

        GetComponent<TextMeshProUGUI>().text = $"Cash : {GameManager.GetGameManager().GetSubsystem<DataSubsystem>().money}$";

    }
}
