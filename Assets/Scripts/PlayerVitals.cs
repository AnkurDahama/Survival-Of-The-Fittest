using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour {
    public Slider HealthBar;
    public Slider ThirstBar;
    public Slider HungerBar;
    public CharacterController player;
    private float HealthFactor;
    private float ThirstFactor;
    private float HungerFactor;

	// Use this for initialization
	void Start () {
        InitBars();
        HealthFactor = 2.5F;
        ThirstFactor = 1.5F;
        HungerFactor = 0.8F;

	}
	
	// Update is called once per frame
	void Update () {
        CheckExtremes();
        DeductVitalsOnTime();
        DeductVitalsOnMove();
	}

    void CheckExtremes()
    {
        if (HealthBar.value <= 0)
            HealthBar.value = 0;
        if (ThirstBar.value <= 0)
            ThirstBar.value = 0;
        if (HungerBar.value <= 0)
            HungerBar.value = 0;
        if (HealthBar.value >= 100)
            HealthBar.value = 100;
        if (ThirstBar.value >= 100)
            ThirstBar.value = 100;
        if (HungerBar.value >= 100)
            HungerBar.value = 100;

    }

    void InitBars()
    {
        HealthBar.maxValue = 100;
        ThirstBar.maxValue = 100;
        HungerBar.maxValue = 100;
        HealthBar.value = 100;
        ThirstBar.value = 100;
        HungerBar.value = 100;
    }

    void DeductVitalsOnTime()
    {
        if (ThirstBar.value <= 0 || HungerBar.value <= 0)
            HealthBar.value -= Time.deltaTime * HealthFactor;

        ThirstBar.value -= Time.deltaTime * ThirstFactor;
        HungerBar.value -= Time.deltaTime * HungerFactor;
    }

    void DeductVitalsOnMove()
    {
        if(player.velocity.magnitude > 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                ThirstBar.value -= Time.deltaTime * 4;
                HungerBar.value -= Time.deltaTime * 2;
            } else
            {
                ThirstBar.value -= Time.deltaTime * 1.5F;
                HungerBar.value -= Time.deltaTime * 1;
            }
        }
    }
}
