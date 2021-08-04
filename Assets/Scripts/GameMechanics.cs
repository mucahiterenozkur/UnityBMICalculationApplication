using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMechanics : MonoBehaviour
{
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI heightText;
    public TMP_Dropdown units;

    public TMP_InputField weightValue;
    public TMP_InputField heightValue;

    public TextMeshProUGUI resultText;
    public TextMeshProUGUI situationText;

    double bmiValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ArrangeUnits();
    }

    public void ArrangeUnits()
    {
        if (units.value == 0)
        {
            weightText.text = "KG";
            heightText.text = "M";
        }

        if (units.value == 1)
        {
            weightText.text = "LBS";
            heightText.text = "IN";
        }
    }

    public void CalculateBMI()
    {
        string heightString = heightValue.text.ToString();
        double heightNumber = double.Parse(heightString);

        heightNumber = (heightNumber * heightNumber);

        if (units.value == 0)
        {
            string weightString = weightValue.text.ToString();
            double weighttt = double.Parse(weightString);
            bmiValue = weighttt / heightNumber;
            resultText.text = bmiValue.ToString("F2"); //for 2 decimal places after coma.
            WriteTheSituationAboutBMI(bmiValue);
        }

        if (units.value == 1)
        {
            string weightString = weightValue.text.ToString();
            double weighttt = double.Parse(weightString);
            bmiValue = (703 * weighttt) / heightNumber;
            resultText.text = bmiValue.ToString("F2"); //for 2 decimal places after coma.
            WriteTheSituationAboutBMI(bmiValue);
        }

    }

    public void WriteTheSituationAboutBMI(double bmiValue)
    {
        if (bmiValue < 15)
        {
            situationText.text = "Very severely underweight";
            situationText.color = Color.yellow;
        }
        else if (bmiValue >= 15 && bmiValue <= 18.5)
        {
            situationText.text = "Underweight";
            situationText.color = Color.yellow;
        }
        else if (bmiValue > 18.5 && bmiValue <= 25)
        {
            situationText.text = "Normal (healthy weight)";
            situationText.color = Color.green;
        }
        else if (bmiValue > 25 && bmiValue <= 30)
        {
            situationText.text = "Overweight";
            situationText.color = Color.yellow;
        }
        else if (bmiValue > 30 && bmiValue <= 35)
        {
            situationText.text = "Moderately obese";
            situationText.color = Color.red;
        }
        else if (bmiValue > 35 && bmiValue <= 40)
        {
            situationText.text = "Severely obese";
            situationText.color = Color.yellow;
        }
        else if (bmiValue > 40)
        {
            situationText.text = "Very severely obese";
            situationText.color = Color.yellow;
        }
    }

}
