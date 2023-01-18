<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="frmSubirArchivosDeducs.aspx.vb" Inherits="frmSubirArchivosDeducs"
    Title="COBAEV - Nómina - Subir archivos de deducciones para descuento en nómina" StylesheetTheme="SkinFile"
    Culture="es-MX" UICulture="es" %>

<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <style type="text/css">
        .ajax__fileupload_fileItemInfo div.removeButton{width:100px;}
        div.ajax__fileupload_uploadbutton{width:120px;}
        .ajax__fileupload .ajax__fileupload_selectFileContainer{width: 110px;}
        .ajax__fileupload_selectFileContainer .ajax__fileupload_selectFileButton{width: 110px;}
    </style>
    <script type="text/javascript">
        //run AjaxFileUpload_change_text() function after page load
        //that example uses  jquery
        $(document).ready(function () {
            AjaxFileUpload_change_text();
        });

        function AjaxFileUpload_change_text() {

            //Here you can edit whatever you want = "..."

            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Selecione archivo";
            Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Arrastre archivos aquí";
            Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "pendiente";
            Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Eliminar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Cargar archivos";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Cargado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "Cargado {0} %";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploading = "Cargando";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} archivo(s) pendientes para cargar.";
            Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "Todos los archivos fueron cargados.";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileList = "Lista de archivos cargados:";
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "Por favor seleccione archivo(s) a cargar.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancelling = "Cancelando...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadError = "Ocurrió un error durante la carga del archivo.";
            Sys.Extended.UI.Resources.AjaxFileUpload_CancellingUpload = "Cancelando carga...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Cargando archivo: {0}.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "Cancelar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "cancelado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "Carga de archivo cancelada";
            Sys.Extended.UI.Resources.AjaxFileUpload_DefaultError = "Error al cargar el archivo";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingHtml5File = "Cargando archivo: {0} de {1} bytes.";
            Sys.Extended.UI.Resources.AjaxFileUpload_error = "error";
        }
    </script>
        <asp:UpdatePanel ID="updpnl" runat="server">
        <ContentTemplate>
        <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="viewUpLoad" runat="server">
            <div>
                <table style="width: 100%;" align="center">
                    <tr>
                        <td style="vertical-align: top; text-align: right">
                            <h2>
                                Sistema de nómina: Subir archivos de deducciones para descuento en nómina
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        <div>
                            <asp:Label ID="lblSelQna" runat="server" SkinID="SkinLblNormal" Text="Seleccione quincena"></asp:Label>
                        </div>
                        <div>
                            <asp:DropDownList ID="ddlQnasAbiertasParaCaptura" runat="server" 
                                SkinID="SkinDropDownList" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete"
                                AllowedFileTypes="txt" MaximumNumberOfFiles="10" OnUploadCompleteAll="AjaxFileUpload1_UploadCompleteAll"  />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:View>
        <asp:View ID="viewRelacionaArchivos" runat="server">
            Archivos cargados correctamente en el servidor
        </asp:View>
        <asp:View ID="viewError" runat="server">
            <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
            <div id="divBotonesErrores">
                <p class="submitButton">
                    <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip=""
                        />
                    <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                        ToolTip="" 
                        PostBackUrl="~/Consultas/Empleados/Historia.aspx?TipoOperacion=4" />
                </p>
            </div>
        </asp:View>
        </asp:MultiView>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
