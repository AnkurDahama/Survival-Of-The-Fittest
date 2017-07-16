using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProp : MonoBehaviour {
    public PlayerVitals playerVitals;
    public enum Type { Health, Thirst, Hunger}
    public Type MyType;
    public void Interact()
    {
        if (MyType == Type.Health)
            playerVitals.HealthBar.value += 10;
        else if (MyType == Type.Thirst)
            playerVitals.ThirstBar.value += 10;
        else if (MyType == Type.Hunger)
            playerVitals.HungerBar.value += 10;

        Destroy(gameObject);

    }
}
