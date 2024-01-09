using UnityEngine;
using UnityEngine.Events;

public class ShootingAction : MonoBehaviour

    // Use the action bar to change the effect that happens to the affected object!
    // Attach this to each object that wants to be affected by the projectile
{
    public UnityEvent action;

    public void Action()
    {
        action?.Invoke();
    }
}
