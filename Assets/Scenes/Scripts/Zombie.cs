
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Destroy(_animator, 1);
    }
}
