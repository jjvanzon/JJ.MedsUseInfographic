Meds Use Infographic Notes
==========================

Introduction
------------

This aims to be the planning doc / notes for making a computer program that plots an infographic of some medication use over time using JJ.Framework.VectorGraphics.

Steps
-----

- [ ] Strategy
  - [ ] Following a rigid plan might take a lot of energy from me.
- [ ] Prep dev environment
  - [x] Publishing Working Methods folder (with documentation templates) to an online git repository.
  - [x] Setting up planning notes
  - [x] Updating Visual Studio
  - [x] Windows updates
  - [x] Setting up git repository
  - [x] Updating ReSharper
  - [x] Uninstalling Visual Studio 2017
  - [x] ReSharper performance tuning
  - [ ] .. Fine-tuning Visual Studio settings
- [ ] Software architecture (optionals)
  - [ ] .. Processing ReSharper warnings
  - [ ] .. Setting up folder subdivision / code structure
  - [x] Setting up automated build
    - [x] master/develop branch and build separation.
    - [x] JJ.Framework is not in the right folder
    - [x] / Changing it to "..\JJs Software\JJ.Framework" may work for all the builds? > Did not do.
    - [x] / The folder JJs Software might not exist in the build engine? > Did not do.
    - [x] / Alternative: Making a second local clone of JJ.Framework? > Did not do.
    - [x] Alternative: Move contents of JJs Software Small folder to the JJs Software folder?
    - [x] JJ.Framework references are still not found.
    - [x] Manually editing the csproj to try to fix paths to JJ.Framework projects.
  - [x] Using MarkDown for this document?
  - [ ] >.. NuGet packaging JJ.Framework.VectorGraphics?
  - [ ] >.. NuGet packaging JJ.Framework.WinForms?
  - [ ] >.. Try using .NET Standard?
  - [ ] >.. Sharing on LinkedIn?
  - [ ] >.. Sharing on Facebook?
  - [ ] >.. JJ.Framework issues (see Details below)
- [ ] Programming
  - [x] Code boiler plating
  - [x] Code layering
  - [x] Entity model
  - [x] Repository (in-memory data)
  - [x] View models
  - [x] Presenter
  - [x] Entity to view model mapping
  - [ ] __JJ.Framework.VectorGraphics doc comments__
  - [ ] >.. Vector graphics elements
  - [ ] >.. View model to vector graphics mapping
  - [ ] >.. WinForms wrapper
  - [ ] >.. Pill circles
  - [ ] Vector graphics styling
  - [ ] Total a day curve
  - [ ] Trace paths
  - [ ] >.. JJ.MedsUseInfographic.Data.SpecialFormat or .FromNotes: Parsing text from how it was typed in meds use notes.
  - [ ] Details (see further down)
  
Details
-------

### 2020-08-05 MedsUseInfoGraphic Details

- [ ] Spooky action: Milligrams a pill and size of the vector graphics element might like to be related, but the information seems to get lost after converting it to PillViewModel, even though the numeric relationships still seems to act at a distance between layers.
- [ ] ViewModel variable names might give enough clues about how to draw. In other programs it might be purely conceptual: the data shown on screen. But in this case how it is shown might be important to be better apparent in the view model?

### 2020-08-05 JJ.Framework Details

- [x] Gave a VectorGraphics Element.Children a Clear method.
- [x] Error placing DiagramControl on Form: cannot load JJ.Framework.VectorGraphics.
  - [x] It says the same in another project: Synthesizer.
  - [x] The JJ.Framework.WinForms.TestForms seems to run fine.
  - [x] A JJ.Framework.WinForms.TestForms Form will also open in de designer.
  - [x] Added all the JJ.Framework csproj's that the dependencies asked for, because a few were missing. That seemed to fix it for this project.
- [ ] >.. Adding margin in pixels seems non-trivial? Can it be made easier?
  - [ ] >.. ElementPosition.SetMarginInPixels() based on code from CurveDetailsViewModelToDiagramConverter around line 148?
- [ ] >.. Correcting JJ.Framework bug:
  - [ ] >.. JJ.Framework.Collections.CollectionExtensions.SingleOrDefaultWithClearException recursive on all paths indicated by ReSharper.

### 2020-08-26 TODO JJ.Framework.VectorGraphics Doc Comments

Maybe structurally go through some JJ.Framework code and add comments.
Maybe be strategic and write even when in doubt it works that way.
Because switching between writing and trying it out might be too much for me.
Also, to not refactor might be a good rule to make things easier on me.
Member comments might be sometimes omitted, by using "inheritdoc" tags to refer to the class's comment.

Looking up the details turned out to be a burden. Work was stopped for now.

- [x] Making missing doc comment result in warnings.
  - Checking the check box "XML documentation file"
  - In the Build options of JJ.Framework.VectorGraphics.
  - For both Debug and Release configurations.
- [x] 'Can be made private' warnings seem missing. O wait... it is 'can be made internal' warnings that might be turned on.
- [ ] JJ.Framework.VectorGraphics
  - WAS AT: ScaleModeEnum
- [ ] Some of JJ.Framework.Drawing
- [ ] Some of JJ.Framework.VectorGraphics
