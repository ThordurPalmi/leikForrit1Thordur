using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    // Fall sem er kallað þegar hlutur rekst á Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Sækjum RubyController hlutinn úr hinum Collider2D hlutnum sem hluturinn er að rekast á
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er til staðar...
        if (controller != null)
        {
            // ...kallar viðkomandi RubyController hlutur á ChangeHealth aðferðina með -1 sem inntaki
            // sem svarar til þess að draga eitt líf af RubyController hlutnum
            controller.ChangeHealth(-1);
        }
    }

    // Fall sem er kallað áfram eins lengi sem hluturinn er á Collider2D
    void OnTriggerStay2D(Collider2D other)
    {
        // Sækjum RubyController hlutinn úr hinum Collider2D hlutnum sem hluturinn er að rekast á
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er til staðar...
        if (controller != null)
        {
            // ...kallar viðkomandi RubyController hlutur á ChangeHealth aðferðina með -1 sem inntaki
            // sem svarar til þess að draga eitt líf af RubyController hlutnum
            controller.ChangeHealth(-1);
        }
    }
}
