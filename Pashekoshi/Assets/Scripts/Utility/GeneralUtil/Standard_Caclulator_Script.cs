using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Standard_Caclulator_Script : MonoBehaviour
{
    private TextMeshProUGUI Main_Display_Text;
    private TextMeshProUGUI Sub_Display_Text;
    private string main_display = "";
    private string sub_display = "";
    private string operation = null;

    void Start()
    {
        Main_Display_Text = GameObject.Find("Main_Display_Text").GetComponent<TextMeshProUGUI>(); // Gets the Main Display
        Sub_Display_Text = GameObject.Find("Sub_Display_Text").GetComponent<TextMeshProUGUI>(); // Gets the Sub-Display
        Clear(); // Ensures that the calculator is cleared before the user begins to use it
    }

    public void Clear()  // Resets Calculator Values
    {
        main_display = "0";
        sub_display = "";
        operation = null;
        Update_Display();
    }

    public void Append_Number(TextMeshProUGUI number_being_pressed)
    {
        if (number_being_pressed.text == "." && main_display.Contains(".")) return; // Makes sure that only one decimal point can be used
        if (main_display == "0") // Ensures that the initial 0 that is on the screen is wiped out before entering in new values
        {
            main_display = "";
            Update_Display();
        }
        main_display = main_display.ToString() + number_being_pressed.text; // Ensures that the numbers are added as strings not as actual integers
        Update_Display();
    }

    public void ChooseOperation(GameObject operation_being_pressed)
    {
        if (main_display == "") return; // If there is no value in the main display, do not do this function
        if (sub_display != "") Compute(); // If there is already a sellected operation compute that first and then insert the current operation
        operation = operation_being_pressed.tag; // The tag of the object tells me in a string what the operation is
        sub_display = main_display; // Puts the current number on the Main Display to the Sub Display
        main_display = ""; // Resets the main display in order to get ready for a new number to be inserted
        Update_Display();
    }

    public void Convert_Percentage()
    {
        main_display = (float.Parse(main_display) / 100).ToString();
        Update_Display();
    }

    public void Square_Root_Number()
    {
        main_display = (Math.Sqrt(float.Parse(main_display))).ToString();
        Update_Display();
    }

    public void Square_Number()
    {
        main_display = (Math.Pow(float.Parse(main_display), 2)).ToString();
        Update_Display();
    }

    public void Divide_By_One()
    {
        main_display = (1 / float.Parse(main_display)).ToString();
        Update_Display();
    }

    public void Negate()
    {
        main_display = (-float.Parse(main_display)).ToString();
        Update_Display();
    }

    public void Compute()
    {
        float result;
        float sub_display_num = float.Parse(sub_display); // Converts the sub display into a floating point number
        float main_display_num = float.Parse(main_display); // Converts the main display into a floating point number
        if (float.IsNaN(sub_display_num) || float.IsNaN(main_display_num)) return; // If one or both of them are not numbers then cancel the function

        switch (operation) // Completes the appropiate calculation and stores it into the, "result" variable
        {
            case "Division":
                result = sub_display_num / main_display_num;
                break;
            case "Multiplication":
                result = sub_display_num * main_display_num;
                break;

            case "Subtraction":
                result = sub_display_num - main_display_num;
                break;

            case "Addition":
                result = sub_display_num + main_display_num;
                break;

            default:
                return;
        }
        main_display = result.ToString(); // Puts the result into, "main_display" as a string
        operation = null; // Resets the operaton
        sub_display = ""; // Clears the sub display
        Update_Display();
    }

    public void Delete()
    {
        main_display = main_display.ToString().Substring(0, main_display.Length - 1); // Removes the last character of the main display
        Update_Display();
    }

    public void Update_Display() // Makes the calculator's actual display equal to the scripts display
    {
        Main_Display_Text.text = main_display;
        if (operation != null)
        {
            switch (operation) // Ensures that the correct math symbol appears in the sub display
            {
                case "Division":
                    Sub_Display_Text.text = sub_display.ToString() + "/";
                    break;

                case "Multiplication":
                    Sub_Display_Text.text = sub_display.ToString() + "*";
                    break;

                case "Subtraction":
                    Sub_Display_Text.text = sub_display.ToString() + "-";
                    break;

                case "Addition":
                    Sub_Display_Text.text = sub_display.ToString() + "+";
                    break;

                default:
                    return;
            }
            return;
        }
        Sub_Display_Text.text = ""; // Makes sure that the sub display for the previous calculation is removed
    }
}