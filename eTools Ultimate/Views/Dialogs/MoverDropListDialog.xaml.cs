using eTools_Ultimate.Models.Movers;
using eTools_Ultimate.ViewModels.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            viewModel.DropAdded += ViewModel_DropAdded;
            viewModel.DropListView.CollectionChanged += ViewModel_DropListView_CollectionChanged;
        }

        private void ViewModel_DropListView_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    {
                        if (e.NewItems is not null && e.NewItems.Count > 0)
                        {
                            IEnumerable<MoverDropTreeViewItem> newItems = e.NewItems.Cast<MoverDropTreeViewItem>();
                            MoverDropTreeViewItem lastNewItem = newItems.Last();

                            Application.Current.Dispatcher.Invoke(async () =>
                            {
                                GetTreeViewItem(DropListTreeView, lastNewItem);
                                lastNewItem.IsSelected = true;
                                //DropListTreeView.Items.Cast<MoverDropTreeViewItem>().ToList().ForEach(item => item.IsExpanded = true);
                            }, System.Windows.Threading.DispatcherPriority.DataBind);
                        }
                        break;
                    }
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    {
                        if(e.OldItems is not null && e.OldItems.Count > 0)
                        {
                            Application.Current.Dispatcher.Invoke(async () =>
                            {
                                MoverDropTreeViewItem[] items = [..DropListTreeView.Items.Cast<MoverDropTreeViewItem>()];

                                MoverDropTreeViewItem? newSelectedItem = null;

                                if (items.Length > e.OldStartingIndex)
                                    newSelectedItem = items[e.OldStartingIndex];
                                else if (items.Length > 0)
                                    newSelectedItem = items[^1];

                                if (newSelectedItem != null)
                                {
                                    GetTreeViewItem(DropListTreeView, newSelectedItem);
                                    newSelectedItem.IsSelected = true;
                                }
                            }, System.Windows.Threading.DispatcherPriority.DataBind);
                        }
                        break;
                    }
            }
            
        }

        private void ViewModel_DropAdded(object? sender, DropAddedEventArgs e)
        {
            //Application.Current.Dispatcher.Invoke(async () =>
            //{
            //    GetTreeViewItem(DropListTreeView, e.DropTreeItem);
            //    e.DropTreeItem.IsSelected = true;
            //}, System.Windows.Threading.DispatcherPriority.Render);
        }

        private System.Windows.Controls.TreeViewItem? GetTreeViewItem(TreeView treeView, object item)
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
            UIElementCollection children = itemsHostPanel.Children;

            if (itemsHostPanel is MyVirtualizingStackPanel virtualizingPanel)
            {
                int itemIndex = treeView.Items.Cast<object>().ToList().IndexOf(item);
                if (itemIndex != -1)
                {
                    virtualizingPanel.BringIntoView(itemIndex);
                    return (System.Windows.Controls.TreeViewItem)treeView.ItemContainerGenerator.
                            ContainerFromIndex(itemIndex);
                }
            }

            return null;
        }

        /// <summary>
        /// Recursively search for an item in this subtree.
        /// </summary>
        /// <param name="container">
        /// The parent ItemsControl. This can be a TreeView or a TreeViewItem.
        /// </param>
        /// <param name="item">
        /// The item to search for.
        /// </param>
        /// <returns>
        /// The TreeViewItem that contains the specified item.
        /// </returns>
        //private System.Windows.Controls.TreeViewItem? GetTreeViewItem(ItemsControl container, object item)
        //{
        //    if (container != null)
        //    {
        //        if (container.DataContext == item)
        //        {
        //            return container as System.Windows.Controls.TreeViewItem;
        //        }

        //        // Expand the current container
        //        if (container is System.Windows.Controls.TreeViewItem && !((System.Windows.Controls.TreeViewItem)container).IsExpanded)
        //        {
        //            container.SetValue(System.Windows.Controls.TreeViewItem.IsExpandedProperty, true);
        //        }

        //        // Try to generate the ItemsPresenter and the ItemsPanel.
        //        // by calling ApplyTemplate.  Note that in the
        //        // virtualizing case even if the item is marked
        //        // expanded we still need to do this step in order to
        //        // regenerate the visuals because they may have been virtualized away.

        //        container.ApplyTemplate();
        //        ItemsPresenter? itemsPresenter =
        //            (ItemsPresenter)container.Template.FindName("ItemsHost", container);
        //        if (itemsPresenter != null)
        //        {
        //            itemsPresenter.ApplyTemplate();
        //        }
        //        else
        //        {
        //            // The Tree template has not named the ItemsPresenter,
        //            // so walk the descendents and find the child.
        //            itemsPresenter = FindVisualChild<ItemsPresenter>(container);
        //            if (itemsPresenter == null)
        //            {
        //                container.UpdateLayout();

        //                itemsPresenter = FindVisualChild<ItemsPresenter>(container);
        //            }
        //        }

        //        Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);

        //        // Ensure that the generator for this panel has been created.
        //        UIElementCollection children = itemsHostPanel.Children;

        //        MyVirtualizingStackPanel? virtualizingPanel =
        //            itemsHostPanel as MyVirtualizingStackPanel;

        //        for (int i = 0, count = container.Items.Count; i < count; i++)
        //        {
        //            System.Windows.Controls.TreeViewItem subContainer;
        //            if (virtualizingPanel != null)
        //            {
        //                // Bring the item into view so
        //                // that the container will be generated.
        //                virtualizingPanel.BringIntoView(i);

        //                subContainer =
        //                    (System.Windows.Controls.TreeViewItem)container.ItemContainerGenerator.
        //                    ContainerFromIndex(i);
        //            }
        //            else
        //            {
        //                subContainer =
        //                    (System.Windows.Controls.TreeViewItem)container.ItemContainerGenerator.
        //                    ContainerFromIndex(i);

        //                // Bring the item into view to maintain the
        //                // same behavior as with a virtualizing panel.
        //                subContainer.BringIntoView();
        //            }

        //            if (subContainer != null)
        //            {
        //                // Search the next level for the object.
        //                System.Windows.Controls.TreeViewItem? resultContainer = GetTreeViewItem(subContainer, item);
        //                if (resultContainer != null)
        //                {
        //                    return resultContainer;
        //                }
        //                else
        //                {
        //                    // The object is not under this TreeViewItem
        //                    // so collapse it.
        //                    subContainer.IsExpanded = false;
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}

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
                    T? correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    T? descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }

        public static System.Windows.Controls.TreeViewItem? FindTviFromObjectRecursive(ItemsControl ic, object o)
        {
            //Search for the object model in first level children (recursively)
            System.Windows.Controls.TreeViewItem? tvi = ic.ItemContainerGenerator.ContainerFromItem(o) as System.Windows.Controls.TreeViewItem;
            if (tvi != null) return tvi;
            //Loop through user object models
            foreach (object i in ic.Items)
            {
                //Get the TreeViewItem associated with the iterated object model
                System.Windows.Controls.TreeViewItem? tvi2 = ic.ItemContainerGenerator.ContainerFromItem(i) as System.Windows.Controls.TreeViewItem;
                if (tvi2 is null) continue;

                tvi = FindTviFromObjectRecursive(tvi2, o);
                if (tvi != null) return tvi;
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
