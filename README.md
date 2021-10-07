# MVVM Easy

[![nuget badge](https://img.shields.io/nuget/v/MvvmEasy?logo=NuGet&style=for-the-badge)](https://www.nuget.org/packages/MvvmEasy)
[![nuget downloads badge](https://img.shields.io/nuget/dt/MvvmEasy?logo=NuGet&style=for-the-badge)](https://www.nuget.org/packages/MvvmEasy)
[![license badge](https://img.shields.io/github/license/gabriel-moresco/mvvm-easy?style=for-the-badge)](./LICENSE.txt)

An easy MVVM framework to use in your WPF applications.

## Usage

### Properties

Inherit your ViewModels that are not Dialogs from `BaseViewModel` to notify binded property changes.

```cs
public class MainViewModel : BaseViewModel
{
    private string _test;
    public string Test
    {
        get => _test;
        set
        {
            _test = value;
            OnPropertyChanged();
        }
    }
}
```

### Commands

The `DelegateCommand` class provide a mechanism to bind Commands and Events from view to viewmodel.

```cs
public class MainViewModel : BaseViewModel
{
    public DelegateCommand TestCommand => new DelegateCommand(Test);
    
    private void Test(object parameter)
    {
        //do something...
    }
}
```

You can also use a method Can to determine when a Command can be executed.

```cs
public class MainViewModel : BaseViewModel
{
    public DelegateCommand TestCommand => new DelegateCommand(Test, CanTest);
    
    private void Test(object parameter)
    {
        //do something...
    }
    
    private bool CanTest()
    {
        return true;
    }
}
```

### Dialog Manager

The `DialogManager` static class allows opening Windows (dialogs) that the corresponding ViewModel inherits from `DialogViewModel`.

#### Dialog ViewModel:
```cs
public class SampleViewModel : DialogViewModel
{
}
```

#### Showing the Dialog:
```cs
public class MainViewModel : BaseViewModel
{
    private void ShowExempleDialog()
    {
        bool? dialogResult = DialogManager.ShowDialog(new SampleViewModel());
    }
}
```

In this case, the `ShowDialog` method will look for the name of a View that matches the name of the ViewModel by replacing the word "ViewModel" with "View".
ViewModel `SampleViewModel` matches `SampleView` dialog.
