using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location")]
    [SerializeField] private OVRGrabbable grabbable;
    [SerializeField] private OVRGrabber left;
    [SerializeField] private OVRGrabber right;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [SerializeField] private float destroyTimer = 2f;
    [SerializeField] private float shotPower = 500f;
    [SerializeField] private float ejectPower = 150f;
    [SerializeField] private AudioSource audio;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(grabbable.isGrabbed)
        {
            if(grabbable.grabbedBy == right)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                    gunAnimator.SetTrigger("Fire");
            } else if(grabbable.grabbedBy == left)
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    gunAnimator.SetTrigger("Fire");
            }

        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            
        }
    }


    void Shoot()
    {
        audio.Play();

        if (muzzleFlashPrefab)
        {
            
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            
            Destroy(tempFlash, destroyTimer);
        }

        
        if (!bulletPrefab)
        { return; }

        
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);

    }

    
    void CasingRelease()
    {
        
        if (!casingExitLocation || !casingPrefab)
        { return; }

        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
   
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

   
        Destroy(tempCasing, destroyTimer);
    }

}
