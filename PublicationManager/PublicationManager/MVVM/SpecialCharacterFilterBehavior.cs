using System.Linq;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace PublicationManager.MVVM
{
    public class SpecialCharacterFilterBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        }

        private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Does not allow letters to be added if they are special characters.
            e.Handled = e.Text.ToCharArray().Contains('@');
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            base.OnDetaching();
        }
    }
}
