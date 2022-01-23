public sealed class Goal
{
    private GoalName _goalName;
    private WorldState _state;
    private int _importance;

    
    public Goal(GoalName goalName, WorldState state, int importance)
    {
        _goalName = goalName;
        _state = state;
        _importance = importance;
    }

    public GoalName GoalName => _goalName;
    public WorldState State => _state;
    public int Importance => _importance;
}