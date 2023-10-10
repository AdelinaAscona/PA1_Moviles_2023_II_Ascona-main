using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealth", menuName = "ScriptableObjects/PlayerHealth")]
public class PlayerHealth : ScriptableObject
{
    public int maxHealth = 3;
    public int currentHealth;
}