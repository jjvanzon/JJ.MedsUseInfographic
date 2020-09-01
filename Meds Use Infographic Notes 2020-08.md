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
    - [x] Setting up planning notes
    - [x] Publishing Working Methods folder (with documentation templates) to an online git repository.
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

- [ ] JJ.Framework.VectorGraphics doc comments
- [x] Making missing doc comment result in warnings.
    - Checking the check box "XML documentation file"
    - In the Build options of JJ.Framework.VectorGraphics.
    - For both Debug and Release configurations.
- [x] 'Can be made private' warnings seem missing. O wait... it is 'can be made internal' warnings that might be turned on.
- [x] Drawing namespace doc comments
- [x] Enums namespace doc comments
- [x] EventArg namespace doc comments
    - [x] Perhaps indicate whether coordinates are not only scaled or pixels, but also whether they are absolute or relative.
- [ ] __Gestures namespace doc comments__
    - __Was at: GestureInternals__
    - [x] After studingy the way Gestures as a whole look again, what would happen is:
    - [ ] A wrapper for a *surface/drawing/graphics technology* might pass along picked up mouse and keyboard events to the:
    - [ ] *Diagram.GestureHandling*, which calls Diagram.Recalculate at certain times but also delegates to an internal:
    - [ ] *GestureHandler*:
        - [x] Would figures out things like:
            - [x] *Hit testing*: Which element was hit (currently only checks hits within rectagles despite other shapes like ellipses being part of the API).
            - [x] *Bubbling*: When events might *bubble* to parent elements
            - [x] *Mouse capturing*: when a mousedown might *fix* the involved element no matter where the mouse arrow goes until you let go of the mouse button.
        - [x] GestureHandler would call individual gestures to handle off the gesture after the involved element might have been figured out.
        - [ ] This may happen in a bit of an elaborated way. GestureHandler may call:
            - [ ] *GestureBase.GestureInternals*: which are *internal* as a trick to try and isolate these members, which delegates back to
            - [ ] *GestureBase.InternalHandle...* methods that are *protected*, which are implemented inside a Gesture class.
        - [x] *Keyboard gestures* are currently only usable on the Diagram level or Diagram.BackGround level, so not related to an element. (That might require focus handling. *Focus* is *not* a feature of this API (yet).)
    - [x] *Gesture* objects: publically have basically *constructors* and *events*. Individual gesture objects would be tied to either the Diagram, Diagram.BackGround(?) or to individual Elements, which individually handle things like ClickEvent for a specific element for instance.
    - [ ] So there I end up at the Gesture objects which I am currently trying to document.
    - [x] I would like to involve how these gesture objects are to be used. Specifically for instance instantiating gestures and assigning them to elements.
- [ ] Doc comments for some of JJ.Framework.Drawing
- [ ] Doc comments for some of JJ.Framework.VectorGraphic

### 2020-08-26 Postponed (Scarce )JJ.Framework.VectorGraphics Refactorings

- [ ] May rename GestureHandler to GestureElementDeterminer or something, since that might be the responsibility it would take on.
- [ ] Renaming coordinate properties (X, Y) to be longer, yet more descriptive?
    - The idea 'makes sense on its own' might not hold up.
    - The aspects relative/absolute and pixel/scaled seem refined and not so obvious.
    - When properties may be called X: is it scaled, is it relative or absolute? Is it absolute in case of diagram related? Is it (absolute?) pixels when related to gesture parameters?
    - That the code looks more 'fun', well, that might not hold up when things get confusing.
    - 'Absolute' may mean related to the top-left corner of the Diagram.
    - 'Relative' may mean relative to the element's direct parent.
    - 'Scaled' may in a certain case mean pixels if Diagram.ScaleMode = Pixels.
- [ ] Try making gesture delegation less elaborate.
    - There seems to be some seemingly redundant delegation just to hide some members and make a neater interface on the outside, that just seems confusing when trying to understand the internal code. My opinion is that there might be multiple 'parties' or 'roles' to keep happy: someone creating the API, someone trying to read the API code, someone implementing a Gesture class, and someone trying to use the API, the gesture part specifically. Those might currently all be *me*, but all those roles may be equally important. So a cleaner interface but confusing delegation might not be ideal. There might be other solutions.