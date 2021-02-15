## Welcome

The toolbar generator is a small windows desktop application running on .net 5 which lets you create named toolbar templates to be further used to display content from an external (outside the simulator) source in an iframe.

### Requirements

- Windows with .net 5 runtime
- MSFS SDK
  - v1.0.0 had been tested with the 0.9.0.0 steam version

### Installation
After downloading and extracting the application, from the link above or via the repository releases pages, you should have the following:

- a "Template" folder
- and "MsfsToolbarGenerator.exe"

You can copy those wherever you want.

### Generate a toolbar

![Image of the Generator](toolbar-generator-main.png)

_Template folder_: Select the folder from the extracted ZIP named "Template"

_Workspace folder_: Any empty folder will do for now

_Package tool_: Select the package tool from the MSFS SDK (in tools/bin)

_Toolbar name_: The Name of the toolbar. Please do not use "Space" or any special character for now ;-)

**_Create_**: Copies the template files to the workspace folder and renames them

_Packagetool parameters_: After "Create" this field will show the parameters used to call the package tool to build the toolbar. You may correct them now, but at your own responsibility!

**_Pack_**: Calls the package tool, waits for it to compile, copies the build artifacts to their respective places and creates a layout.json file

The "Pack" may take a while as the package tool does some magic in the background. You are good as long as the application does not close. The operation is finished when the progress bar disapears.

### Link the toolbar to a website

Finally you need to tell the toolbar the URL to the content it should display.

- Open "html_ui\InGamePanels\YourFancyToolbarNamePanel\YourFancyToolbarNamePanel.js" with a editor
- Replace "http://localhost/index.html" at line 11 and 27 with your URL. Do keep the quotation marks while doing so!

If you are not sure if the URL you choose works in the simulator, you might create a simple local html page with an iframe and test it in your browser beforehand.

Keep in mind that only simple sites currently work within the sim. So dont try to add netflix ;-)

### Use it in the simulator

Just copy the whole workspace directory into your community folder and name it accordingly.

### Troubleshooting

Why is my toolbar not in the sim:

- You might need to remove the "build" folder from the toolbar
  - Works on my system without removing it
  
Why does my toolbar does not show the content I set it up for?

- You might already have another toolbar with the same name so they are overwriting each other when loaded into the sim

The application suddenly closes!

- There currently is no error handling or whatsoever. So any little thing thats not going as expected might kill the application.

### Future versions (maybe) include:

- Error handling and build log
- Use "Space" and other characters in the toolbar name
- Set the iframe url directly in the application
- Manage multiple toolbars and their urls
