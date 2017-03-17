using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Input;

using Intepreter.Model.Abstract;


namespace Intepreter.Behavior
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseLeftButtonUp   += AssociatedObject_MouseLeftButtonUp;
            this.AssociatedObject.MouseLeave          += AssociatedObject_MouseLeave;
        }

        private void AssociatedObject_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_isMouseClicked)
            {
                IDragable dragObject = this.AssociatedObject.DataContext as IDragable;

                if (dragObject != null)
                {
                    var data = new DataObject();
                    data.SetData(dragObject.DataType, this.AssociatedObject.DataContext);
                    System.Windows.DragDrop.DoDragDrop(this.AssociatedObject, data, DragDropEffects.All);
                }
            }

            _isMouseClicked = false;
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseClicked = false;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseClicked = true;
        }

        private bool _isMouseClicked = false;
    }
}
