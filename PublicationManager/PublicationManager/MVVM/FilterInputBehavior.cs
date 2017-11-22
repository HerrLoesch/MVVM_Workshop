using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace PublicationManager.MVVM
{
    public class FilterInputBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
            base.OnDetaching();
        }

        private void AssociatedObjectOnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            keyEventArgs.Handled = keyEventArgs.Key == Key.A;
        }
    }
}
