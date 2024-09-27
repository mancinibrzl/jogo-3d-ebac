using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    [SerializeField] private GunBase[] _gunPrefabs;
    public Transform gunPosition;
    
    private GunBase _currentGun;

    private GunBase[] _gunInstances;

    protected override void Init()
    {
        base.Init();

        CreateGuns();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.ChangeGun1.performed += ctx => ChangeGun(0);
        inputs.Gameplay.ChangeGun2.performed += ctx => ChangeGun(1);
    }

    private void CreateGuns()
    {
        _gunInstances = new GunBase[_gunPrefabs.Length];

        for (int i = 0; i < _gunPrefabs.Length; ++i)
        {
            _gunInstances[i] = Instantiate(_gunPrefabs[i], gunPosition);
            _gunInstances[i].transform.localPosition = _gunInstances[i].transform.localEulerAngles = Vector3.zero;
            _gunInstances[i].gameObject.SetActive(false);
        }

        _currentGun = _gunInstances[0];
        _currentGun.gameObject.SetActive(true);
    }

    private void ChangeGun(int index)
    {
        if(_currentGun == _gunInstances[index])
           return;

        _currentGun.gameObject.SetActive(false);
        _currentGun = _gunInstances[index];
        _currentGun.gameObject.SetActive(true);
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }
    
    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShoot();
    }
}
