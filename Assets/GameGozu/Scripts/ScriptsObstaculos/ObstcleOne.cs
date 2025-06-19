using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstcleOne : MonoBehaviour
{
    [SerializeField] private float saltoFrecuencia;
    [SerializeField] private float saltoAltura;
    [SerializeField] private AnimationCurve curvaSalto;
    [SerializeField] private float multiplicadorCurva;

    private float tiempo;
    private Vector3 posicionInicial;

    private void Start()
    {
        tiempo = 0f;
        posicionInicial = transform.position;
    }

    private void Update()
    {
        tiempo += Time.deltaTime * saltoFrecuencia;
        float valorCurva = curvaSalto.Evaluate(Mathf.Sin(tiempo));
        float altura = valorCurva * saltoAltura * multiplicadorCurva;

        transform.position = new Vector3(transform.position.x,posicionInicial.y + altura,
            transform.position.z);
    }
}