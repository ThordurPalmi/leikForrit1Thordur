using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public RubyController rubyController; //Player game objectið
    public TextMeshProUGUI healthText; // texta objectið

    void Update()
    {
        healthText.text = "Health: " + rubyController.health.ToString(); //Breyti texta
    }
}
