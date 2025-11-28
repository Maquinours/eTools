using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace eTools_Ultimate.Views.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour MoverDropListDialog.xaml
    /// </summary>
    public partial class MoverDropListDialog : ContentDialog
    {
        public MoverDropListDialog(ContentPresenter? contentPresenter, Mover mover) : base(contentPresenter)
        {
            MoverDropListDialogViewModel viewModel = new(mover);
            DataContext = viewModel;

            InitializeComponent();

            CollectionChangedEventManager.AddHandler(DropListTreeView.Items, DropListTreeView_Items_CollectionChanged);

            //((INotifyCollectionChanged)DropListTreeView.Items).CollectionChanged += DropListTreeView_Items_CollectionChanged;
        }

        private void DropListTreeView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DropListTreeView.Items.Count > 0)
            {
                MoverDropTreeViewItem firstItem = DropListTreeView.Items.Cast<MoverDropTreeViewItem>().First();
                BringTreeViewItemIntoView(DropListTreeView, firstItem);
                firstItem.IsSelected = true;
            }
        }

        private void DropListTreeView_Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        if (e.NewItems is not null && e.NewItems.Count > 0)
                        {
                            IEnumerable<MoverDropTreeViewItem> newItems = e.NewItems.Cast<MoverDropTreeViewItem>();
                            MoverDropTreeViewItem lastNewItem = newItems.Last();

                            Application.Current.Dispatcher.Invoke(async () =>
                            {
                                BringTreeViewItemIntoView(DropListTreeView, lastNewItem);
                                lastNewItem.IsSelected = true;
                            }, System.Windows.Threading.DispatcherPriority.DataBind);
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        if (e.OldItems is not null && e.OldItems.Count > 0)
                        {
                            Application.Current.Dispatcher.Invoke(async () =>
                            {
                                MoverDropTreeViewItem[] items = [.. DropListTreeView.Items.Cast<MoverDropTreeViewItem>()];

                                MoverDropTreeViewItem? newSelectedItem = null;

                                if (items.Length > e.OldStartingIndex)
                                    newSelectedItem = items[e.OldStartingIndex];
                                else if (items.Length > 0)
                                    newSelectedItem = items[^1];

                                if (newSelectedItem != null)
                                {
                                    BringTreeViewItemIntoView(DropListTreeView, newSelectedItem);
                                    newSelectedItem.IsSelected = true;
                                }
                            }, System.Windows.Threading.DispatcherPriority.DataBind);
                        }
                        break;
                    }
            }

        }

        private void BringTreeViewItemIntoView(TreeView treeView, object item)
        {
            // Try to generate the ItemsPresenter and the ItemsPanel.
            // by calling ApplyTemplate.  Note that in the
            // virtualizing case even if the item is marked
            // expanded we still need to do this step in order to
            // regenerate the visuals because they may have been virtualized away.
            treeView.ApplyTemplate();
            ItemsPresenter? itemsPresenter =
                (ItemsPresenter)treeView.Template.FindName("ItemsHost", treeView);
            if (itemsPresenter != null)
            {
                itemsPresenter.ApplyTemplate();
            }
            else
            {
                // The Tree template has not named the ItemsPresenter,
                // so walk the descendents and find the child.
                itemsPresenter = FindVisualChild<ItemsPresenter>(treeView);
                if (itemsPresenter == null)
                {
                    treeView.UpdateLayout();

                    itemsPresenter = FindVisualChild<ItemsPresenter>(treeView);
                }
            }

            Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);

            // Ensure that the generator for this panel has been created.
            _ = itemsHostPanel.Children;

            if (itemsHostPanel is MyVirtualizingStackPanel virtualizingPanel)
            {
                int itemIndex = treeView.Items.Cast<object>().ToList().IndexOf(item);
                if (itemIndex != -1)
                    virtualizingPanel.BringIntoView(itemIndex);
            }
        }

        /// <summary>
        /// Search for an element of a certain type in the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of element to find.</typeparam>
        /// <param name="visual">The parent element.</param>
        /// <returns></returns>
        private T? FindVisualChild<T>(Visual visual) where T : Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    if (child is T correctlyTyped)
                        return correctlyTyped;

                    T? descendent = FindVisualChild<T>(child);

                    if (descendent != null)
                        return descendent;
                }
            }

            return null;
        }
    }

    public class MyVirtualizingStackPanel : VirtualizingStackPanel
    {
        /// <summary>
        /// Publically expose BringIndexIntoView.
        /// </summary>
        public void BringIntoView(int index)
        {

            this.BringIndexIntoView(index);
        }
    }
}
