function Resaltar_On(GridView)
{
    if(GridView != null)
    {
       GridView.originalBgColor = GridView.style.backgroundColor;
       GridView.originalColor = GridView.style.color;
       GridView.style.backgroundColor = "#CCCCCC"; /*"#666666;#DBE7F6";*/
       GridView.style.color = "black";
    }
}

function Resaltar_Off(GridView)
{
    if(GridView != null)
    {
        GridView.style.backgroundColor = GridView.originalBgColor;
        GridView.style.color = GridView.originalColor;
    }
}

function abreVentanaEmergente(URL, NombreVentana){ 
   window.open(URL,NombreVentana,"left=10,width=600,height=300,Location=No,Menubar=No,Toolbar=No,Top=50,Left=300,Resizable=Yes,ScrollBars=Yes") 
} 

function abreVentana(URL, NombreVentana){ 
   window.open(URL,NombreVentana,"width=600,height=900,Location=No,Menubar=No,Toolbar=No,Top=50,Left=300,Resizable=Yes,ScrollBars=Yes") 
}

function abreVentanaImpresion(URL, NombreVentana) {
    window.open(URL, NombreVentana, "width=900,height=800,Location=No,Menubar=No,Toolbar=No,Top=0,Left=0,Resizable=Yes,ScrollBars=Yes");
}

function abrePopUpMediana(URL, NombreVentana){
    miWindow = window.open(URL, NombreVentana, "width=700,height=600,Location=No,Menubar=No,Toolbar=No,Top=50,Left=300,Resizable=Yes,ScrollBars=Yes");
} 

function configuraVentana(){
	moveTo(300,50)
	resizeTo(600,900)
}
function limpiaEtiqueta(etiqueta) 
    {
        document.getElementById(etiqueta).innerText = "";
    }
function cambiaTextoEtiqueta(etiqueta, texto) 
{
    document.getElementById(etiqueta).innerText = texto;
}
function abreCalendario(URL, txtbxFchNac, hfFchNac) 
    {
        var WinSettings = "center:yes;dialogHeight:300px;dialogWidth:300px";
        var MyArgs = window.showModalDialog(URL, '', WinSettings);
        if (MyArgs != null)
        {
            if (MyArgs[0] != "0"){
                document.getElementById(txtbxFchNac).value = MyArgs[0].toString();
                document.getElementById(hfFchNac).value = MyArgs[0].toString();
            }
        }
    }
function abreVentanaBuscaEmpsDesdeWebForms(URL, txtbxRFC, txtbxNomEmp, hfRFC, hfNomEmp) 
    {
        var WinSettings = "center:yes;resizable:yes;dialogHeight:500px;dialogWidth:500px";
        var MyArgs = window.showModalDialog(URL, '', WinSettings);
        if (MyArgs != null)
        {
            document.getElementById(txtbxRFC).value = MyArgs[0].toString();
            document.getElementById(hfRFC).value = MyArgs[0].toString();
            document.getElementById(txtbxNomEmp).value = MyArgs[1].toString();
            document.getElementById(hfNomEmp).value = MyArgs[1].toString();
        }
    }
function abreVentanaBuscaEmpsDesdeMenu(URL, txtbxRFC, txtbxNomEmp) 
    {
        var WinSettings = "center:yes;resizable:yes;dialogHeight:500px;dialogWidth:500px";
        window.showModalDialog(URL, '', WinSettings);
    }
function abreVentanaChica(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogHeight:300px";
    window.showModalDialog(URL, '', WinSettings);
}
function abreVentanaModal(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogHeight:300px";
    window.showModalDialog(URL, self, WinSettings);
}
function doPostBack()
{
    __doPostBack("ibActualizar","");
}
function abreVentanaMediana(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogWidth:600px;dialogHeight:500px";
    window.showModalDialog(URL, '', WinSettings);
}
function abreVentMedAncha(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogWidth:800px;dialogHeight:500px";
    window.showModalDialog(URL, '', WinSettings);
}
function seleccionaEmpleado(RFC, ApePat, ApeMat, Nombre)
{
    var RFC = document.getElementById(RFC).innerText;
    var ApePat = document.getElementById(ApePat).innerText;
    var ApeMat = document.getElementById(ApeMat).innerText;
    var Nombre = document.getElementById(Nombre).innerText;
    var MyArgs = new Array(RFC, ApePat + ' ' + ApeMat + ' ' + Nombre);
    window.returnValue = MyArgs;
    window.close();
}
function abreVentMedAlta(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogWidth:700px;dialogHeight:700px";
    window.showModalDialog(URL, '', WinSettings);
}

function abreVentMediaScreen(URL, NombreVentana){
    window.open(URL,NombreVentana,"width=1400,height=350,Location=No,Menubar=No,Toolbar=No,Top=0,Left=0,Resizable=Yes,ScrollBars=Yes") 
}

function abreVentMedAncha2(URL) 
{
    var WinSettings = "center:yes;resizable:yes;dialogWidth:900px;dialogHeight:600px";
    window.showModalDialog(URL, '', WinSettings);
}

function abreVentMedAncha3(URL) {
    var WinSettings = "center:yes;resizable:yes;dialogWidth:1000px;dialogHeight:700px";
    window.showModalDialog(URL, '', WinSettings);
}