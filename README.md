## Naming Conventions

### PascalCase 
Used for:
- Public methods, properties
- Class names
- Namespace names
- Enum types.

### Class example
```csharp
class Person {
    public string FirstName { get; set; }
    public void PrintName() { }
}
```

### Enum example
```csharp
enum example {
    isRandom,
    isNotRandom
}
```

## Comments
Don't use comments all the time. Only when you need to.

### Example of excessive use

```csharp
int a = 5;  // Declare an integer variable 'a' and assign the value 5
int b = 3;  // Declare an integer variable 'b' and assign the value 3
int sum = a + b;  // Add 'a' and 'b' and store the result in 'sum'
Console.WriteLine(sum);  // Output the value of 'sum' to the console
```


## SOLID Principles with Code Examples

**Single Responsibility Principle (SRP)**

* **Definition:** A class should have one and only one reason to change.

* **Example:**

```csharp
// Violates SRP: The `Order` class is responsible for both processing and sending the order.
public class Order {
    public void Process() { /* ... */ }
    public void Send() { /* ... */ }
}

// Adheres to SRP: Separates responsibilities into different classes.
public class OrderProcessor {
    public void Process(Order order) { /* ... */ }
}

public class OrderSender {
    public void Send(Order order) { /* ... */ }
}
```

----
**Open-Closed Principle (OCP)**

* **Definition:** Objects or entities should be open for extension but closed for modification.

* **Example:**

```csharp
// Violates OCP: Adding a new shape requires modifying the `Shape` class.
public abstract class Shape {
    public abstract void Draw();
}

// Adheres to OCP: Introduces a new interface for drawing shapes.
public interface IShapeDrawer {
    void Draw();
}

public class Circle : IShapeDrawer {
    public void Draw() { /* ... */ }
}

public class Rectangle : IShapeDrawer {
    public void Draw() { /* ... */ }
}
```

---
**Liskov Substitution Principle (LSP)**

* **Definition:** Let q(x) be a property provable about objects of x of type T. Then q(y) should be provable for objects y of type S where S is a subtype of T.

* **Example:**

```csharp
// Violates LSP: A `Rectangle` should be able to be substituted for a `Square` without breaking the program.
public class Rectangle {
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
}

public class Square : Rectangle {
    public override int Width {
        set { base.Width = base.Height = value; }
    }

    public override int Height {
        set { base.Width = base.Height = value; }
    }
}
```

----
**Interface Segregation Principle (ISP)**

* **Definition:** A client should never be forced to implement an interface that it doesn’t use, or clients shouldn’t be forced to depend on methods they do not use.

* **Example:**

```csharp
// Violates ISP: The `IDrawable` interface forces all classes to implement `DrawText` and `DrawShape`.
public interface IDrawable {
    void DrawText(string text);
    void DrawShape();
}

// Adheres to ISP: Introduces separate interfaces for drawing text and shapes.
public interface ITextDrawable {
    void DrawText(string text);
}

public interface IShapeDrawable {
    void DrawShape();
}
```

---
**Dependency Inversion Principle (DIP)**

* **Definition:**
Entities must depend on abstractions, not on concretions. It states that the high-level module must not depend on the low-level module, but they should depend on abstractions.

* **Example:**

```csharp
// Violates DIP: The `EmailSender` directly depends on the `GmailSender` concrete class.
public class EmailSender {
    public void SendEmail(string to, string subject, string body) {
        var gmailSender = new GmailSender();
        gmailSender.Send(to, subject, body);
    }
}

// Adheres to DIP: The `EmailSender` depends on an `IEmailService` abstraction.
public interface IEmailService {
    void Send(string to, string subject, string body);
}

public class EmailSender {
    private readonly IEmailService _emailService;

    public EmailSender(IEmailService emailService) {
        _emailService = emailService;
    }

    public void SendEmail(string to, string subject, string body) {
        _emailService.Send(to, subject, body);
    }
}
```

