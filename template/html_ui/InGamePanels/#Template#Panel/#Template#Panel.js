var IngamePanel#Template#PanelLoaded = false;
document.addEventListener('beforeunload', function () {
    IngamePanel#Template#PanelLoaded = false;
}, false);
class IngamePanel#Template#Panel extends HTMLElement {
    constructor() {
        super();
        console.log('IngamePanel#Template#Panel2');
        var iframe = document.querySelector("##Template#PanelIframe");
        if (iframe) {
            iframe.src = "http://localhost/index.html";
        }
    }
    connectedCallback() {
        var self = this;
        
        console.log('IngamePanel#Template#Panel1');

        this.m_MainDisplay = document.querySelector("#MainDisplay");
        this.m_MainDisplay.classList.add("hidden");

        this.m_Footer = document.querySelector("#Footer");
        this.m_Footer.classList.add("hidden");

        var iframe = document.querySelector("##Template#PanelIframe");
        if (iframe) {
            iframe.src = "http://localhost/index.html";
        }
    }
    updateImage() {
    }
}
window.customElements.define("ingamepanel-#template#", IngamePanel#Template#Panel);
checkAutoload();