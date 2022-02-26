public sealed class Goal
{
    private readonly GoalName _goalName;
    private readonly WorldState _state;
    private readonly int _importance;
    private readonly AgentType _agentType;
    private readonly int _count;
    
    public Goal(GoalName goalName, WorldState state, int importance, AgentType agentType, int count)
    {
        _goalName = goalName;
        _state = state;
        _importance = importance;
        _agentType = agentType;
        _count = count;
    }

    public GoalName GoalName => _goalName;
    public AgentType AgentType => _agentType;
    public WorldState State => _state;
    public int Importance => _importance;
    public int Count => _count;

    public bool Equals(Goal other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _goalName == other._goalName && _state == other._state && _importance == other._importance;
    }

    public override bool Equals(object obj)
    {
        return ReferenceEquals(this, obj) || obj is Goal other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (int) _goalName;
            hashCode = (hashCode * 397) ^ (int) _state;
            hashCode = (hashCode * 397) ^ _importance;
            return hashCode;
        }
    }
}