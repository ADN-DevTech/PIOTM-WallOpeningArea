# PIOTM-WallOpeningArea

Plugin of the Month, August 2011
Brought to you by the Autodesk Developer Network

Wall Opening Area

# Description

This plugin calculates the sum of openings on each wall
and store the values in two shared parameters of each wall:

    Opening Area Smaller Max
        Sum all area value smaller than a specific value
    Opening Area
	Sum all opening areas

# System Requirements

This plugin has been tested with Revit Architecture 2011 and 2012,
and requires the .NET Framework 3.5 

A pre-built version of the plugin has been provided which should
work on 32- and 64-bit Windows systems.
The plugin has not been tested with all Revit verticals, 
but should work (see "Feedback" below, otherwise).

The source code has been provided as a Visual Studio 2008 project
containing C# code (not required to run the plugin).

# Installation

The following steps are for using the plugin with Revit 
Architecture 2012. 
If you are using Revit 2011, please consider the release
number as "2011" in the paths listed below.  

1. If you are using Vista or Windows 7, first check
if the zip file needs to be unblocked.
Right-click on the zip file and select "Properties". If you see
an "Unblock" button, then click it. 

2. Copy the plugin module "ADNPlugin-WallOpeningArea.dll" and the 
.addin manifest file, "ADNPlugin-WallOpeningArea.addin", to one of 
the following locations: 

For Windows XP: 

C:\Documents and Settings\<your login>\Application Data\
Autodesk\Revit\Addins\2012\

or 

C:\Documents and Settings\All Users\Application Data\
Autodesk\Revit\Addins\2012\


The first location will make the plugin available for your use 
only, while the second is for all users of your computer.

** Note: The first location is recommended if you have security 
permission issues (e.g., when UAC is turned on), such as problem 
creating the shared parameter file.

For Vista/Windows 7:

C:\Users\<your login>\AppData\Roaming\Autodesk\Revit\Addins\2012\

or 

C:\ProgramData\Autodesk\Revit\Addins\2012\


The first location will make the plugin available for your use 
only, while the second is for all users of your computer.

** Note: The first location is recommended if you have security 
permission issues (e.g., when UAC is turned on), such as problem 
creating the shared parameter file.


If you decide for a different location for the .dll, please modify 
the following line in the .addin file to match to the location that 
you have copied:

<Assembly>.\ADNPlugin-WallOpeningArea.dll</Assembly>

3. Once installed, "Wall Opening Area" command becomes available 
in your Revit.  Go to "Add-ins" tab >> "External Tools" panel. 
You should see "Wall Opening Area" command listed there. 

4. After run the command, check the newly created parameters on any
wall element of the project.

# Usage

Inside your Revit-based application, make sure you are in 3D view
before running the command. 
Go to "Add-ins" tab >> "External Tools" panel >> "Wall Opening Area" 
to start the command. 

In the dialog that appears, you can type in the maximum area of 
opening to search on walls. Click 'OK'. The command will search 
on each wall for openings smaller than the specified value, sum all 
these areas and store the information as a 'Shared Parameter'.

When the command is run for the first time, the plugin will create
a shared parameter file named "WallOpeningsSharedParam.txt" in the 
same folder as the plugin's .dll module.  

# Uninstallation

Simply removing "ADNPlugin-WallOpeningArea.addin" file from 
your installation folder will uninstall the plugin. 

Limitations
--------------
The following scenarios are considered: hosted elements (such as 
doors, windows, etc.), hosted opening elements, inner loop profile
openings that cross the entire wall width. Outer loops profile 
changes are not considered (to create an opening on the border of
wall, consider use opening element instead profile edit)

Walls which are created as in-place family are not supported.
Walls created from a mass with curved surfaces are also not 
supported.  
 
The command requires a 3D View to run. It is also required that all
elements to be considered are visible. Any type of opening that is
invisible on the active 3D view WILL NOT be considered on the sum.

The parameters are not dynamically updated, which means that the
command must be executed in order to updated the parameter value.

Known Issues
------------
If the profile of the opening is not constant along the opening 
width, the command may not identify it as a 'full opening' 
and do not consider it. To avoid (or reduce) miscalculations,
pay attention to such openings.

We have identified that in certain situations the plug-in 
could not create the required shared parameter file due to 
security permissions (e.g. when UAC is turned on). 
If you have already installed this plug-in, just replace
the ADNPlugin-WallOpeningArea.dll with the new version (1.0.1).

Author
------
This plugin was written by Augusto Goncalves of Autodesk Developer 
Technical Services team. 

Acknowledgements
----------------
Autodesk Brazil Technical Specialist Ricardo Bianca De Mello who
helped with industry expertise and 
Brazilian reseller Mauricio Antonini (Brasoftware) who helped 
on initial validation and testing models.

Further Reading
---------------
For more information on developing with Revit, please visit the
Revit Developer Center at http://www.autodesk.com/developrevit

Feedback
--------
Email us at labs.plugins@autodesk.com with feedback or requests for
enhancements.

Release History
---------------

<<<<<<< Updated upstream
1.0    Original release                     (August 1, 2011)
1.0.1  Modified the Installation Instruction 
       in the ReadMe.txt, considering the 
       permission issue with the location 
       of the shared parameter file         (August 9, 2011)
1.0.2  Ribbon button created                (October 13, 2011)
=======
    1.0    Original release                     (August 1, 2011)
    1.0.1  Modified the Installation Instruction 
           in the ReadMe.txt, considering the 
           permission issue with the location 
           of the shared parameter file         (August 9, 2011)
    1.0.2  Ribbon button created                (October 13, 2011)
>>>>>>> Stashed changes

(C) Copyright 2011 by Autodesk, Inc. 

Permission to use, copy, modify, and distribute this software in
object code form for any purpose and without fee is hereby granted, 
provided that the above copyright notice appears in all copies and 
that both that copyright notice and the limited warranty and
restricted rights notice below appear in all supporting 
documentation.

AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
UNINTERRUPTED OR ERROR FREE.
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
