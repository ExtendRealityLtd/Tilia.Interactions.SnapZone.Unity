# Class ActivationValidator

Determines if the collided SnapZone is valid for activation based on whether another SnapZone is already holding the activated state.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [activatingZoneListeners]
  * [currentActivatingGameObject]
  * [currentActivatingInteractable]
  * [currentZoneListeners]
  * [Validated]
* [Properties]
  * [Facade]
  * [IsActivated]
* [Methods]
  * [Activate(GameObject)]
  * [AttemptReactivation(GameObject, SnapZoneActivator)]
  * [CancelAttemptReactivation(GameObject, SnapZoneActivator)]
  * [ClearInvalidSnapZoneCollisions(InteractableFacade, ref List<GameObject>)]
  * [Deactivate(GameObject)]
  * [TryGetInteractable(GameObject)]
  * [TrySetInteractableFacade(GameObject)]

## Details

##### Inheritance

* System.Object
* ActivationValidator

##### Namespace

* [Tilia.Interactions.SnapZone]

##### Syntax

```
public class ActivationValidator : MonoBehaviour
```

### Fields

#### activatingZoneListeners

A collection of listeners registered with the SnapZone that is being activated by a given interactable GameObject.

##### Declaration

```
protected Dictionary<ActivationValidator.ListenerKey, UnityAction<GameObject>> activatingZoneListeners
```

#### currentActivatingGameObject

The GameObject that is currently activating this SnapZone.

##### Declaration

```
protected GameObject currentActivatingGameObject
```

#### currentActivatingInteractable

The InteractableFacade associated to the GameObject that is currently activating this SnapZone.

##### Declaration

```
protected InteractableFacade currentActivatingInteractable
```

#### currentZoneListeners

A collection of listeners registered with this SnapZone.

##### Declaration

```
protected Dictionary<ActivationValidator.ListenerKey, UnityAction<GameObject>> currentZoneListeners
```

#### Validated

Emitted when the SnapZone activation is validated.

##### Declaration

```
public ActivationValidator.UnityEvent Validated
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public SnapZoneFacade Facade { get; protected set; }
```

#### IsActivated

Determines if the SnapZone is currently activated.

##### Declaration

```
public bool IsActivated { get; protected set; }
```

### Methods

#### Activate(GameObject)

Attempts to activate the SnapZone if the colliding GameObject is not already activating another SnapZone.

##### Declaration

```
public virtual void Activate(GameObject activator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | activator | The colliding interactable. |

#### AttemptReactivation(GameObject, SnapZoneActivator)

Attempts activate this SnapZone with the given GameObject.

##### Declaration

```
protected virtual void AttemptReactivation(GameObject activator, SnapZoneActivator activatingZone)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | activator | The colliding interactable. |
| [SnapZoneActivator] | activatingZone | The SnapZone that was previously being activated by the colliding interactable. |

#### CancelAttemptReactivation(GameObject, SnapZoneActivator)

Cancels the attempt to activate the SnapZone upon the previous activating SnapZone becoming deactivated.

##### Declaration

```
protected virtual void CancelAttemptReactivation(GameObject activator, SnapZoneActivator activatingZone)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | activator | The colliding interactable. |
| [SnapZoneActivator] | activatingZone | The SnapZone that was previously being activated by the colliding interactable. |

#### ClearInvalidSnapZoneCollisions(InteractableFacade, ref List<GameObject>)

Clears any invalid SnapZone collision that still may be stored on the activating Interactable.

##### Declaration

```
protected virtual void ClearInvalidSnapZoneCollisions(InteractableFacade interactable, ref List<GameObject> invalidCollisions)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The activating interactable. |
| System.Collections.Generic.List<GameObject\> | invalidCollisions | The collection of invalid SnapZone collisions. |

#### Deactivate(GameObject)

Attempts to Deactivate the SnapZone if it is already activated.

##### Declaration

```
public virtual void Deactivate(GameObject deactivator)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | deactivator | The interactable that is no longer colliding with the SnapZone. |

#### TryGetInteractable(GameObject)

Attempts to retrieve the InteractableFacade associated with the given valid snappable GameObject.

##### Declaration

```
protected virtual InteractableFacade TryGetInteractable(GameObject container)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | container | The colliding interactable. |

##### Returns

| Type | Description |
| --- | --- |
| InteractableFacade | The interactable associated with the snappable object. |

#### TrySetInteractableFacade(GameObject)

Attempts to set the cache for the InteractableFacade associated with the given valid snappable GameObject.

##### Declaration

```
protected virtual void TrySetInteractableFacade(GameObject container)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| GameObject | container | The colliding interactable. |

[Tilia.Interactions.SnapZone]: README.md
[ActivationValidator.ListenerKey]: ActivationValidator.ListenerKey.md
[ActivationValidator.UnityEvent]: ActivationValidator.UnityEvent.md
[SnapZoneFacade]: SnapZoneFacade.md
[SnapZoneActivator]: SnapZoneActivator.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[activatingZoneListeners]: #activatingZoneListeners
[currentActivatingGameObject]: #currentActivatingGameObject
[currentActivatingInteractable]: #currentActivatingInteractable
[currentZoneListeners]: #currentZoneListeners
[Validated]: #Validated
[Properties]: #Properties
[Facade]: #Facade
[IsActivated]: #IsActivated
[Methods]: #Methods
[Activate(GameObject)]: #ActivateGameObject
[AttemptReactivation(GameObject, SnapZoneActivator)]: #AttemptReactivationGameObject-SnapZoneActivator
[CancelAttemptReactivation(GameObject, SnapZoneActivator)]: #CancelAttemptReactivationGameObject-SnapZoneActivator
[ClearInvalidSnapZoneCollisions(InteractableFacade, ref List<GameObject>)]: #ClearInvalidSnapZoneCollisionsInteractableFacade-ref List<GameObject>
[Deactivate(GameObject)]: #DeactivateGameObject
[TryGetInteractable(GameObject)]: #TryGetInteractableGameObject
[TrySetInteractableFacade(GameObject)]: #TrySetInteractableFacadeGameObject
