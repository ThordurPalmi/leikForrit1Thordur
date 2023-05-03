using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    // Fall sem er kalla� �egar hlutur rekst � Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // S�kjum RubyController hlutinn �r hinum Collider2D hlutnum sem hluturinn er a� rekast �
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er til sta�ar...
        if (controller != null)
        {
            // ...kallar vi�komandi RubyController hlutur � ChangeHealth a�fer�ina me� -1 sem inntaki
            // sem svarar til �ess a� draga eitt l�f af RubyController hlutnum
            controller.ChangeHealth(-1);
        }
    }

    // Fall sem er kalla� �fram eins lengi sem hluturinn er � Collider2D
    void OnTriggerStay2D(Collider2D other)
    {
        // S�kjum RubyController hlutinn �r hinum Collider2D hlutnum sem hluturinn er a� rekast �
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er til sta�ar...
        if (controller != null)
        {
            // ...kallar vi�komandi RubyController hlutur � ChangeHealth a�fer�ina me� -1 sem inntaki
            // sem svarar til �ess a� draga eitt l�f af RubyController hlutnum
            controller.ChangeHealth(-1);
        }
    }
}
