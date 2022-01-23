//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ResourceGetterComponent resourceGetter { get { return (ResourceGetterComponent)GetComponent(GameComponentsLookup.ResourceGetter); } }
    public bool hasResourceGetter { get { return HasComponent(GameComponentsLookup.ResourceGetter); } }

    public void AddResourceGetter(System.Collections.Generic.Dictionary<ResourceType, int> newItems) {
        var index = GameComponentsLookup.ResourceGetter;
        var component = (ResourceGetterComponent)CreateComponent(index, typeof(ResourceGetterComponent));
        component.Items = newItems;
        AddComponent(index, component);
    }

    public void ReplaceResourceGetter(System.Collections.Generic.Dictionary<ResourceType, int> newItems) {
        var index = GameComponentsLookup.ResourceGetter;
        var component = (ResourceGetterComponent)CreateComponent(index, typeof(ResourceGetterComponent));
        component.Items = newItems;
        ReplaceComponent(index, component);
    }

    public void RemoveResourceGetter() {
        RemoveComponent(GameComponentsLookup.ResourceGetter);
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

    static Entitas.IMatcher<GameEntity> _matcherResourceGetter;

    public static Entitas.IMatcher<GameEntity> ResourceGetter {
        get {
            if (_matcherResourceGetter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ResourceGetter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherResourceGetter = matcher;
            }

            return _matcherResourceGetter;
        }
    }
}
