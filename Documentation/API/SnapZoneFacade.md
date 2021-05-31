# Class SnapZoneFacade

The public interface into the Interactions SnapZone Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [Activated]
  * [Deactivated]
  * [Entered]
  * [Exited]
  * [Snapped]
  * [Unsnapped]
* [Properties]
  * [Configuration]
  * [InitialSnappedInteractable]
  * [SnappableGameObjects]
  * [SnappedGameObject]
  * [SnapValidity]
  * [TransitionDuration]
  * [ZoneState]
* [Methods]
  * [OnAfterSnapValidityChange()]
  * [OnAfterTransitionDurationChange()]
  * [Snap(GameObject)]
  * [Snap(InteractableFacade)]
  * [Unsnap()]

## Details

##### Inheritance

* System.Object
* SnapZoneFacade

##### Namespace

* [Tilia.Interactions.SnapZone]

##### Syntax

```
public class SnapZoneFacade : MonoBehaviour
```

### Fields

#### Activated

Emitted when a valid GameObject activates the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Activated
```

#### Deactivated

Emitted when a valid GameObject deactivates the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Deactivated
```

#### Entered

Emitted when a valid GameObject enters the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Entered
```

#### Exited

Emitted when a valid GameObject exits the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Exited
```

#### Snapped

Emitted when a valid GameObject is snapped to the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Snapped
```

#### Unsnapped

Emitted when a valid GameObject is unsnapped from the zone.

##### Declaration

```
public SnapZoneFacade.UnityEvent Unsnapped
```

### Properties

#### Configuration

The linked Configurator Setup.

##### Declaration

```
public SnapZoneConfigurator Configuration { get; protected set; }
```

#### InitialSnappedInteractable

An optional InteractableFacade to snap into the snap zone when the snap zone is enabled.

##### Declaration

```
public InteractableFacade InitialSnappedInteractable { get; set; }
```

#### SnappableGameObjects

Returns the collection of GameObjects that are currently colliding with the snap zone and are valid to be snapped.

##### Declaration

```
public HeapAllocationFreeReadOnlyList<GameObject> SnappableGameObjects { get; }
```

#### SnappedGameObject

Returns the currently snapped GameObject.

##### Declaration

```
public GameObject SnappedGameObject { get; }
```

#### SnapValidity

The rules that determine which GameObject can be snapped to this snap zone.

##### Declaration

```
public RuleContainer SnapValidity { get; set; }
```

#### TransitionDuration

The duration for the transition of the snapped GameObject to reach the snap zone destination.

##### Declaration

```
public float TransitionDuration { get; set; }
```

#### ZoneState

The state of the SnapZone.

##### Declaration

```
public SnapZoneFacade.SnapZoneState ZoneState { get; }
```

### Methods

#### OnAfterSnapValidityChange()

Called after [SnapValidity] has been changed.

##### Declaration

```
protected virtual void OnAfterSnapValidityChange()
```

#### OnAfterTransitionDurationChange()

Called after [TransitionDuration] has been changed.

##### Declaration

```
protected virtual void OnAfterTransitionDurationChange()
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

#### Snap(InteractableFacade)

Attempts to snap a given InteractableFacade to the snap zone.

##### Declaration

```
public virtual void Snap(InteractableFacade interactableToSnap)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactableToSnap | The interactable to attempt to snap. |

#### Unsnap()

Attempts to unsnap any existing GameObject that is currently snapped to the snap zone.

##### Declaration

```
public virtual void Unsnap()
```

[Tilia.Interactions.SnapZone]: README.md
[SnapZoneFacade.UnityEvent]: SnapZoneFacade.UnityEvent.md
[SnapZoneConfigurator]: SnapZoneConfigurator.md
[SnapZoneFacade.SnapZoneState]: SnapZoneFacade.SnapZoneState.md
[SnapValidity]: SnapZoneFacade.md#SnapValidity
[TransitionDuration]: SnapZoneFacade.md#TransitionDuration
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[Activated]: #Activated
[Deactivated]: #Deactivated
[Entered]: #Entered
[Exited]: #Exited
[Snapped]: #Snapped
[Unsnapped]: #Unsnapped
[Properties]: #Properties
[Configuration]: #Configuration
[InitialSnappedInteractable]: #InitialSnappedInteractable
[SnappableGameObjects]: #SnappableGameObjects
[SnappedGameObject]: #SnappedGameObject
[SnapValidity]: #SnapValidity
[TransitionDuration]: #TransitionDuration
[ZoneState]: #ZoneState
[Methods]: #Methods
[OnAfterSnapValidityChange()]: #OnAfterSnapValidityChange
[OnAfterTransitionDurationChange()]: #OnAfterTransitionDurationChange
[Snap(GameObject)]: #SnapGameObject
[Snap(InteractableFacade)]: #SnapInteractableFacade
[Unsnap()]: #Unsnap
