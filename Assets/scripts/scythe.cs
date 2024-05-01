using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(weapon))]
public class scythe : MonoBehaviour

{
    float duration = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        duration = 5f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 5f * Time.deltaTime;
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }

    }

    


    /* DESPAWN WEAPONS
        weapon.timeAlive -= Time.deltaTime;
            if(weapon.timeAlive <= 0){
                
            }
    */
}
