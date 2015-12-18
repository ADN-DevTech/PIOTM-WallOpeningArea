// (C) Copyright 2011 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software
// in object code form for any purpose and without fee is hereby
// granted, provided that the above copyright notice appears in
// all copies and that both that copyright notice and the limited
// warranty and restricted rights notice below appear in all
// supporting documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK,
// INC. DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL
// BE UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is
// subject to restrictions set forth in FAR 52.227-19 (Commercial
// Computer Software - Restricted Rights) and DFAR 252.227-7013(c)
// (1)(ii)(Rights in Technical Data and Computer Software), as
// applicable.
//

#region Imported Namespaces

//.NET common used namespaces
using System;
using System.Collections.Generic;

//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

#endregion

namespace ADNPlugin.Revit.WallOpeningArea
{
  [Transaction(TransactionMode.Automatic)]
  [Regeneration(RegenerationOption.Manual)]
  class ADNPApplication : IExternalApplication
  {
    const string PIOTM_PANEL_NAME = "Wall Opening";

    public Result OnStartup(UIControlledApplication application)
    {
      // get the executing assembly
      System.Reflection.Assembly dotNetAssembly = 
        System.Reflection.Assembly.GetExecutingAssembly();

      // create the push button data for our command
      PushButtonData pbdWallOpeningArea = new PushButtonData(
        "ADNP_WALL_OPENING_AREA", "Wall Opening Area",
        dotNetAssembly.Location,
        "ADNPlugin.Revit.WallOpeningArea.ADNPCommand");
      pbdWallOpeningArea.LargeImage =
        LoadPNGImageFromResource(
        "ADNPlugin.Revit.WallOpeningArea.icon32.png");
      pbdWallOpeningArea.LongDescription =
        "This plugin can be used to calculate the sum of openings " +
        "on a wall that are smaller than a specified value.";

      // get PIOTM panel
      RibbonPanel piotmPanel = GetPIOTMPanel(application);

      // finally add the item
      piotmPanel.AddItem(pbdWallOpeningArea);

      return Result.Succeeded;
    }

    /// <summary>
    /// Get the default PIOTM panel
    /// </summary>
    /// <param name="application">Revit application</param>
    /// <returns></returns>
    private static RibbonPanel GetPIOTMPanel(
      UIControlledApplication application)
    {
      IList<RibbonPanel> panels = application.GetRibbonPanels();
      foreach (RibbonPanel pnl in panels)
        if (pnl.Name == PIOTM_PANEL_NAME)
          return pnl;

      return application.CreateRibbonPanel(PIOTM_PANEL_NAME);
    }

    /// <summary>
    /// Load the bitmap from resource. The resource image 
    /// 'Build action' must be set to 'Embeded resource'.
    /// PNG extension supports transparency.
    /// </summary>
    /// <param name="imageResourceName">Resource name .PNG</param>
    /// <returns>The loaded image</returns>
    private static System.Windows.Media.ImageSource
      LoadPNGImageFromResource(string imageResourceName)
    {
      System.Reflection.Assembly dotNetAssembly = 
        System.Reflection.Assembly.GetExecutingAssembly();
      System.IO.Stream iconStream = 
        dotNetAssembly.GetManifestResourceStream(imageResourceName);
      System.Windows.Media.Imaging.PngBitmapDecoder bitmapDecoder =
        new System.Windows.Media.Imaging.PngBitmapDecoder(iconStream,
          System.Windows.Media.Imaging.BitmapCreateOptions.
          PreservePixelFormat, System.Windows.Media.Imaging.
          BitmapCacheOption.Default);
      System.Windows.Media.ImageSource imageSource = 
        bitmapDecoder.Frames[0];
      return imageSource;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
      return Result.Succeeded;
    }
  }
}
