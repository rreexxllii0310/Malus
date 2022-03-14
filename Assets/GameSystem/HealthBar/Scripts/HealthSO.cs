using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health", menuName = "Health Value/Health")]
public class HealthSO : ScriptableObject
{
    [SerializeField]
    int maxHealthValue = 100;
    [SerializeField]
    int healthValue;

    public int MaxHealthValue
    {
        get { return maxHealthValue; }
        set { maxHealthValue = value; }
    }

    public int HealthValue
    {
        get { return healthValue; }
        set
        {
            healthValue = value;
            if (healthValue < 0)
            {
                healthValue = 0;
            }
            else if (healthValue > maxHealthValue)
            {
                healthValue = maxHealthValue;
            }
        }
    }
}
