using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public Stats Speed { get; protected set; }
    [field: SerializeField] public Stats Damage { get; protected set; }

    private void Update()
    {
        transform.position += transform.up * Speed.GetValue() * Time.deltaTime;
    }

}
