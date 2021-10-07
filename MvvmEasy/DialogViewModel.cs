using System.Windows;

namespace MvvmEasy
{
    public abstract class DialogViewModel : BaseViewModel
    {
        internal Window AttachedWindow { get; set; }

        public void TryClose(bool? dialogResult = null)
        {
            try
            {
                if (AttachedWindow != null)
                {
                    AttachedWindow.DialogResult = dialogResult;
                    AttachedWindow.Close();
                }
            }
            catch { }
        }
    }
}
