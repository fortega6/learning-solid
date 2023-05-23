using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] private string _id;
    public string Id => _id;
}