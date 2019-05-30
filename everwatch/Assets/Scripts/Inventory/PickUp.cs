using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Texture icon;
    public enum PickUpType {consumable, weapon, material};
    public PickUpType pickUpType;

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public bool pickedUp;
    public bool equipped;


}
