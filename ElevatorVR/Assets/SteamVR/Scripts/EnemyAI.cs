using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//public class EnemyAI : MonoBehaviour
//{
//    public float seeDistance = 30.0f;
//    public float attackDistance = 5.0f;
//    private NavMeshAgent nav;
//    public Transform target;
//    public Animation anim;
//    public AnimationClip a_Idle;
//    public float a_IdleSpeed = 1;
//    public AnimationClip a_Walk;
//    public float a_WalkSpeed = 2;
//    public AnimationClip a_Attack;
//    public float a_AttackSpeed = 2;
//    public bool walk;
//    public bool Attack;


//    // Start is called before the first frame update
//    void Start()
//    {
//        GetComponent<Animation>()[a_Idle.name].speed = a_IdleSpeed;
//        GetComponent<Animation>()[a_Attack.name].speed = a_AttackSpeed;
//        GetComponent<Animation>()[a_Walk.name].speed = a_WalkSpeed;
//        GetComponent<Animation>().CrossFade(a_Idle.name);
//    }

//    void IdleState()
//    {
//        nav.enabled = false;
//        GetComponent<Animation>().CrossFade(a_Idle.name);
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        if (anim[a_Attack.name].enabled == false)
//        {
//            Attack = true;
//        }

//        if (Vector3.Distance(transform.position, target.transform.position) <= seeDistance & Attack == true)
//        {
//            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance & anim[a_Attack.name].enabled == false)
//            {
//                GetComponent<Animation>().CrossFade(a_Walk.name);
//                walk = true;
//                nav.enabled = true;
//                nav.SetDestination(target.position);
//            }
//            else
//            {
//                if (target.tag == "Player")
//                {
//                    nav.enabled = false;
//                    GetComponent<Animation>().CrossFade(a_Attack.name);
//                    walk = false;
//                    Vector3 lookAtPosition = target.position;
//                    lookAtPosition.y = transform.position.y;
//                    transform.LookAt(lookAtPosition);
//                }
//            }
//        }
//        else
//        {
//            GetComponent<Animation>().CrossFade(a_Idle.name);
//            walk = false;
//            nav.enabled = false;
//        }
//    }
//}





















public class EnemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent enemy;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.destination = player.transform.position;
    }
}
