namespace Assets.Scripts.AI
{
    public interface IEnemyState
    {
        void Enter(EnemyBase enemy);
        void Execute();
        void Exit();
    }
}
