var IngamePanelScratchPanelLoaded = false;
document.addEventListener('beforeunload', function () {
    IngamePanelScratchPanelLoaded = false;
    /*var iframe = document.querySelector("#ScratchPanelIframe");
    if (iframe) {
        iframe.src = "";
    }
    var ScratchPanelWrap = document.querySelector("#ScratchPanelWrap");
    if (ScratchPanelWrap) {
        ScratchPanelWrap.innerHTML += "unload"+(new Date()).toString();
    }*/
}, false);
class IngamePanelScratchPanel extends HTMLElement {
    constructor() {
        super();
        console.log('IngamePanelScratchPanel2');
        var iframe = document.querySelector("#ScratchPanelIframe");
        if (iframe) {
            iframe.src = "http://192.168.2.104/scratchpad.html";
        }
    }
    isDebugEnabled() {
        var self = this;
        if (typeof g_modDebugMgr != "undefined") {
            g_modDebugMgr.AddConsole(null);
            g_modDebugMgr.AddDebugButton("ButtonScratchID1", function() {
                console.log('ButtonScratchID1');
                console.log(self.instrumentIdentifier);
            });
            g_modDebugMgr.AddDebugButton("ButtonScratchTemplateID1", function() {
                console.log('ButtonScratchTemplateID1');
                console.log(self.templateID);
            });
            g_modDebugMgr.AddDebugButton("ButtonScratchSource1", function() {
                console.log('ButtonScratchSource1');
                console.log(window.document.documentElement.outerHTML);
            });
        } else {
            Include.addScript("/JS/debug.js", function () {
                if (typeof g_modDebugMgr != "undefined") {
                    g_modDebugMgr.AddConsole(null);
                    g_modDebugMgr.AddDebugButton("ButtonScratchID2", function() {
                        console.log('ButtonScratchID2');
                        console.log(self.instrumentIdentifier);
                    });
                    g_modDebugMgr.AddDebugButton("ButtonScratchTemplateID2", function() {
                        console.log('ButtonScratchTemplateID2');
                        console.log(self.templateID);
                    });
                    g_modDebugMgr.AddDebugButton("ButtonScratchSource2", function() {
                        console.log('ButtonScratchSource2');
                        console.log(window.document.documentElement.outerHTML);
                    });
                } else {
                    /*setTimeout(() => {
                        self.isDebugEnabled();
                    }, 2000);*/
                }
            });
        }
    }
    connectedCallback() {
        var self = this;
        /*setTimeout(() => {
            self.isDebugEnabled();
        }, 1000);*/
        console.log('IngamePanelScratchPanel1');

        this.m_MainDisplay = document.querySelector("#MainDisplay");
        this.m_MainDisplay.classList.add("hidden");

        this.m_Footer = document.querySelector("#Footer");
        this.m_Footer.classList.add("hidden");

        /*this.m_ScratchPanelWrap = document.querySelector("#ScratchPanelWrap");
        this.m_ScratchPanelWrap.innerHTML += "asdas"+(new Date()).toString();*/

        var iframe = document.querySelector("#ScratchPanelIframe");
        if (iframe) {
            iframe.src = "http://192.168.2.104/scratchpad.html";
        }
        /*this.m_ButtonElement = document.querySelector("#DeviceType");
        this.m_ImageElement = document.getElementById("DeviceImage");
        this.m_ButtonElement.addEventListener("OnValidate", (e) => {
            this.updateImage();
        });*/
    }
    updateImage() {
    }
}
window.customElements.define("ingamepanel-scratch", IngamePanelScratchPanel);
checkAutoload();