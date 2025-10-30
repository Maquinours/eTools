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
            //if (dropInfo.Data is not ITerrainItem sourceItem)
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::DragOver : dropInfo.Data is not ITerrainItem");

            //if (dropInfo.TargetItem is not null and not ITerrainItem)
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::DragOver : dropInfo.TargetItem is neither ITerrainItem nor null");

            //ITerrainItem? targetItem = dropInfo.TargetItem as ITerrainItem;

            //ObservableCollection<ITerrainItem> sourceCollection =
            //    dropInfo.DragInfo.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    (dropInfo.DragInfo.SourceCollection as ICollectionView)?.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop exception : Unable to find an ObservableCollection source");

            //if (targetItem != null && (sourceItem == targetItem || (sourceItem is TerrainBrace sourceBrace && sourceBrace.IsAncestorOf(targetItem))))
            //    return;

            //if (targetItem is TerrainBrace && (dropInfo.InsertPosition & RelativeInsertPosition.TargetItemCenter) != 0)
            //{
            //    dropInfo.Effects = DragDropEffects.Move;
            //    dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            //}
            //else if(dropInfo.InsertPosition == RelativeInsertPosition.BeforeTargetItem || dropInfo.InsertPosition == RelativeInsertPosition.AfterTargetItem)
            //{
            //    if (dropInfo.DragInfo.SourceCollection == dropInfo.TargetCollection)
            //    {
            //        int sourceIndex = sourceCollection.IndexOf(sourceItem);
            //        int insertIndex = dropInfo.DragInfo.SourceCollection == dropInfo.TargetCollection && sourceIndex < dropInfo.UnfilteredInsertIndex ? dropInfo.UnfilteredInsertIndex - 1 : dropInfo.UnfilteredInsertIndex;
            //        if (insertIndex == sourceIndex) 
            //            return;
            //    }
            //    dropInfo.Effects = DragDropEffects.Move;
            //    dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            //}
        }
        public void Drop(IDropInfo dropInfo)
        {
            //if (dropInfo.Data is not ITerrainItem sourceItem)
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop : dropInfo.Data is not ITerrainItem");
            //if (dropInfo.TargetItem is not ITerrainItem targetItem)
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop : dropInfo.TargetItem is not ITerrainItem");

            //ObservableCollection<ITerrainItem> sourceCollection = 
            //    dropInfo.DragInfo.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    (dropInfo.DragInfo.SourceCollection as ICollectionView)?.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop exception : Unable to find an ObservableCollection source");

            //ObservableCollection <ITerrainItem> targetCollection =
            //    dropInfo.TargetCollection as ObservableCollection<ITerrainItem> ??
            //    (dropInfo.TargetCollection as ICollectionView)?.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    (dropInfo.TargetCollection as ItemCollection)?.SourceCollection as ObservableCollection<ITerrainItem> ??
            //    throw new InvalidOperationException("TerrainsTreeViewDropHandler::Drop exception : Unable to find an ObservableCollection target");

            //if (sourceItem == targetItem || (sourceItem is TerrainBrace sourceBrace && sourceBrace.IsAncestorOf(targetItem)))
            //    return;

            //int insertIndex = sourceCollection == targetCollection && sourceCollection.IndexOf(sourceItem) < dropInfo.UnfilteredInsertIndex ? dropInfo.UnfilteredInsertIndex - 1 : dropInfo.UnfilteredInsertIndex;
            //sourceCollection.Remove(sourceItem);
            //targetCollection.Insert(Math.Min(insertIndex, targetCollection.Count), sourceItem);
        }
    }
}
