# MVC.NetMinyaITISummer2026AugustD05

# 🔷 ASP.NET Core MVC – State Management, Model Binding, Layout, Partial Views & Routing (.NET 9)

This project demonstrates **State Management, Model Binding, Layout, Partial Views & Routing**:

- ✅ ASP.NET Core **State Management**
  - TempData
  - Session
  - Cookies

- ✅ ASP.NET Core **Model Binding**
  - Primitive Types
  - Arrays
  - Collections
  - Complex Types
  - Bind Attribute
  - FromRoute & FromQuery

- ✅ ASP.NET Core **Layout**
  - Shared Layout
  - `_Layout.cshtml`
  - Navigation & Footer

- ✅ ASP.NET Core **Partial Views**
  - Reusable UI Components
  - Passing Models to Partial Views
  - Shared Partial Views

- ✅ ASP.NET Core **Routing**
  - Conventional Routing
  - Attribute-Based Routing
  - Custom Routes

---

# 📌 State Management

State Management allows you to store and retrieve data across HTTP requests.

---

## 1️⃣ TempData

### 🔹 Definition
- Stores data for **one redirect request**
- Uses Session internally
- Automatically removes data after it is read (unless kept)

### ✅ Example

```csharp
public IActionResult SetTempData()
{
    TempData["Message"] = "Hello from TempData";
    return Content("TempData Saved");
}
```

### 🔹 Normal Read (Removes Data)

```csharp
public IActionResult GetTempData1()
{
    string? message = TempData["Message"]?.ToString();
    return Content(message ?? "No message");
}
```

### 🔹 Peek (Does NOT Remove)

```csharp
string? message = TempData.Peek("Message")?.ToString();
```

### 🔹 Keep (Preserve After Read)

```csharp
string? message = TempData["Message"]?.ToString();
TempData.Keep("Message");
```

---

## 2️⃣ Session

### 🔹 Definition
- Stores data until session expires
- Stored server-side
- Requires Session middleware

### ✅ Example

```csharp
public IActionResult SetSession()
{
    HttpContext.Session.SetString("Message", "Hello from Session");
    HttpContext.Session.SetInt32("Age", 42);
    return Content("Session Saved");
}
```

```csharp
public IActionResult GetSession()
{
    string? message = HttpContext.Session.GetString("Message");
    int? age = HttpContext.Session.GetInt32("Age");
    return Content($"Message: {message}, Age: {age}");
}
```

---

## 3️⃣ Cookies

### 🔹 Definition
- Stored client-side (Browser)
- Can have expiration time
- Can be HttpOnly (secure)

### ✅ Example

```csharp
public IActionResult SetCookie()
{
    CookieOptions cookieOptions = new CookieOptions
    {
        Expires = DateTimeOffset.UtcNow.AddHours(10),
        HttpOnly = true,
        IsEssential = true
    };

    Response.Cookies.Append("Message", "Hello From Cookie", cookieOptions);
    return Content("Cookie Saved");
}
```

```csharp
public IActionResult GetCookie()
{
    string? message = Request.Cookies["Message"];
    return Content($"Message: {message}");
}
```

---

# 📌 Model Binding

## 🔹 Definition

Model Binding maps data from:
- Route
- Query String
- Form Data
- Body

Into action method parameters automatically.

---

# 1️⃣ Primitive Model Binding

### Example 1

URL:
```
~/ModelBinding/PrimitiveModelBinding1?id=42
```

```csharp
public IActionResult PrimitiveModelBinding1(int id)
{
    return Content($"Received Id: {id}");
}
```

---

### Example 2 (Different Parameter Name)

```
~/ModelBinding/PrimitiveModelBinding2?empId=42
```

```csharp
public IActionResult PrimitiveModelBinding2(int empId)
{
    return Content($"Received Id: {empId}");
}
```

---

# 2️⃣ Multiple Parameters

```
~/ModelBinding/PrimitiveModelBinding3?empId=42&name=Ahmed
```

```csharp
public IActionResult PrimitiveModelBinding3(int empId, string name)
{
    return Content($"Received Id: {empId}, Name: {name}");
}
```

---

# 3️⃣ Array Model Binding

```
~/ModelBinding/ArrayModelBinding4?empId=45&colors=red&colors=blue
```

```csharp
public IActionResult ArrayModelBinding4(int empId, string[] colors)
{
    return Content($"Received Id: {empId}, Colors: {string.Join(", ", colors)}");
}
```

---

# 4️⃣ Dictionary / Collection Binding

```
~/ModelBinding/CollectionsModelBinding5?phones[ahmed]=12&phones[ali]=456
```

```csharp
public IActionResult CollectionsModelBinding5(Dictionary<string, int> phones)
{
    return Content($"Received Phones: {string.Join(", ", phones.Select(p => $"{p.Key}: {p.Value}"))}");
}
```

---

# 5️⃣ Complex Type Model Binding

### Department Model

```csharp
public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
}
```

---

### Example

```
~/ModelBinding/ComplexModelBinding5?id=5&name=HR
```

```csharp
public IActionResult ComplexModelBinding5(Department department)
{
    return Content($"Received Department: {department.Name}, Id: {department.Id}");
}
```

---

# 6️⃣ Nested Complex Model Binding

```
~/ModelBinding/ComplexModelBinding7?id=5&name=HR&employees[0].name=Ahmed
```

Model binder automatically binds nested Employees collection.

---

# 7️⃣ Bind Attribute (Security)

Prevents Over-Posting Attack

```csharp
public IActionResult ComplexModelBinding8(
    [Bind(include:"Id, Name")] Department department)
{
    return Content($"Received Department: {department.Name}");
}
```

---

# 8️⃣ FromRoute

```csharp
public IActionResult PrimitiveModelBinding9([FromRoute] int id)
{
    return Content($"Received Id: {id}");
}
```

---

# 9️⃣ FromQuery

```csharp
public IActionResult PrimitiveModelBinding10([FromQuery] int id)
{
    return Content($"Received Id: {id}");
}
```

---

# 📌 Layout

## 🔹 Definition

A **Layout** provides a shared structure for multiple Razor Views.
It helps avoid repeating common HTML such as:

- Navigation bar
- Header
- Footer
- CSS references
- JavaScript references

The default shared layout is located at:

```
Views
└── Shared
    |── _Layout.cshtml
    └── _MyCustomLayout.cshtml
```

---

### ✅ Example

```cshtml
<!DOCTYPE html>
<html>
<head>
    <title>@ViewData["Title"]</title>
</head>

<body>

    <header>
        <!-- Navigation -->
    </header>

    <main>
        @RenderBody()
    </main>

    <footer>
        <!-- Footer -->
    </footer>

</body>
</html>
```

---

### 🔹 RenderBody

```cshtml
@RenderBody()
```

`RenderBody()` renders the content of the current View inside the Layout.

---

# 📌 Partial Views

## 🔹 Definition

**Partial Views** are reusable Razor Views that can be rendered inside other Views.
They are useful for:

- Reusable UI components
- Reducing duplicated markup
- Separating complex Views
- Displaying reusable data sections

```
Views
└── Employee
    └── _EmployeeDetailsPartial.cshtml
```

---

### 🔹 Partial View

```cshtml
@model Employee

<div class="card">
    <h4>@Model.Name</h4>
    <p>Age: @Model.Age</p>
    <p>Salary: @Model.Salary</p>
</div>
```

---

### 🔹 Render Partial View

```cshtml
<partial name="_EmployeePartial" model="@employee" />
```

---

### 🔹 Render Partial View with a Collection

```cshtml
@foreach (var employee in Model)
{
    <partial name="_EmployeeDetailsPartial" model="employee" />
}
```

---

# 📌 Routing

## 🔹 Definition

**Routing** determines which Controller and Action should handle an incoming HTTP request.
ASP.NET Core MVC supports different routing approaches.

---

## 1️⃣ Conventional Routing

Conventional routing defines a general routing pattern.

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Example URL:

```
/Employee/Details/5
```

This maps to:

```
Controller → EmployeeController
Action     → Details
id         → 5
```

---

## 2️⃣ Attribute-Based Routing

Routes can be defined directly on Controllers and Actions using attributes.

```csharp
[Route("employees")]
public class EmployeeController : Controller
{
    [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        return Content($"Employee Id: {id}");
    }
}
```

Example URL:

```
/employees/details/5
```

---

## 3️⃣ Custom Routes

You can define custom routes based on application requirements.

```csharp
[Route("company/employees/{id}")]
public IActionResult EmployeeDetails(int id)
{
    return Content($"Employee Id: {id}");
}
```

Example URL:

```
/company/employees/5
```

---

# 🔥 Key Learning Points

✅ TempData → One redirect only  
✅ Session → Stored until session expires  
✅ Cookies → Stored in browser  
✅ Model Binding automatically maps request data  
✅ Supports primitive, array, dictionary & complex types  
✅ [Bind] prevents over-posting  
✅ [FromRoute] & [FromQuery] control binding source  
✅ Layout provides a shared page structure  
✅ `_Layout.cshtml` reduces duplicated HTML  
✅ `RenderBody()` injects the current View into the Layout  
✅ Partial Views create reusable UI components  
✅ Partial Views support passing models (single or collection)  
✅ Conventional Routing uses a general `{controller}/{action}/{id?}` pattern  
✅ Attribute-Based Routing defines routes directly on Controllers/Actions  
✅ Custom Routes allow flexible, application-specific URL patterns  

---

# 🧠 Summary

ASP.NET Core MVC provides powerful features for building structured web applications.

This project demonstrates:

- State Management
- Model Binding
- Layouts
- Partial Views
- Routing

Together, these concepts help build MVC applications with:

- Clean Controllers
- Reusable Views
- Strongly Typed Data
- Flexible Routing
- Maintainable UI
- Efficient HTTP request handling

---

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer

---