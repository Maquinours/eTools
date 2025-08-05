using eTools_Ultimate.Models;
using eTools_Ultimate.Services;
using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace eTools_Ultimate.Helpers
{
    public class TerrainsTreeViewDropHandler : IDropTarget
    {
        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is not ITerrainItem sourceItem)
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::DragOver : dropInfo.Data is not ITerrainItem");
            if(dropInfo.TargetItem is not ITerrainItem targetItem)
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::DragOver : dropInfo.TargetItem is not ITerrainItem");

            if (sourceItem == targetItem || (sourceItem is TerrainBrace sourceBrace && sourceBrace.IsAncestorOf(targetItem)))
                return;

            if (targetItem is TerrainBrace && (dropInfo.InsertPosition & RelativeInsertPosition.TargetItemCenter) != 0)
            {
                dropInfo.Effects = DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            }
            else if(dropInfo.InsertPosition == RelativeInsertPosition.BeforeTargetItem || dropInfo.InsertPosition == RelativeInsertPosition.AfterTargetItem)
            {
                dropInfo.Effects = DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }
        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.Data is not ITerrainItem sourceItem)
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop : dropInfo.Data is not ITerrainItem");
            if (dropInfo.TargetItem is not ITerrainItem targetItem)
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop : dropInfo.TargetItem is not ITerrainItem");

            ObservableCollection<ITerrainItem> sourceCollection = 
                dropInfo.DragInfo.SourceCollection as ObservableCollection<ITerrainItem> ??
                (dropInfo.DragInfo.SourceCollection as ICollectionView)?.SourceCollection as ObservableCollection<ITerrainItem> ??
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop exception : Unable to find an ObservableCollection source");

            ObservableCollection <ITerrainItem> targetCollection =
                dropInfo.TargetCollection as ObservableCollection<ITerrainItem> ??
                (dropInfo.TargetCollection as ICollectionView)?.SourceCollection as ObservableCollection<ITerrainItem> ??
                (dropInfo.TargetCollection as ItemCollection)?.SourceCollection as ObservableCollection<ITerrainItem> ??
                throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop exception : Unable to find an ObservableCollection target");

            if (sourceItem == targetItem || (sourceItem is TerrainBrace sourceBrace && sourceBrace.IsAncestorOf(targetItem)))
                return;

            sourceCollection.Remove(sourceItem);
            targetCollection.Insert(dropInfo.InsertIndex, sourceItem);
            //if (targetItem is TerrainBrace && (dropInfo.InsertPosition & RelativeInsertPosition.TargetItemCenter) != 0)
            //{
            //    sourceCollection.Remove(sourceItem);
            //    targetCollection.Insert(dropInfo.InsertIndex, sourceItem);
            //    //dropInfo.DragInfo.SourceCollection
            //    //TerrainBrace? currentParent = TerrainsService.Instance.GetItemParent(sourceItem);
            //    //if (currentParent == null) TerrainsService.Instance.TerrainItems.Remove(sourceItem);
            //    //else currentParent.Children.Remove(sourceItem);

            //    //targetBrace.Children.Insert(dropInfo.InsertIndex, sourceItem);
            //}

            //targetCollection.Add(item);
        }
    }
}
