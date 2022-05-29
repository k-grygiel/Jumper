using UnityEngine;
using Useables;

public static class ExtensionMethods
{
    public static bool IsPlayer(this Collider collider)
    {
        return collider.CompareTag("Player");
    }

    public static bool IsUseable(this Collider collider)
    {
        return collider.GetComponent<IUseable>() != null;
    }
}
