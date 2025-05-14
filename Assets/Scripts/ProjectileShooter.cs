using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileShooter : MonoBehaviour
{
    public ProjectilePool[] projectilePools;
    public Transform firePoint;
    private int currentType = 0;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentType = (currentType + 1) % projectilePools.Length;
            Debug.Log("Tipo cambiado a: " + (currentType + 1));
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            projectilePools[currentType].GetProjectile(firePoint.position, firePoint.rotation);
        }
    }
    public void ReactivarTarget(GameObject target, float delay)
    {
        StartCoroutine(ReactivarTargetLuego(target, delay));
    }

    private IEnumerator ReactivarTargetLuego(GameObject target, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        target.SetActive(true);

        // Reinicia collider para evitar errores
        Collider col = target.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
            yield return null;
            col.enabled = true;
        }

        Debug.Log("Target reactivado");
    }


    public void DisableShootingFor(float seconds)
    {
        StartCoroutine(DisableTemporarily(seconds));
    }

    IEnumerator DisableTemporarily(float seconds)
    {
        canShoot = false;
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }
}
