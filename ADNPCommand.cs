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
  [Transaction(TransactionMode.Manual)]
  [Regeneration(RegenerationOption.Manual)]
  public class ADNPCommand : IExternalCommand
  {
    /// <summary>
    /// The one and only method required by the IExternalCommand 
    /// interface, the main entry point for a external command.
    /// </summary>
    /// <param name="commandData">Input argument providing access
    /// to the Revit application and its documents 
    /// and their properties.</param>
    /// <param name="message">Return argument to display a message to
    /// the user in case of error if Result is not Succeeded.</param>
    /// <param name="elements">Return argument to highlight elements 
    /// on the graphics screen if Result is not Succeeded.</param>
    /// <returns>Cancelled, Failed or Succeeded Result code.
    /// </returns>
    public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)
    {
      Document doc = commandData.Application.ActiveUIDocument.
        Document;

      if (!(doc.ActiveView is View3D))
      {
        TaskDialog.Show("Require 3D View",
            "This command must be executed from a 3D " +
            "view with all relevant elements visible");
        return Result.Cancelled;
      }

      // Open a form to collect this value
      SearchConfigForm frm = new SearchConfigForm(commandData);
      if (frm.ShowDialog() != System.Windows.Forms.
          DialogResult.OK) return Result.Cancelled;
      double minOpeningValue = (double)frm.AreaField;

      WallAreaFunctions.CalculateWallOpeningAreas(
          commandData.Application.ActiveUIDocument, minOpeningValue);

      // Must return some code
      return Result.Succeeded;
    }
  }
}
