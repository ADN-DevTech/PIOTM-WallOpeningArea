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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ADNPlugin.Revit.WallOpeningArea
{
  class SharedParameterFunctions
  {
    public const string PARAMETER_SMALL_OPEN_NAME =
      "Opening Area Smaller Max";
    public const string PARAMETER_TOTAL_OPEN_NAME =
      "Opening Area";
    public const string PARAMETER_GROUP_NAME =
      "WallOpeningsVolumeParamGroup";

    public static string SharedParameterFilePath
    {
      get
      {
        return System.IO.Path.Combine(
          System.IO.Path.GetDirectoryName(
          System.Reflection.Assembly.GetExecutingAssembly().Location),
          "WallOpeningsSharedParam.txt");
      }
    }

    public static bool OpenOrCreateWallSharedParameter(
        Document doc)
    {
      // Check on one element if the parameter already exist
      FilteredElementCollector coll = 
        new FilteredElementCollector(doc);
      coll.OfClass(typeof(Wall));
      Element ele = coll.FirstElement();
      if (ele != null)
      {
        Parameter param = ele.get_Parameter(
          PARAMETER_SMALL_OPEN_NAME);
        if (param != null) return true; //already exist
      }

      // Create if not exist
      try
      {
        if (!System.IO.File.Exists(SharedParameterFilePath))
          System.IO.File.Create(SharedParameterFilePath).Close();
      }
      catch 
      {
        TaskDialog.Show("Unable to create Shared Parameter file",
          "The plug-in could not create the required shared " +
          "parameter file at " + SharedParameterFilePath + 
          ". Command cancelled.");
        return false;
      }

      // Open the shared parameter file
      doc.Application.SharedParametersFilename =
          SharedParameterFilePath;
      DefinitionFile sharedParamDefFile =
          doc.Application.OpenSharedParameterFile();

      // Create a category set to apply the parameter
      CategorySet categorySet =
        doc.Application.Create.NewCategorySet();
      categorySet.Insert(doc.Settings.Categories.
        get_Item(BuiltInCategory.OST_Walls));
      Binding binding = doc.Application.Create.
        NewInstanceBinding(categorySet);

      // Create a shared parameter group
      string groupName = PARAMETER_GROUP_NAME;
      DefinitionGroup sharedParamDefGroup =
          sharedParamDefFile.Groups.get_Item(groupName);
      if (sharedParamDefGroup == null)
        sharedParamDefGroup = sharedParamDefFile.Groups.
          Create(groupName);

      // Create the parameter definition for small openings
      // Check if exists, create if required
      Definition paramSmallOpeningDef =
          sharedParamDefGroup.Definitions.get_Item(
          PARAMETER_SMALL_OPEN_NAME);
      if (paramSmallOpeningDef == null)
        paramSmallOpeningDef =
            sharedParamDefGroup.Definitions.Create(
            PARAMETER_SMALL_OPEN_NAME,
            ParameterType.Area);

      // Apply parameter for small openings to walls
      doc.ParameterBindings.Insert(paramSmallOpeningDef, binding);

      // Create the parameter definition for total openings
      // Check if exists, create if required
      Definition paramTotalOpeningDef =  
        sharedParamDefGroup.Definitions.get_Item( 
        PARAMETER_TOTAL_OPEN_NAME);
      if (paramTotalOpeningDef == null)
        paramTotalOpeningDef =
            sharedParamDefGroup.Definitions.Create(
            PARAMETER_TOTAL_OPEN_NAME,
            ParameterType.Area);

      // Apply parameter for total openings to walls
      doc.ParameterBindings.Insert(paramTotalOpeningDef, binding);

      return true;
    }
  }
}
