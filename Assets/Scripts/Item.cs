using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string _id;
    public string Id => _id;
}