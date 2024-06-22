using DG.Tweening;
using UnityEngine;

public class ShotBomb : MonoBehaviour
{

    [SerializeField] private float rotateSpeed;
    Vector3 prevPos = new Vector3(0, 0, -10000f);

    [SerializeField] GameObject explosionEffect;

    private void Update()
    {

        if (prevPos != transform.position)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 10 * Time.deltaTime * rotateSpeed);
        }
        else
        {
            Explosion();
        }

        prevPos = transform.position;
    }
    public void Explosion()
    {

        DOTween.Sequence()
            .Append(transform.DOShakeRotation(0.5f, 5))
            .Join(transform.DOScale(1.2f, 0.5f))
            .AppendCallback(() =>
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            });

    }

}
