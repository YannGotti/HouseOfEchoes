using UnityEngine;

namespace Assets.Scripts.AI
{
    public class EnemyBase : MonoBehaviour
    {
        private EnemyFSM fsm;
        private EnemyAnimator animator;

        public void OnSeePlayer() { }
        public void OnLostPlayer() { }
    }
}
