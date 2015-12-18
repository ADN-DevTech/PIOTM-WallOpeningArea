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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace ADNPlugin.Revit.WallOpeningArea
{
  public partial class SearchConfigForm : System.Windows.Forms.Form
  {
    ExternalCommandData _commandData;

    public SearchConfigForm(ExternalCommandData commandData)
    {
      InitializeComponent();
      _commandData = commandData;
    }

    private void Config_Load(object sender, EventArgs e)
    {
      FormatOptions fo = _commandData.Application.
        ActiveUIDocument.Document.
        ProjectUnit.get_FormatOptions(UnitType.UT_Area);

      DisplayUnitType dut = fo.Units;// e.g. DUT_SQUARE_METERS
      string unitLbl = LabelUtils.GetLabelFor(dut); // e.g. Sq meters 

      // Put a label on the form
      lblUnitName.Text = unitLbl;

      // Set a initial value of 2 sq meters (21.52 sq feet)
      txtArea.Value = (decimal)
        (21.52782 / ConverstionFactorToSqFeet(fo.Units));

      // Set a incremental of 10%
      txtArea.Increment = txtArea.Value / 10;

      // Set a maximum value as 10x
      txtArea.Maximum = txtArea.Value * 10;
    }

    /// <summary>
    /// Entered area (in Square Feet)
    /// </summary>
    public double AreaField
    {
      get
      {
        FormatOptions fo = _commandData.Application.
          ActiveUIDocument.Document.
        ProjectUnit.get_FormatOptions(UnitType.UT_Area);

        double enteredValue = (double)txtArea.Value;

        return enteredValue * ConverstionFactorToSqFeet(fo.Units);
        //switch (fo.Units)
        //{
        //  case DisplayUnitType.DUT_ACRES:
        //    return enteredValue * Acres_To_SqFeet;
        //  case DisplayUnitType.DUT_HECTARES:
        //    return enteredValue * Hectares_To_SqFeet;
        //  case DisplayUnitType.DUT_SQUARE_FEET:
        //    return enteredValue;
        //  case DisplayUnitType.DUT_SQUARE_METERS:
        //    return (enteredValue / SqFeet_To_SqMeter);
        //  case DisplayUnitType.DUT_SQUARE_INCHES:
        //    return enteredValue * SqInche_To_SqFeet;
        //  case DisplayUnitType.DUT_SQUARE_CENTIMETERS:
        //    return enteredValue * SqCm_To_SqFeet;
        //  case DisplayUnitType.DUT_SQUARE_MILLIMETERS:
        //    return enteredValue * SqMm_To_SqFeet;
        //}
        //return ((double)txtArea.Value);
      }
    }

    private double ConverstionFactorToSqFeet(
      DisplayUnitType unitFrom)
    {
      switch (unitFrom)
      {
        case DisplayUnitType.DUT_ACRES:
          return Acres_To_SqFeet;
        case DisplayUnitType.DUT_HECTARES:
          return Hectares_To_SqFeet;
        case DisplayUnitType.DUT_SQUARE_FEET:
          return 1;
        case DisplayUnitType.DUT_SQUARE_METERS:
          return (1 / SqFeet_To_SqMeter);
        case DisplayUnitType.DUT_SQUARE_INCHES:
          return SqInche_To_SqFeet;
        case DisplayUnitType.DUT_SQUARE_CENTIMETERS:
          return SqCm_To_SqFeet;
        case DisplayUnitType.DUT_SQUARE_MILLIMETERS:
          return SqMm_To_SqFeet;
      }
      return 1;
    }

    private const double SqInche_To_SqFeet = 0.00694444444;
    private const double SqCm_To_SqFeet = 0.00107639104;
    private const double SqMm_To_SqFeet = 0.0000107639104;
    private const double Acres_To_SqFeet = 43560;
    private const double Hectares_To_SqFeet = 107639;
    private const double SqFeet_To_SqMeter = 0.09290304;

    private void btnOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
      System.Windows.Forms.MessageBox.Show(
        "This plugin can be used to calculate the sum of openings " +
        "on a wall that are smaller than a specified value. This " +
        "plugin was written by Augusto Goncalves of Autodesk " +
        "Developer Technical Services team.",
        "Wall Opening Area Plug-in", MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}
