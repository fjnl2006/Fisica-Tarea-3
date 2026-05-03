using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Cohete[] rockets;

    public void OnLaunch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            foreach (Cohete rocket in rockets)
            {
                rocket.StartThrust();
            }
        }

        if (context.canceled)
        {
            foreach (Cohete rocket in rockets)
            {
                rocket.StopThrust();
            }
        }
    }
}
