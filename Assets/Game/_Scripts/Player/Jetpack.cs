using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] private float _maxFuel = 10f;
    [SerializeField] private float _jetpackForce = 10f;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private ParticleSystem _jetpackParticles;
    
    private Rigidbody _rbPlayer;
    public float _currentFuel; //privee, public pr voir ds inspecteur
    private bool _isActive = false;

    private void Start()
    {
        _currentFuel = _maxFuel;
        _rbPlayer = _player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //if (_player.IsGrounded() && _currentFuel < _maxFuel)
        //{
        //    _currentFuel += Time.deltaTime;
        //}

        if (_isActive == false)
        {
            _jetpackParticles.Stop();
            return;
        }

        TryUseJetpack();
   
    }

    public void AddFuel(float amount)
    {
        if (_currentFuel + amount > _maxFuel)
        {
            _currentFuel = _maxFuel;
            return;
        }

        _currentFuel += amount;
    }

    public void StartJetpack()
    {
        _isActive = true;
    }

    public void StopJetpack()
    {
        _isActive = false;

        _jetpackParticles.Stop();
    }

    public void TryUseJetpack()
    {
        if (_currentFuel > 0)
        {
            _currentFuel -= Time.fixedDeltaTime;
            _rbPlayer.AddForce(Vector3.up * _jetpackForce, ForceMode.Acceleration);

            _jetpackParticles.Play();
        }
        else
        {
            Debug.Log("out of fuel");
        }
    }
}
