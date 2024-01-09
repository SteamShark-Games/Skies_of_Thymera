using UnityEngine;
using UnityEngine.Events;

public class ShootingManager : MonoBehaviour
{
    public GameObject[] ShootingBullet;
    public int bulletSelection = 0;
    public Transform shootingPoint;
    public bool canShoot = true;
    public UnityEvent OnShootEvent;

    //Create a "shootingPoint" object as a child of the player and adjust it so it is in front of the player slightly!

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (!canShoot)
            return;

        GameObject si = Instantiate(ShootingBullet[bulletSelection], shootingPoint);
        si.transform.parent = null;

        OnShootEvent.Invoke();
    }

 /*   GameObject[] ShootingBulletTypes
        
int bulletSelection = 0;


...

Instantiate(ShootingBulletTypes[bulletSelection], ...
 */
}
