using UnityEngine;

[CreateAssetMenu(menuName = "SO/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField] public Stats Damage { get; protected set; }
    [field: SerializeField] public Stats Speed { get; protected set; }
}
