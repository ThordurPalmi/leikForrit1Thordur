using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public RubyController rubyController; //Player game objecti�
    public TextMeshProUGUI healthText; // texta objecti�

    void Update()
    {
        healthText.text = "Health: " + rubyController.health.ToString(); //Breyti texta
    }
}
