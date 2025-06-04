using System;
using UnityEngine;

public class AttackStateMachine : StateMachineBehaviour
{

    public GameObject particle;
    private bool launchedProjectile = false;


    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > .1 && !launchedProjectile)
        {
            var projectilePosition = animator.gameObject.transform.position;
            if (animator.gameObject.transform.localScale.x == -1)
            {
                projectilePosition.x += 2.5f;
                projectilePosition.y -= .75f;
                var projectile = (GameObject)Instantiate(particle, projectilePosition, Quaternion.identity);
                var temp = projectile.transform.localScale;
                temp.x = -1;
                projectile.transform.localScale = temp;
                var particleSystem = projectile.GetComponentInChildren<ParticleSystem>();
                particleSystem.transform.localRotation = Quaternion.Euler(new Vector3(0, 270, -90));
            }
            else
            {
                projectilePosition.x += 2.5f;
                projectilePosition.y -= .75f;
                var go = (GameObject)Instantiate(particle, projectilePosition, Quaternion.identity);
            }
            launchedProjectile = true;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        launchedProjectile = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
