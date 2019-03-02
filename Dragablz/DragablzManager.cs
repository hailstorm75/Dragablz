﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dragablz.Dockablz;

namespace Dragablz
{
  public static class DragablzManager
  {
    public static readonly HashSet<Layout> LOADED_LAYOUTS = new HashSet<Layout>();
    public static readonly HashSet<TabablzControl> LOADED_TABABLZ_INSTANCES = new HashSet<TabablzControl>();
    public static readonly HashSet<TabablzControl> VISIBLE_TABABLZ_INSTANCES = new HashSet<TabablzControl>();

    public static void LoadTabablzInstance(TabablzControl tabablzControl)
    {
      LOADED_TABABLZ_INSTANCES.Add(tabablzControl);
      tabablzControl.SelectionChanged += TabablzControlOnSelectionChanged;
    }

    public static void UnloadTabablzInstrance(TabablzControl tabablzControl)
    {
      LOADED_TABABLZ_INSTANCES.Remove(tabablzControl);
      tabablzControl.SelectionChanged -= TabablzControlOnSelectionChanged;
    }

    private static void TabablzControlOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    {
      OnTabSelectionChanged(selectionChangedEventArgs);
    }

    public static event EventHandler<SelectionChangedEventArgs> TabSelectionChanged;

    private static void OnTabSelectionChanged(SelectionChangedEventArgs e)
      => TabSelectionChanged?.Invoke(e.Source, e);
  }
}
