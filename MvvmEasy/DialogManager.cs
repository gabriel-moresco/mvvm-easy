using System;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace MvvmEasy
{
    public static class DialogManager
    {
        public static bool? ShowDialog(DialogViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel), $"{nameof(viewModel)} cannot be null.");
            }

            Type viewModelType = viewModel.GetType();
            string viewTypeName = viewModelType.Name.Replace("ViewModel", "View");

            Type viewType = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(o => o.Name == viewTypeName);

            if (viewType == null)
            {
                throw new InvalidOperationException($"A view named \"{viewTypeName}\" cannot be found.");
            }

            Window view = Activator.CreateInstance(viewType) as Window;

            viewModel.AttachedWindow = view ?? throw new InvalidCastException($"The type \"{viewTypeName}\" is not a Window.");

            view.DataContext = viewModel;
            return view.ShowDialog();
        }
    }
}
