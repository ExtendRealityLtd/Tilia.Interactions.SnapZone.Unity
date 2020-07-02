# Class SnapZoneActivator

Holds the linked settings for a Interactions SnapZone.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Properties]
  * [Collider]
  * [CollisionTracker]
  * [Facade]

## Details

##### Inheritance

* System.Object
* SnapZoneActivator

##### Namespace

* [Tilia.Interactions.SnapZone]

##### Syntax

```
public class SnapZoneActivator : MonoBehaviour
```

### Properties

#### Collider

The [Collider] that is used to determine the collidable area for the zone.

##### Declaration

```
public Collider Collider { get; set; }
```

#### CollisionTracker

The [CollisionTracker] used for tracking collisions on the zone.

##### Declaration

```
public CollisionTracker CollisionTracker { get; protected set; }
```

#### Facade

The public interface facade.

##### Declaration

```
public SnapZoneFacade Facade { get; protected set; }
```

[Tilia.Interactions.SnapZone]: README.md
[Collider]: SnapZoneActivator.md#Collider
[CollisionTracker]: SnapZoneActivator.md#CollisionTracker
[SnapZoneFacade]: SnapZoneFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Properties]: #Properties
[Collider]: #Collider
[CollisionTracker]: #CollisionTracker
[Facade]: #Facade
