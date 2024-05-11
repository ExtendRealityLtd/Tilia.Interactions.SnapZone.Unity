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
  * [ApplySnapZoneScale]
  * [AutoSnapThrownObjects]
  * [Configuration]
  * [HighlightAlwaysActive]
  * [InitialSnappedInteractable]
  * [IsVisible]
  * [SnappableGameObjects]
  * [SnappedGameObject]
  * [SnapValidity]
  * [TransitionDuration]
  * [ZoneState]
* [Methods]
  * [AllowSnappedObjectGrab()]
  * [ClearSnapValidity()]
  * [OnAfterApplySnapZoneScaleChange()]
  * [OnAfterAutoSnapThrownObjectsChange()]
  * [OnAfterHighlightAlwaysActiveChange()]
  * [OnAfterSnapValidityChange()]
  * [OnAfterTransitionDurationChange()]
  * [PreventSnappedObjectGrab()]
  * [Snap(GameObject)]
  * [Snap(InteractableFacade)]
  * [ToggleSnappedObjectGrab(Boolean)]
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

#### ApplySnapZoneScale

Whether to apply the scale of the snap zone to the target that is snapped into it.

##### Declaration

```
public bool ApplySnapZoneScale { get; set; }
```

#### AutoSnapThrownObjects

Whether to auto snap a thrown GameObject into this snap zone even if the GameObject is not being held as it enters the collision area.

##### Declaration

```
public bool AutoSnapThrownObjects { get; set; }
```

#### Configuration

The linked Configurator Setup.

##### Declaration

```
public SnapZoneConfigurator Configuration { get; set; }
```

#### HighlightAlwaysActive

Whether the snap zone highlight is always active or only active when the snap zone is actively hovered in.

##### Declaration

```
public bool HighlightAlwaysActive { get; set; }
```

#### InitialSnappedInteractable

An optional InteractableFacade to snap into the snap zone when the snap zone is enabled.

##### Declaration

```
public InteractableFacade InitialSnappedInteractable { get; set; }
```

#### IsVisible

Whether the snap zone is visible or not.

##### Declaration

```
public virtual bool IsVisible { get; set; }
```

#### SnappableGameObjects

Returns the collection of GameObjects that are currently colliding with the snap zone and are valid to be snapped.

##### Declaration

```
public virtual HeapAllocationFreeReadOnlyList<GameObject> SnappableGameObjects { get; }
```

#### SnappedGameObject

Returns the currently snapped GameObject.

##### Declaration

```
public virtual GameObject SnappedGameObject { get; }
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

The state of the snap zone.

##### Declaration

```
public virtual SnapZoneFacade.SnapZoneState ZoneState { get; }
```

### Methods

#### AllowSnappedObjectGrab()

Allows the snapped object to be grabbed.

##### Declaration

```
public virtual void AllowSnappedObjectGrab()
```

#### ClearSnapValidity()

Clears [SnapValidity].

##### Declaration

```
public virtual void ClearSnapValidity()
```

#### OnAfterApplySnapZoneScaleChange()

Called after [ApplySnapZoneScale] has been changed.

##### Declaration

```
protected virtual void OnAfterApplySnapZoneScaleChange()
```

#### OnAfterAutoSnapThrownObjectsChange()

Called after [AutoSnapThrownObjects] has been changed.

##### Declaration

```
protected virtual void OnAfterAutoSnapThrownObjectsChange()
```

#### OnAfterHighlightAlwaysActiveChange()

Called after [HighlightAlwaysActive] has been changed.

##### Declaration

```
protected virtual void OnAfterHighlightAlwaysActiveChange()
```

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

#### PreventSnappedObjectGrab()

Prevents the snapped object from being grabbed.

##### Declaration

```
public virtual void PreventSnappedObjectGrab()
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

#### ToggleSnappedObjectGrab(Boolean)

Toggles the grabbed state of the snapped object.

##### Declaration

```
protected virtual void ToggleSnappedObjectGrab(bool allow)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| System.Boolean | allow | Whether to allow the snapped object to be grabbed. |

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
[ApplySnapZoneScale]: SnapZoneFacade.md#ApplySnapZoneScale
[AutoSnapThrownObjects]: SnapZoneFacade.md#AutoSnapThrownObjects
[HighlightAlwaysActive]: SnapZoneFacade.md#HighlightAlwaysActive
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
[ApplySnapZoneScale]: #ApplySnapZoneScale
[AutoSnapThrownObjects]: #AutoSnapThrownObjects
[Configuration]: #Configuration
[HighlightAlwaysActive]: #HighlightAlwaysActive
[InitialSnappedInteractable]: #InitialSnappedInteractable
[IsVisible]: #IsVisible
[SnappableGameObjects]: #SnappableGameObjects
[SnappedGameObject]: #SnappedGameObject
[SnapValidity]: #SnapValidity
[TransitionDuration]: #TransitionDuration
[ZoneState]: #ZoneState
[Methods]: #Methods
[AllowSnappedObjectGrab()]: #AllowSnappedObjectGrab
[ClearSnapValidity()]: #ClearSnapValidity
[OnAfterApplySnapZoneScaleChange()]: #OnAfterApplySnapZoneScaleChange
[OnAfterAutoSnapThrownObjectsChange()]: #OnAfterAutoSnapThrownObjectsChange
[OnAfterHighlightAlwaysActiveChange()]: #OnAfterHighlightAlwaysActiveChange
[OnAfterSnapValidityChange()]: #OnAfterSnapValidityChange
[OnAfterTransitionDurationChange()]: #OnAfterTransitionDurationChange
[PreventSnappedObjectGrab()]: #PreventSnappedObjectGrab
[Snap(GameObject)]: #SnapGameObject
[Snap(InteractableFacade)]: #SnapInteractableFacade
[ToggleSnappedObjectGrab(Boolean)]: #ToggleSnappedObjectGrabBoolean
[Unsnap()]: #Unsnap
