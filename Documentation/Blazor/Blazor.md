# Blazor

## Getting started


### General

* To reference a component on colde use: @ref
    Ex.: 
        `<Component @ref="ComponentReference"><\Component>`
        and in codebehind
        `public Component componentReference { get; set; }`        
* comunicate btween componente use: EventCallback
    Ex.:
        On child component
        ```C#
            [Parameter]
            public EventCallback<bool> ExampleCallback { get; set; }
            ...
            await ExampleCallback.InvokeAsync(true);
        ```
        On parent component
        ```html
            <Component @ref="ComponentReference" 
                ExampleCallback="@ExampleCallbackHandler">
            <\Component>
        ```
### Data biding 

* One-Way
    Use: @field
    Ex: 
    ```html
    <h1>@Field</h1>
    ```

* Two-Way
    Use: @bind="@Field"
    Ex: 
    ```html
    <input @bind="@Field" />
    ```

* Two-Way OverLoad Event
    Use: @bind="@Field"
    Ex: 
    ```html
    <input @bind-value="@Field" @bind-value:event="oninput" />
    ```

* click
    Use: @onclick="Button_Click"
    ex:
    ```html
    <button @onclick="Button_Click">Click me</button>
    ```

### Form

* **EditForm**
    Ex.:
    ```html
    <EditForm Model="@Model" 
        OnValidSubmit="@HandlerValidSubmit" 
        OnInvalidSubmit="@HandlerInvalidSubmit">
        <InputText id="field" @
            bind-value="@Model.Field" 
            placeholder="enter field">
        </InputText>
    </EditForm>
    ```
**Fields:**
* InputText
* InputTextArea
* InputNumber
* InputSelect
* InputDate
* InputCheckbox

### CodeBehind Navigation

* **NavigationManager** Class

    ```c#
    [Inject]
    private NavigationManager NavigationManager {get; set;}
    ...
    NavigationManager.NavigateTo("/example")
    ...
    ```

## Validation

**Nuget: `System.ComponentModel.Annotations`**

Then annotate the model:

ex.:
```C#
[Required]
[StringLength(50, ErrorMessage="Name it's to long")]
public string Name { get; set; }

[Required]
[EmailAddress]
public string Email { get; set; }
```

Add **DataAnnotationsValidators** to the EditForm:
```html
<EditForm Model="@Model" 
        OnValidSubmit="@HandlerValidSubmit" 
        OnInvalidSubmit="@HandlerInvalidSubmit">
        <DataAnnotationsValidators\>
        <InputText id="field" @
            bind-value="@Model.Field" 
            placeholder="enter field">
        </InputText>
    </EditForm>
```

To add a summary add **ValidationSummary** to the EditForm:
```html
<EditForm Model="@Model" 
        OnValidSubmit="@HandlerValidSubmit" 
        OnInvalidSubmit="@HandlerInvalidSubmit">
        <DataAnnotationsValidators />
        <ValidationSummary />
        <InputText id="field" @
            bind-value="@Model.Field" 
            placeholder="enter field">
        </InputText>
    </EditForm>
```

And for individual component validation message add **ValidationMessage**
```html
<EditForm Model="@Model" 
        OnValidSubmit="@HandlerValidSubmit" 
        OnInvalidSubmit="@HandlerInvalidSubmit">
        <DataAnnotationsValidators\>
        <div>
            <InputText id="field" @
                bind-value="@Model.Field" 
                placeholder="enter field">
            </InputText>
            <ValidationMessage class="..." For="@(() => Model.Field)"></ValidationMessage>
        </div>
        
    </EditForm>
```

