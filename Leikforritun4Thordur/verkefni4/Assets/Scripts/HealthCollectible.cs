using UnityEngine;

public class HealthCollectible : MonoBehaviour 
{
    // Fall sem er kallað þegar hlutur rekst á Collider2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Sækjum RubyController hlutinn úr hinum Collider2D hlutnum sem hluturinn er að rekast á
        RubyController controller = other.GetComponent<RubyController>();

        // Ef RubyController hluturinn er til staðar...
        if (controller != null)
        {
            // ...bætum við við einu lífi á RubyController hlutnum...
            controller.ChangeHealth(1);

            // ...og eyðum hlutnum sem skriftan er tengd við (sem var rekst á)
            Destroy(gameObject);
        }
    }
}
