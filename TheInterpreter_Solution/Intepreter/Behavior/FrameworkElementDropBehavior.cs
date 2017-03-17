using System;
using System.Windows;
using System.Windows.Interactivity;
using Intepreter.Model.Abstract;

namespace Intepreter.Behavior 
{
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.AllowDrop = true;
            this.AssociatedObject.DragEnter += AssociatedObject_DragEnter;
            this.AssociatedObject.DragOver += AssociatedObject_DragOver;
            this.AssociatedObject.DragLeave += AssociatedObject_DragLeave;
            this.AssociatedObject.Drop += AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (_dataType != null)
            {
                //if the data type can be dropped 
                if (e.Data.GetDataPresent(_dataType))
                {
                    //drop the data
                    IDropable target = this.AssociatedObject.DataContext as IDropable;
                    target.Drop(e.Data.GetData(_dataType));

                    //remove the data from the source
                    IDragable source = e.Data.GetData(_dataType) as IDragable;
                }
            }

            if (this.adorner != null)
            {
                this.adorner.Remove();
            }

            e.Handled = true;
        }

        private void AssociatedObject_DragLeave(object sender, DragEventArgs e)
        {
            if (this.adorner != null)
            {
                this.adorner.Remove();
            }

            e.Handled = true;
        }

        private void AssociatedObject_DragOver(object sender, DragEventArgs e)
        {
            if (_dataType != null)
            {
                if (e.Data.GetDataPresent(_dataType))
                {
                    this.SetDragDropEffects(e);

                    if (this.adorner != null)
                    {
                        this.adorner.Update();
                    }    
                }
            }
        }

        private void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (this._dataType == null)
            {
                if (this.AssociatedObject.DataContext != null)
                {
                    var dropObject = this.AssociatedObject.DataContext as IDropable;

                    if (dropObject != null)
                    {
                        this._dataType = dropObject.DataType;
                    }
                }
            }

            if (this.adorner == null)
            {
                this.adorner = new FrameworkElementAdorner(sender as UIElement);
            }

            e.Handled = true;
        }

        private void SetDragDropEffects(DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            if (e.Data.GetDataPresent(_dataType))
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        private Type _dataType;
        private FrameworkElementAdorner adorner;
    }
}
