using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum Type { Type1, Type2, Type3 }
    public Type projectileType;
    public ParticleSystem particleEffect;

    public float speed = 50f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime*8);

    }
    private void OnEnable()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
    private void OnDisable()
    {
        if (particleEffect != null)
        {
            particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Target")) return;

        switch (projectileType)
        {
            case Type.Type1:
                Debug.Log("Impacto de proyectil tipo 1");
                gameObject.SetActive(false);
                break;

            case Type.Type2:
                Debug.Log("Impacto de proyectil tipo 2");

                other.gameObject.SetActive(false); // Oculta el target
                FindObjectOfType<ProjectileShooter>().ReactivarTarget(other.gameObject, 1f);


                FindObjectOfType<ProjectileShooter>().DisableShootingFor(1f); // Bloquea disparo

                gameObject.SetActive(false); // Recicla el proyectil
                break;


            case Type.Type3:
                if (particleEffect != null)
                {
                    particleEffect.gameObject.SetActive(true);
                    particleEffect.Play();
                    Debug.Log("Impacto de proyectil tipo 3");
                    StartCoroutine(DisableAfterDelay(0.5f));
                }
                break;
        }
    }
    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    private IEnumerator ReactivarTargetLuego(GameObject target, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        target.SetActive(true);

        // Forzar reinicio del collider (importante si sigue sin detectar colisiones)
        Collider col = target.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
            yield return null; // espera 1 frame
            col.enabled = true;
        }

        // Confirmación visual
        Debug.Log("Target reactivado");
    }






}
