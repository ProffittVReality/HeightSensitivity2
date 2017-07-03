Mesh Maker - Modeling & Editing Collection.
v1.9.8 - Released 04/10/2015 by Alan Baylis
----------------------------------------


Foreword
----------------------------------------
Thank you for your purchase of Mesh Maker. This package contains a collection of 12 utilities for creating and working with meshes & prefabs within Unity.

Geom 2.0 - Quick and Easy Geometric Modeling
Mesh Editor - Advanced Mesh Editing Utility
Isosurface - Mathematics Inspired Meshes
Boolean Ops - Perform CSG Operations on Meshes
MeshPainter - Paint Directly on Meshes
Blenderizer - Object Focused Editor Camera
Metaballs - Create New Organic Base Meshes
Mesh Tools - Eleven Editing Tools in One
Sculptor - Solids of Revolution
3D Brush - Fully Featured Prefab Painting Tool
Mesh Cutter - Cut, Copy & Paste Parts of Meshes
Prefab Maker - Combine, Atlas & Prefab creation


Notes
----------------------------------------
The Mesh Maker menu is located in the Window section on the Unity menu bar.

The main menu now pops up on the scene view window and hides itself in the bottom left corner when not in use. To show the menu simply place the mouse over the visible title.

You can open up all of the programs at the same time and use them in combination, though this has not been thoroughly tested in all cases. If you have any problems try restarting Mesh Maker or Unity to see if that fixes the problem.
  
Geom:
Duplicates of grids made in the hierarchy will not be automatically added to Geom.
Don't delete the Framework or the Grids from the hierarchy, use Geom to delete grids or use the Exit button to end the build session.
Renaming the Grids in the hierarchy will not change their names within Geom.

Mesh Editor:
All of the functions work on skinned meshes except for triangle and edge extrusion.
To work on different sized models you can now change the epsilon value by going into the setting and changing the epsilon value.
When extruding multiple triangles that meet at a single point they sometimes have inverted faces. The solution is to extrude the triangles individually.

Metaballs:
This is an early version of the program and is suitable for working with up to a dozen or so quality metaballs but more if you work in a lower resolution. Ideal for creating a base mesh that can be tweaked with the Mesh Editor program.

Boolean Ops:
It is not recommended to do more that a few operations on the same target object or the geometry may become corrupt. While the program works well on simple objects it may fail on very complicated objects or objects with underlying problems like holes in their geometry. It is highly recommended that you make a copy of the target object and save your scene before using this software.

3D Brush:
In Unity 5 it is recommended to turn of continuous baking of lightmaps by going to the menu and navigating to Window/Lighting/Lightmaps and unchecking the checkbox. This will prevent lag in the editor.

 
To-do List
----------------------------------------
Geom:
Done - Improved normal smoothing.
Done - More CPU friendly.
Export to FBX.
Done - Spline based frameworks.
Add holes to mesh design. 

Mesh Cutter:
Done - Editing of skinned meshes.

Mesh Editor:
Done - Extrusion and deformation of meshes.
Done - Editing skinned meshes.
Edge loops.
Combine/Split vertices.

Mesh Painter:
Done - Direct painting of meshes in scene view window.
Better painting across triangle edges.
Different brushes.
Fill option.

Boolean Ops:
Mesh optimization to remove excess triangles after each operation.
Option to group triangles that share the same materials.
Recalculate bounding boxes and other obvious fixes.

Mesh Tools:
Done - Mesh Tools work with submeshes.
Done - More advanced UV Mapping.
Split with plane, with fill option.

Metaballs:
Option to use different formulas for calculating the metaball fields.
Finite support formula.
Auto resizing of the dimensions.
Process only the cubes around the mesh surface and other optimizations.

Sculptor:
Partial revolutions.
Choice of degree to rotate between 0 and 360.
Cap ends.

Prefab Maker:
Skinned meshes.
Tiled textures.
Hidden triangle removal.
Check with all types of shaders.


Common Issues / FAQ
----------------------------------------
Please visit the home page at http://www.meshmaker.com for the latest news and help forum.


Attributions
----------------------------------------

Boolean Ops uses parts of the open source software created by Evan Wallace and released under the MIT license. To get the original source code and license details follow the links below. 
Direct port of https://github.com/timknip/csg.as (Actionscript 3) to C# / Unity.
Copyright (c) 2011 Evan Wallace (http://madebyevan.com/), under the MIT license (original Javascript version, https://github.com/evanw/csg.js/)
Copyright (c) 2012 Tim Knip (http://floorplanner.com/), under the MIT license (AS3 port, https://github.com/evanw/csg.js/)
Copyright (c) 2013 Andrew Perry (http://omgwtfgames.com), under MIT license (C#/Unity port here at https://github.com/omgwtfgames/csg.cs)

Mesh Editor uses a cut down version of the undo/redo framework written by Nims72. Very nice code and highly recommended. (https://github.com/Nims72/Unity-Custom-Undo-Redo-System)

The textures used in the videos were made By Dexsoft Games and are available for free on the Asset Store. (http://www.assetstore.unity3d.com/en/#!/content/1809)

The resources feature of Prefab Maker is kindly provided by Simon Oliver to the public domain. (https://github.com/handcircus/Unity-Resource-Checker)

The example assets used with 3D Brush are available for free from Unity Technologies at the following locations:

Standard Terrain Assets
Available in Unity by clicking on the Assets menu item and going to Import Package/Terrain Assets.

Terrain Assets
https://www.assetstore.unity3d.com/en/#!/content/6

Shanty Town: Brush Vegetation
https://www.assetstore.unity3d.com/en/#!/content/41

The city model used in the screenshots and videos for Mesh Cutter is called Japanese Otaku City and was created by ZENRIN CO. LTD. I would like to thank the creators of this great asset which is available for free on the asset store at  https://www.assetstore.unity3d.com/en/#!/content/20359


Contact
----------------------------------------
Alan Baylis
www.meshmaker.com
support@meshmaker.com


Update Log
-----------------------------------------
v1.0.0 released 20/09/13
First release of Mesh Maker. 

v1.0.1 released 5/10/13
Improved smoothing of normals.
More CPU friendly.

v1.2.0 released 6/01/14
New feature for creating meshes using the marching cubes algorithm and isosurfaces.
New Isosurface tutorial.
Added option to create inverted meshes.
Single grid meshes are now possible, ideal for billboards and decals.
User defined maximum smooth angle.
Texture planar mapping is now possible from three directions.
Included 60 primitive meshes and 17 frameworks.

v1.3.0 released 26/01/14 
A new toolkit called Mesh Tools has been added with the following features:
Clone Meshes
Move/Rotate Pivot Point
Uniform Scaling
Snap To Grid
Invert Meshes
Flip Meshes

v1.4.0 released 26/02/14
A new texturing utility called Mesh Painter has been added.
New Mesh Painter tutorial.
Added support for meshes with submeshes to Mesh Tools.
New GUI look.
Source moved to Editor folder to allow test builds.

v1.5.0 released 15/05/14
Mesh Painter now paints directly on objects in the Scene View window.
Fixed a bug in Mesh Tools related to Snap To Grid timing out after about 10 minutes.
Box Projection UV mapping now labeled correctly in Mesh Maker.
Restored planar UV mapping in the XY plane. 
Original Mesh Painter functionality moved to Mesh Tools.
Mesh Tools now contains 8 utilities including Split Mesh and Transform Textures.

v1.6.0 released 04/06/14
Added Boolean Ops (CSG/BSP operations) to the programs list. 
Cleaned up Mesh Painter memory usage.
First release of Blenderizer.

v1.7.0 released 02/08/14
Beta release (v0.7) of Mesh Editor.
Original Mesh Maker program is now called Geom.
Integrated Blenderizer into Mesh Editor.
Added feature to Geom to set control point position explicitly.

v1.7.1 released 06/08/14
Mesh Editor:
Fixed bug when deleting multiple triangles.
Fixed undo/redo step names
Fixed double undo for delete
Cleaned up more memory leaks.
Added option to change epsilon values.

v1.8.0 released 03/09/14
Beta release (v0.5) release of Metaballs.
Improved main menu which discretely hides itself.
New GUI layout for all windows.
Added three new tools to Mesh Tools. Real Scale, Double Sided Meshes and Save Mesh.
Small fixes here and there.

v1.9.0 released 26/09/14
Beta release (v0.8) of Sculptor.
Fixed Undo/Redo bug in Mesh Editor.
Main folder is now portable to subfolders.

v1.9.1 released 06/11/14
Added individual menus for each program

v1.9.2 released 31/03/15
Checked all programs for Unity 5 compatibility
Upgraded Geom to version 2.0 with the following new features:
- New 2D interface with 3 orthogonal views.
- Now possible to move points in the Y axis.
- Insert and Delete control points.
- Unlimited grid sizes.
- Undo/Redo feature.
- Easily enter accurate point positions.
- Save/Load program settings.
- Save/Load frameworks to XML files.
- Custom colors for 3D and 2D views.
- Show/Hide 2D interface.
- Change background picture for tracing objects.
- 15 new starting geometric shapes.
- Numbered control points in 2D and 3D views.
- Synchronized point movement across all grids.
- Automatic prefab creation with new meshes.

v1.9.3 released 24/04/15
First release of 3D Brush v0.9.
Fix to Geom for scroll wheel in 2D interface.

v1.9.4 released 18/05/15
First release of Mesh Cutter v0.9.
Changed the example brush scale in 3D Brush
3D Brush fix to duplication of save settings in the XML file
3D Brush now saves all settings

v1.9.5 released 15/06/15
Complete rebuild of Mesh Editor v1.0
Moved Mesh Maker menu to the main Unity menu bar
Programs now listed in alphabetical order
Main menu now works in all scene view windows including isometric views

v1.9.6 released 31/07/15
First release of Prefab Maker v0.9
Changed the mesh copy dialog for Mesh Cutter & Mesh Editor
Added select all triangles by material to Mesh Cutter
Mesh Cutter Alt key now blocks triangle selection
Added Mac friendly hotkey selection to Mesh Cutter

v1.9.7 released 14/08/15
Mesh Cutter now works with skinned meshes.
Mesh Editor now works with skinned meshes.
Subdivision of triangles added to Mesh Editor.

v1.9.8 released 04/10/15
Mesh Maker:
New splash screen
Real time news updates
Resources folder renamed to Files
New settings for Main Menu
Fixed namespace clashes
Main folder is now moveable within project folder

Mesh Editor:
New option to show normals
New option to recalculate normals
New option to recalculate tangents
Update UVs now works with normal editing
Locked object stays locked after delete, etc
Fix to Snap To Grid
Fix to shader warning
Fix to handle position after extrude
Fix to double sided normals
Added tool to generate secondary UV set
Added tool to recalculate normals

3D Brush:
Added option to generate random names

Prefab Maker:
Added clear warning if selected folder is not empty
Suppressed log warnings if materials and submeshes don't match 
