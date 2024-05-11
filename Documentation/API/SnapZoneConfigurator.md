# Class SnapZoneConfigurator

Sets up the Interactions SnapZone Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedSnappedInteractable]
  * [EndOfFrameInstruction]
  * [InitialOffset]
  * [SnapDefaultInteractableRoutine]
* [Properties]
  * [ActivationArea]
  * [ActivationValidator]
  * [AllValidRules]
  * [AutoSnapLogicContainer]
  * [CollidingObjectsList]
  * [DestinationLocation]
  * [Facade]
  * [Follower]
  * [ForceUnsnapInteractableProcess]
  * [GrabStateEmitter]
  * [HighlightLogicContainer]
  * [HighlightMeshContainer]
  * [InitialTransitionDuration]
  * [PropertyApplier]
  * [SnapDroppedInteractableProcess]
  * [SnappableInteractables]
  * [SnappedInteractable]
  * [SnappedInteractablesList]
  * [ValidCollisionRules]
  * [ValidSnappableInteractablesList]
* [Methods]
  * [ConfigureAutoSnap()]
  * [ConfigureHighlightLogic()]
  * [ConfigurePropertyApplier()]
  * [ConfigureSnapZoneScaling()]
  * [ConfigureValidityRules()]
  * [EmitActivated(GameObject)]
  * [EmitDeactivated(GameObject)]
  * [EmitEntered(GameObject)]
  * [EmitExited(GameObject)]
  * [EmitSnapped(GameObject)]
  * [EmitUnsnapped(GameObject)]
  * [Hide()]
  * [OnDisable()]
  * [OnEnable()]
  * [PrepareKinematicStateChange(GameObject)]
  * [PrepareKinematicStateChange(InteractableFacade)]
  * [PrepareKinematicStateChange(Rigidbody)]
  * [ProcessOtherSnappablesOnSnap()]
  * [Show()]
  * [Snap(GameObject)]
  * [SnapInitialAtEndOfFrame()]
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

### Fields

#### cachedSnappedInteractable

A container for caching the snapped interactable when hiding the snap zone.

##### Declaration

```
protected InteractableFacade cachedSnappedInteractable
```

#### EndOfFrameInstruction

An instruction for yielding at the end of the current frame.

##### Declaration

```
protected YieldInstruction EndOfFrameInstruction
```

#### InitialOffset

An offset to apply upon snap if the snapped GameObject is in the same position as the [DestinationLocation] to ensure the follower works correctly.

##### Declaration

```
protected float InitialOffset
```

#### SnapDefaultInteractableRoutine

The Coroutine for managing the default initial snap.

##### Declaration

```
protected Coroutine SnapDefaultInteractableRoutine
```

### Properties

#### ActivationArea

The [SnapZoneActivator] that determines if the activation area.

##### Declaration

```
public SnapZoneActivator ActivationArea { get; set; }
```

#### ActivationValidator

The [ActivationValidator] that determines if the activation of the zone is valid.

##### Declaration

```
public ActivationValidator ActivationValidator { get; set; }
```

#### AllValidRules

The AllRule that takes the [ValidCollisionRules].

##### Declaration

```
public AllRule AllValidRules { get; set; }
```

#### AutoSnapLogicContainer

The GameObject that contains the auto snap logic.

##### Declaration

```
public GameObject AutoSnapLogicContainer { get; set; }
```

#### CollidingObjectsList

The GameObjectObservableList containing the list of objects that are currently colliding with the zone.

##### Declaration

```
public GameObjectObservableList CollidingObjectsList { get; set; }
```

#### DestinationLocation

The GameObject that determines the snap destination location.

##### Declaration

```
public GameObject DestinationLocation { get; set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public SnapZoneFacade Facade { get; set; }
```

#### Follower

The GameObject that holds the highlight on hover logic.

##### Declaration

```
public ObjectFollower Follower { get; set; }
```

#### ForceUnsnapInteractableProcess

The GameObjectEventProxyEmitter that is responsible for forcing an unsnap of the snapped Interactable.

##### Declaration

```
public GameObjectEventProxyEmitter ForceUnsnapInteractableProcess { get; set; }
```

#### GrabStateEmitter

The InteractableGrabStateEmitter that processes if the interactable entering the zone is being grabbed.

##### Declaration

```
public InteractableGrabStateEmitter GrabStateEmitter { get; set; }
```

#### HighlightLogicContainer

The GameObject that holds the highlight on hover logic.

##### Declaration

```
public GameObject HighlightLogicContainer { get; set; }
```

#### HighlightMeshContainer

The GameObject that holds the highlight mesh containerc.

##### Declaration

```
public GameObject HighlightMeshContainer { get; set; }
```

#### InitialTransitionDuration

The initial duration to transition the default Interactable to the SnapZone.

##### Declaration

```
public float InitialTransitionDuration { get; set; }
```

#### PropertyApplier

The TransformPropertyApplier that transitions the Interactable to the snapped destination.

##### Declaration

```
public TransformPropertyApplier PropertyApplier { get; set; }
```

#### SnapDroppedInteractableProcess

The GameObjectEventProxyEmitter that is responsible for processing the snap of a valid dropped Interactable.

##### Declaration

```
public GameObjectEventProxyEmitter SnapDroppedInteractableProcess { get; set; }
```

#### SnappableInteractables

Returns the collection of GameObjects that are currently colliding with the snap zone and are valid to be snapped.

##### Declaration

```
public virtual HeapAllocationFreeReadOnlyList<GameObject> SnappableInteractables { get; }
```

#### SnappedInteractable

Returns the currently snapped GameObject.

##### Declaration

```
public virtual GameObject SnappedInteractable { get; }
```

#### SnappedInteractablesList

The GameObjectObservableList containing the list of snapped Interactables.

##### Declaration

```
public GameObjectObservableList SnappedInteractablesList { get; set; }
```

#### ValidCollisionRules

The RuleContainerObservableList that determines the valid snappable Interactables.

##### Declaration

```
public RuleContainerObservableList ValidCollisionRules { get; set; }
```

#### ValidSnappableInteractablesList

The GameObjectObservableList containing the list of Interactables that can be snapped.

##### Declaration

```
public GameObjectObservableList ValidSnappableInteractablesList { get; set; }
```

### Methods

#### ConfigureAutoSnap()

Configures the auto snap logic.

##### Declaration

```
public virtual void ConfigureAutoSnap()
```

#### ConfigureHighlightLogic()

Configures the highlight logic of the snap zone.

##### Declaration

```
public virtual void ConfigureHighlightLogic()
```

#### ConfigurePropertyApplier()

Configures the transition duration for the snapping process.

##### Declaration

```
public virtual void ConfigurePropertyApplier()
```

#### ConfigureSnapZoneScaling()

Configures whether the snap zone will scale the target snapped object.

##### Declaration

```
public virtual void ConfigureSnapZoneScaling()
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

#### Hide()

Attempts to gracefully disable the snap zone.

##### Declaration

```
public virtual void Hide()
```

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

#### PrepareKinematicStateChange(GameObject)

Prepares the given GameObject for a kinematic state change.

##### Declaration

```
public virtual void PrepareKinematicStateChange(GameObject target)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | target | The GameObject to prepare. |

#### PrepareKinematicStateChange(InteractableFacade)

Prepares the given InteractableFacade for a kinematic state change.

##### Declaration

```
public virtual void PrepareKinematicStateChange(InteractableFacade target)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | target | The interactable to prepare. |

#### PrepareKinematicStateChange(Rigidbody)

Prepares the given Rigidbody for a kinematic state change.

##### Declaration

```
public virtual void PrepareKinematicStateChange(Rigidbody target)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| Rigidbody | target | The rigidbody to prepare. |

#### ProcessOtherSnappablesOnSnap()

Attempts to process any other valid snappable objects against any other potential SnapZones if their primary activating zone is snapped by another object.

##### Declaration

```
public virtual void ProcessOtherSnappablesOnSnap()
```

#### Show()

Attempts to gracefully enable the snap zone after being hidden.

##### Declaration

```
public virtual void Show()
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

#### SnapInitialAtEndOfFrame()

Snaps the Facade.SnapInitialAtEndOfFrame to the snap zone at the end of the frame.

##### Declaration

```
protected virtual IEnumerator SnapInitialAtEndOfFrame()
```

##### Returns

| Type | Description |
| --- | --- |
| System.Collections.IEnumerator | An Enumerator to manage the running of the Coroutine. |

#### Unsnap()

Attempts to unsnap any existing InteractableFacade that is currently snapped to the snap zone.

##### Declaration

```
public virtual void Unsnap()
```

[Tilia.Interactions.SnapZone]: README.md
[DestinationLocation]: SnapZoneConfigurator.md#DestinationLocation
[SnapZoneActivator]: SnapZoneActivator.md
[ActivationValidator]: SnapZoneConfigurator.md#ActivationValidator
[ActivationValidator]: ActivationValidator.md
[ValidCollisionRules]: SnapZoneConfigurator.md#ValidCollisionRules
[SnapZoneFacade]: SnapZoneFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedSnappedInteractable]: #cachedSnappedInteractable
[EndOfFrameInstruction]: #EndOfFrameInstruction
[InitialOffset]: #InitialOffset
[SnapDefaultInteractableRoutine]: #SnapDefaultInteractableRoutine
[Properties]: #Properties
[ActivationArea]: #ActivationArea
[ActivationValidator]: #ActivationValidator
[AllValidRules]: #AllValidRules
[AutoSnapLogicContainer]: #AutoSnapLogicContainer
[CollidingObjectsList]: #CollidingObjectsList
[DestinationLocation]: #DestinationLocation
[Facade]: #Facade
[Follower]: #Follower
[ForceUnsnapInteractableProcess]: #ForceUnsnapInteractableProcess
[GrabStateEmitter]: #GrabStateEmitter
[HighlightLogicContainer]: #HighlightLogicContainer
[HighlightMeshContainer]: #HighlightMeshContainer
[InitialTransitionDuration]: #InitialTransitionDuration
[PropertyApplier]: #PropertyApplier
[SnapDroppedInteractableProcess]: #SnapDroppedInteractableProcess
[SnappableInteractables]: #SnappableInteractables
[SnappedInteractable]: #SnappedInteractable
[SnappedInteractablesList]: #SnappedInteractablesList
[ValidCollisionRules]: #ValidCollisionRules
[ValidSnappableInteractablesList]: #ValidSnappableInteractablesList
[Methods]: #Methods
[ConfigureAutoSnap()]: #ConfigureAutoSnap
[ConfigureHighlightLogic()]: #ConfigureHighlightLogic
[ConfigurePropertyApplier()]: #ConfigurePropertyApplier
[ConfigureSnapZoneScaling()]: #ConfigureSnapZoneScaling
[ConfigureValidityRules()]: #ConfigureValidityRules
[EmitActivated(GameObject)]: #EmitActivatedGameObject
[EmitDeactivated(GameObject)]: #EmitDeactivatedGameObject
[EmitEntered(GameObject)]: #EmitEnteredGameObject
[EmitExited(GameObject)]: #EmitExitedGameObject
[EmitSnapped(GameObject)]: #EmitSnappedGameObject
[EmitUnsnapped(GameObject)]: #EmitUnsnappedGameObject
[Hide()]: #Hide
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[PrepareKinematicStateChange(GameObject)]: #PrepareKinematicStateChangeGameObject
[PrepareKinematicStateChange(InteractableFacade)]: #PrepareKinematicStateChangeInteractableFacade
[PrepareKinematicStateChange(Rigidbody)]: #PrepareKinematicStateChangeRigidbody
[ProcessOtherSnappablesOnSnap()]: #ProcessOtherSnappablesOnSnap
[Show()]: #Show
[Snap(GameObject)]: #SnapGameObject
[SnapInitialAtEndOfFrame()]: #SnapInitialAtEndOfFrame
[Unsnap()]: #Unsnap
