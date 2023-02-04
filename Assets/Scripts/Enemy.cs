using UnityEngine;

[System.Serializable]
public class Enemy
{
    [Range(0f, 100f)]
    public float damage = 5f;
    [Range(0.1f, 2f)] 
    public float damageCooldown;
    [Range(0f, 100f)]
    public float health = 100f;
    [Space] 
    public Transform A;
    public Transform B;
}