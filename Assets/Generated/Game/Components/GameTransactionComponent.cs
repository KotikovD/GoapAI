//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TransactionComponent transaction { get { return (TransactionComponent)GetComponent(GameComponentsLookup.Transaction); } }
    public bool hasTransaction { get { return HasComponent(GameComponentsLookup.Transaction); } }

    public void AddTransaction(GameEntity newTo, ResourceType newResourceType, int newResourceCount) {
        var index = GameComponentsLookup.Transaction;
        var component = (TransactionComponent)CreateComponent(index, typeof(TransactionComponent));
        component.To = newTo;
        component.ResourceType = newResourceType;
        component.ResourceCount = newResourceCount;
        AddComponent(index, component);
    }

    public void ReplaceTransaction(GameEntity newTo, ResourceType newResourceType, int newResourceCount) {
        var index = GameComponentsLookup.Transaction;
        var component = (TransactionComponent)CreateComponent(index, typeof(TransactionComponent));
        component.To = newTo;
        component.ResourceType = newResourceType;
        component.ResourceCount = newResourceCount;
        ReplaceComponent(index, component);
    }

    public void RemoveTransaction() {
        RemoveComponent(GameComponentsLookup.Transaction);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTransaction;

    public static Entitas.IMatcher<GameEntity> Transaction {
        get {
            if (_matcherTransaction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Transaction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTransaction = matcher;
            }

            return _matcherTransaction;
        }
    }
}
