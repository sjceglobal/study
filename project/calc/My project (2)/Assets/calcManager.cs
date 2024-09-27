using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calcManager : MonoBehaviour
{
    public Text resultText;

    private string currentInput = "";
    private string operatorSymbol = "";
    private float firstOperand;
    private bool isOperatorSelected = false;

    public void OnNumberButtonClicked(string number)
    {
        if (isOperatorSelected)
        {
            currentInput = "";
            isOperatorSelected = false;
        }
        if (currentInput.Equals("") && number.Equals("0"))
        {
            currentInput = currentInput;
        }
        else
        {
            currentInput += number;
        }
        resultText.text = currentInput;
    }

    public void OnOperatorButtonClicked(string operatorSym)
    {
        if (float.TryParse(currentInput, out firstOperand))
        {
            operatorSymbol = operatorSym;
            isOperatorSelected = true;
        }
        else
        {
            Debug.LogError("Invalid input");
        }
    }

    public void OnEqualButtonClicked()
    {
        if (float.TryParse(currentInput, out float secondOperand))
        {
            float result = 0;
            switch (operatorSymbol)
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
                    if (secondOperand != 0)
                        result = firstOperand / secondOperand;
                    else
                        Debug.LogError("Cannot divide by zero");
                    break;
            }
            resultText.text = result.ToString();
            currentInput = result.ToString();
            operatorSymbol = "";
            isOperatorSelected = false;
        }
    }

    public void OnClearButtonClicked()
    {
        currentInput = "";
        operatorSymbol = "";
        resultText.text = "0";
        isOperatorSelected = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
