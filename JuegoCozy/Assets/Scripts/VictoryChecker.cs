using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    private bool victoryPrinted = false;

    void Update()
    {
        if (victoryPrinted) return;

        // Limpia la lista de objetos ya destruidos (null)
        targets.RemoveAll(obj => obj == null);

        // Verifica si todos han sido destruidos
        if (targets.Count == 0)
        {
            Debug.Log("¡Victoria!");
            victoryPrinted = true;
        }
    }
}
