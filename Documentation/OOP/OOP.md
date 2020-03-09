# Object-oriented Programing (OOP)

OOP it's a programming paradigm based on the concept of **objects**, witch can contain data/state, in the form of **attributes or properties** and behaviors in the form of **methods**.

Abstract example:

Imagine the object "Led Lamp", a simple led lamp used to illuminate rooms, the led lamp has some attributes:
* Illumination capacity.
* Energy consume.
* Light Color.
* It's on?

Also the led lamp has two behaviors:
* Turn on.
* Turn off.

If we execute the method "Turn on", the state "It's on" will be changed to true, in other way if we execute the method "turn off" the state "It's on" will be changed to false.

Now the same example with code:

```C#
public class LedLamp
{
    public LedLamp(int illuminationCapacity, int energyConsume, string lightColor) 
    {
        this.illuminationCapacity = illuminationCapacity;
        this.energyConsume = energyConsume;
        this.lightColor = lightColor;
        this.isOn = false;               
    }
    
    private int illuminationCapacity;

    private int energyConsume;

    private string lightColor;
    public string GetLightColor()
    {
        return lightColor;
    }
    
    private bool isOn;
    public bool GetIsOn()
    {
        return isOn;
    }

    public void TurnOn()
    {
        this.IsOn = true;
    }

    public void TurnOff()
    {
        this.IsOn = false;
    }
}
```

Latter we will go deeper on the code used on this example.

## Concepts

* **Object**
    - The object represents a logical entity that can **reflects or not an real world object**, in our example, the logical object "LedLamp" reflects the attributes and behaviors of the real world object "Led Lamp", also an object.
* **Class**
    - The Class represents an blueprint of the object, it's like an schema that's has the instructions for the construction of the object, has the attributes names and types, and the behaviors implementations (the instructions to what the object will do when the behavior it's executed).
* **Attributes** 
    - Represents the stats (data) of the object, this attributes can be modified by methods, some attributes can be externalized to be seen outside the object. In our example the "Is On?" and "Light Color" can be seen outside the lamp, but the attributes  "Illumination Capacity" and "Energy Consume" cannot be verified just looking to the lamp, this last two are **private** and doesn't has any methods to retrieve them from out side the object.
    - By definition attributes must be **private** and can only be accessed by special methods called Gets and Sets (See *encapsulation* concept).
    - Gets and Sets: are special methods that expose attributes of an object, the get method externalize the attribute, and the set method that permit that external elements retrieve and modify the object attributes, an attribute can have Get and/or Set or neither.
* **Methods**
    - 


