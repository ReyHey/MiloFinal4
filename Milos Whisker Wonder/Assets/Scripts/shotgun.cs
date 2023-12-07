//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class shotgun : MonoBehaviour
//{
//    [SerializeField] GameObject projectile;
//    [SerializeField] GameObject gun;
//    [SerializeField] float attackingRange = 3f;
//    AttackerSpawner myLaneSpawner;
//    Animator myAnimator;



//    private void Start()
//    {
//        SetLaneSpawner();
//        myAnimator = GetComponent<Animator>();

//    }

//    private void Update()
//    {
//        if (IsAttackerWithinRange())
//        {
//            myAnimator.SetBool("isAttacking", true);
//        }
//        else
//        {
//            myAnimator.SetBool("isAttacking", false);
//        }
//    }

//    private void SetLaneSpawner()
//    {
//        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
//        foreach (AttackerSpawner spawner in spawners)
//        {
//            bool IsCloseEnough =
//                (Mathf.Abs(spawner.transform.position.y - transform.position.y)
//                <= Mathf.Epsilon);

//            if (IsCloseEnough)
//            {
//                myLaneSpawner = spawner;
//            }
//        }
//    }

//    private bool IsAttackerWithinRange()
//    {
//        //If there is no attacker, return false
//        if (myLaneSpawner.transform.childCount <= 0)
//        {
//            return false;
//        }


//        Transform lane = myLaneSpawner.transform;

//        float defenderPosX = transform.position.x;
//        float enemyPosX = 0f;
//        float distance;

//        //Im getting the x position for each child of the spawner
//        foreach (Transform enemy in lane)
//        {
//            enemyPosX = enemy.position.x;
//            distance = Mathf.Abs(defenderPosX - enemyPosX);
//            /*If the distance between Cowgirl & Robot is less than or equal
//        	to the shotguns attacking range, fire!*/
//            if (distance <= attackingRange)
//            {
//                return true;
//            }

//        }
//        return false;
//    }

//    public void Fire()
//    {
//        //Change this to be 3 bullets later....
//        Instantiate(projectile, gun.transform.position, transform.rotation);
//    }

//}


