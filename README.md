# MSFS-Toolbar-Generator

.net 5 WPF App to semi automatic create MSFS toolbars.

In the app
- select template and workspace folder
- create toolbar code from template

Manual steps
- run msfs packager tool on the created data
- copy spb and manifest files
 
In the app
- create layout.json

Not much of a functionallity yet. But I plan on extend it to at least auto pack and copy the generated files in the near future.

The long term goal is some kind of toolbar management application. Where you have a bunch of sources (Urls) that you can assign to a different toolbars or combine them within a single toolbar (with some sort of tabs to switch sources within the toolbar). The toolbars then get automagically created and published to the sim.
Maybe even with some kind of toolbar profiles you can select before flying to get a different setup toolbar layout for eg. VR vs Desktop.

### Credits
#### Template
https://github.com/bymaximus/msfs2020-toolbar-window-template
#### Inspiration for layout.json generator
https://github.com/HughesMDflyer4/MSFSLayoutGenerator
