# Class SnapZoneConfigurator

Sets up the Interactions SnapZone Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [ActivationArea]
  * [ActivationValidator]
  * [CollidingObjectsList]
  * [Facade]
  * [ForceUnsnapInteractableProcess]
  * [GrabStateEmitter]
  * [PropertyApplier]
  * [SnapDroppedInteractableProcess]
  * [SnappableInteractables]
  * [SnappedInteractable]
  * [SnappedInteractablesList]
  * [ValidCollisionRules]
  * [ValidSnappableInteractablesList]
* [Methods]
  * [ConfigurePropertyApplier()]
  * [ConfigureValidityRules()]
  * [EmitActivated(GameObject)]
  * [EmitDeactivated(GameObject)]
  * [EmitEntered(GameObject)]
  * [EmitExited(GameObject)]
  * [EmitSnapped(GameObject)]
  * [EmitUnsnapped(GameObject)]
  * [OnDisable()]
  * [OnEnable()]
  * [ProcessOtherSnappablesOnSnap()]
  * [Snap(GameObject)]
  * [Unsnap()]

## Details

##### Inheritance

* System.Object
* SnapZoneConfigurator

##### Namespace

* [Tilia.Interactions.SnapZone]

##### Syntax

```
public class SnapZoneConfigurator : MonoBehaviour
```

### Properties

#### ActivationArea

The [ActivationValidator] that determines if the activation of the zone is valid.

##### Declaration

```
public SnapZoneActivator ActivationArea { get; protected set; }
```

#### ActivationValidator

The [ActivationValidator] that determines if the activation of the zone is valid.

##### Declaration

```
public ActivationValidator ActivationValidator { get; protected set; }
```

#### CollidingObjectsList

The GameObjectObservableList containing the list of objects that are currently colliding with the zone.

##### Declaration

```
public GameObjectObservableList CollidingObjectsList { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public SnapZoneFacade Facade { get; protected set; }
```

#### ForceUnsnapInteractableProcess

The GameObjectEventProxyEmitter that is responsible for forcing an unsnap of the snapped Interactable.

##### Declaration

```
public GameObjectEventProxyEmitter ForceUnsnapInteractableProcess { get; protected set; }
```

#### GrabStateEmitter

The InteractableGrabStateEmitter that processes if the interactable entering the zone is being grabbed.

##### Declaration

```
public InteractableGrabStateEmitter GrabStateEmitter { get; protected set; }
```

#### PropertyApplier

The TransformPropertyApplier that transitions the Interactable to the snapped destination.

##### Declaration

```
public TransformPropertyApplier PropertyApplier { get; protected set; }
```

#### SnapDroppedInteractableProcess

The GameObjectEventProxyEmitter that is responsible for processing the snap of a valid dropped Interactable.

##### Declaration

```
public GameObjectEventProxyEmitter SnapDroppedInteractableProcess { get; protected set; }
```

#### SnappableInteractables

Returns the collection of GameObjects that are currently colliding with the snap zone and are valid to be snapped.

##### Declaration

```
public HeapAllocationFreeReadOnlyList<GameObject> SnappableInteractables { get; }
```

#### SnappedInteractable

Returns the currently snapped GameObject.

##### Declaration

```
public GameObject SnappedInteractable { get; }
```

#### SnappedInteractablesList

The GameObjectObservableList containing the list of snapped Interactables.

##### Declaration

```
public GameObjectObservableList SnappedInteractablesList { get; protected set; }
```

#### ValidCollisionRules

The RuleContainerObservableList that determines the valid snappable Interactables.

##### Declaration

```
public RuleContainerObservableList ValidCollisionRules { get; protected set; }
```

#### ValidSnappableInteractablesList

The GameObjectObservableList containing the list of Interactables that can be snapped.

##### Declaration

```
public GameObjectObservableList ValidSnappableInteractablesList { get; protected set; }
```

### Methods

#### ConfigurePropertyApplier()

Configures the transition duration for the snapping process.

##### Declaration

```
public virtual void ConfigurePropertyApplier()
```

#### ConfigureValidityRules()

Configures the validity rules for the snap zone.

##### Declaration

```
public virtual void ConfigureValidityRules()
```

#### EmitActivated(GameObject)

Emits the Activated event.

##### Declaration

```
public virtual void EmitActivated(GameObject activator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | activator | The GameObject that has activated the zone. |

#### EmitDeactivated(GameObject)

Emits the Deactivated event.

##### Declaration

```
public virtual void EmitDeactivated(GameObject deactivator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | deactivator | The GameObject that has deactivated the zone. |

#### EmitEntered(GameObject)

Emits the Entered event.

##### Declaration

```
public virtual void EmitEntered(GameObject entered)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | entered | The GameObject that has entered the zone. |

#### EmitExited(GameObject)

Emits the Exited event.

##### Declaration

```
public virtual void EmitExited(GameObject exited)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | exited | The GameObject that has exited the zone. |

#### EmitSnapped(GameObject)

Emits the Snapped event.

##### Declaration

```
public virtual void EmitSnapped(GameObject snapped)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | snapped | The GameObject is snapped to the zone. |

#### EmitUnsnapped(GameObject)

Emits the Unsnapped event.

##### Declaration

```
public virtual void EmitUnsnapped(GameObject unsnapped)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | unsnapped | The GameObject is unsnapped from the zone. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### ProcessOtherSnappablesOnSnap()

Attempts to process any other valid snappable objects against any other potential SnapZones if their primary activating zone is snapped by another object.

##### Declaration

```
public virtual void ProcessOtherSnappablesOnSnap()
```

#### Snap(GameObject)

Attempts to snap a given GameObject to the snap zone.

##### Declaration

```
public virtual void Snap(GameObject objectToSnap)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | objectToSnap | The object to attempt to snap. |

#### Unsnap()

Attempts to unsnap any existing InteractableFacade that is currently snapped to the snap zone.

##### Declaration

```
public virtual void Unsnap()
```

[Tilia.Interactions.SnapZone]: README.md
[ActivationValidator]: SnapZoneConfigurator.md#ActivationValidator
[SnapZoneActivator]: SnapZoneActivator.md
[ActivationValidator]: SnapZoneConfigurator.md#ActivationValidator
[ActivationValidator]: ActivationValidator.md
[SnapZoneFacade]: SnapZoneFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[ActivationArea]: #ActivationArea
[ActivationValidator]: #ActivationValidator
[CollidingObjectsList]: #CollidingObjectsList
[Facade]: #Facade
[ForceUnsnapInteractableProcess]: #ForceUnsnapInteractableProcess
[GrabStateEmitter]: #GrabStateEmitter
[PropertyApplier]: #PropertyApplier
[SnapDroppedInteractableProcess]: #SnapDroppedInteractableProcess
[SnappableInteractables]: #SnappableInteractables
[SnappedInteractable]: #SnappedInteractable
[SnappedInteractablesList]: #SnappedInteractablesList
[ValidCollisionRules]: #ValidCollisionRules
[ValidSnappableInteractablesList]: #ValidSnappableInteractablesList
[Methods]: #Methods
[ConfigurePropertyApplier()]: #ConfigurePropertyApplier
[ConfigureValidityRules()]: #ConfigureValidityRules
[EmitActivated(GameObject)]: #EmitActivatedGameObject
[EmitDeactivated(GameObject)]: #EmitDeactivatedGameObject
[EmitEntered(GameObject)]: #EmitEnteredGameObject
[EmitExited(GameObject)]: #EmitExitedGameObject
[EmitSnapped(GameObject)]: #EmitSnappedGameObject
[EmitUnsnapped(GameObject)]: #EmitUnsnappedGameObject
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[ProcessOtherSnappablesOnSnap()]: #ProcessOtherSnappablesOnSnap
[Snap(GameObject)]: #SnapGameObject
[Unsnap()]: #Unsnap