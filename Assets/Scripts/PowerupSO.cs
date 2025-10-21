using UnityEngine;

[CreateAssetMenu(fileName = "PowerupSO", menuName = "Scriptable Objects/PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float time;


    public float GetSpeed()
    {
        return speed;
    }

    public float GetTime()
    {
        return time;
    }
}
