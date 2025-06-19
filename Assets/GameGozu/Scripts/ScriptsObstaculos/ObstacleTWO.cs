using DG.Tweening;
using UnityEngine;

public class ObstacleTWO : MonoBehaviour
{
    [SerializeField] private float velocityRotate;

    private void Start()
    {
        transform.DOLocalRotate(new Vector3(0,360* velocityRotate, 0), 1f, RotateMode.LocalAxisAdd)
     .SetEase(Ease.Linear)
     .SetLoops(-1);
    }
}
