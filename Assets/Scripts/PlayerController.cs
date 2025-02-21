using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private TMP_Text _text;

    private Rigidbody _rb;
    private Animator _animator;
    private int _bonus;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Potoloc"))
        {
            _animator.Play("Death");
            UserEnterFace.action.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            _bonus++;
            _text.text = _bonus.ToString();
            Destroy(other.gameObject);
        }
    }
}
